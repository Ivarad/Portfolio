using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using flexnetcoresite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using Microsoft.Data.SqlClient;

namespace flexnetcoresite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            this.db = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Katalog()
        {
            return View(await db.Products.ToListAsync());
        }
        public IActionResult Cab()
        {
            return View();
        }
        public IActionResult Reg()
        {
            return View();
        }
        public IActionResult ZabPass()
        {
            return View();
        }
        public IActionResult Zakaz()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }

        public IActionResult Trash()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }



        [HttpPost]
        public async Task<IActionResult> Reg(Users user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cab(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.LoginT && u.Password == model.PasswordT);
                if (user != null)
                {
                    await Authenticate(model.LoginT); // аутентификация
                    return RedirectToAction("Katalog", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    return RedirectToAction("Index", "Home");
                }

            }
            return RedirectToAction("Cab", "Home");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.Add(db.Products.Find(ID));
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return Redirect("~/Home/Katalog");

        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.RemoveAt(number);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return Redirect("~/Home/Trash");
        }


        public async Task<IActionResult> SuccZak()
        {

            if (User.Identity.IsAuthenticated)
            {
                string mail = "";

                List<Users> user = await db.Users.ToListAsync();

                foreach (var item in user)
                {
                    if (User.Identity.Name == item.Login)
                    {
                        mail = item.Email;
                    }
                }
                if (mail != "")
                {
                    MailAddress from = new MailAddress("GGVP1278@yandex.ru", "Магазин Серая булочка");

                    MailAddress to = new MailAddress(mail);

                    MailMessage m = new MailMessage(from, to);

                    m.Subject = "Оформление заказа";

                    m.Body = "<h2>Спасибо что заказали наших булочек!</h2>";

                    m.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.yandex.com", 587);

                    smtp.Credentials = new NetworkCredential("GGVP1278@yandex.ru", "flexyandexClaren1278");

                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }

            }

            return Redirect("~/Home/Zakaz");
        }

    }
}
