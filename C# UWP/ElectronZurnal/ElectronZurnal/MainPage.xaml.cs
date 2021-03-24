using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Security.Cryptography;
using System.Text;
using Windows.Storage;
using System.Xml.Serialization;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ElectronZurnal
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {

        public static List<Users> user = new List<Users>();
        public MainPage()
        {
            this.InitializeComponent();
            Listchek();


        }

        public static string Pass(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }


        }


        private void Authen_Click(object sender, RoutedEventArgs e)
        {
            bool succ = false;


            for (int i = 0; i < user.Count; i++)
            {
                if ((user[i].login != Login.Text || user[i].pass != Pass(Password.Password)) && (Login.Text != "Registration" && Password.Password != "FlexReg"))
                {
                    succ = true;
                }
                else
                {
                    succ = false;
                    break;
                }
            }


            if (succ == false)
            {


                if (Login.Text == "Registration" && Password.Password == "FlexReg")
                {
                    this.Frame.Navigate(typeof(Registration));
                }
                else
                {

                    for (int i = 0; i < user.Count; i++)
                    {
                        if (user[i].type == "0" && user[i].login == Login.Text && user[i].pass == Pass(Password.Password)) this.Frame.Navigate(typeof(Adminflexer));

                        if (user[i].type == "1" && user[i].login == Login.Text && user[i].pass == Pass(Password.Password)) this.Frame.Navigate(typeof(PrepZur));

                        if (user[i].type == "2" && user[i].login == Login.Text && user[i].pass == Pass(Password.Password)) this.Frame.Navigate(typeof(StudZur),user[i].name.ToString());

                    }
                   
                }
            }
            else DisplayAuthDialog();



        }

        public async void Listchek()
        {

            user = new List<Users>();

            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Users.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml = new XmlSerializer(typeof(List<Users>));

            try
            {

                Stream stream = await file.OpenStreamForReadAsync();

                user = (List<Users>)xml.Deserialize(stream);

                stream.Close();

            }
            catch { }

        }


        private async void DisplayAuthDialog()
        {
            ContentDialog flexDialog = new ContentDialog
            {
                Title = "Ошибка",
                Content = "Неверный логин или пароль.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await flexDialog.ShowAsync();
        }

        
    }
}
