using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OfficeOpenXml;
using Windows.UI.Notifications;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ElectronZurnal
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    ///

    [Serializable]
    public class Users
    {
        public Users(String Login, String Pass, String Name, String Sername, String Type, String Group)
        {
            this.login = Login;
            this.pass = Pass;
            this.name = Name;
            this.sername = Sername;
            this.type = Type;
            this.group = Group;
        }

        public Users()
        {

        }
        public String login { get; set; }
        public String pass { get; set; }
        public String name { get; set; }
        public String sername { get; set; }
        public String type { get; set; }
        public String group { get; set; }




    }
    public sealed partial class Adminflexer : Page
    {


        public static List<string> listdicp = new List<string>();
        public static List<string> listgroup = new List<string>();
        public List<Users> userlist = new List<Users>();
        public List<Assess> listassesss = new List<Assess>();


        public Adminflexer()
        {
            this.InitializeComponent();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Checkedus();
            Checked();
            CheckedG();
            CheckedAssess();
        }



        private async void Addbt_Click(object sender, RoutedEventArgs e)
        {
            if (Namedisp.Text != "")
            {


                listdicp = await Zapmet();

                Discip.Items.Clear();

                foreach (string dicpi in listdicp)
                {
                    Discip.Items.Add(dicpi);
                }

                Namedisp.Text = "";
            }
        }

        private async void Editbt_Click(object sender, RoutedEventArgs e)
        {
            if (Namedisp.Text != "")
            {


                listdicp[Discip.SelectedIndex] = Namedisp.Text;

                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Dispc.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<string>));



                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, listdicp);

                stream.Close();

                obnovflex();

                Namedisp.Text = "";
            }
        }

        private async void Deletebt_Click(object sender, RoutedEventArgs e)
        {
            if (Discip.SelectedIndex > -1)
            {


                listdicp.RemoveAt(Discip.SelectedIndex);


                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Dispc.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<string>));



                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, listdicp);

                stream.Close();

                obnovflex();
            }
        }

        public async void Checked()
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Dispc.xml", CreationCollisionOption.OpenIfExists);



            XmlSerializer xml = new XmlSerializer(typeof(List<string>));

            try
            {

                Stream stream = await file.OpenStreamForReadAsync();

                listdicp = (List<string>)xml.Deserialize(stream);

                stream.Close();

            }
            catch { }

            obnovflex();

        }

        public async Task<List<string>> Zapmet()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Dispc.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer xml = new XmlSerializer(typeof(List<string>));


            listdicp.Add(Namedisp.Text);


            Stream stream = await file.OpenStreamForWriteAsync();

            xml.Serialize(stream, listdicp);

            stream.Close();

            return listdicp;
        }

        public void obnovflex()
        {
            Discip.Items.Clear();

            foreach (string dicpi in listdicp)
            {
                Discip.Items.Add(dicpi);
            }
        }

        public async Task<List<string>> CheckedG()
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Group.xml", CreationCollisionOption.OpenIfExists);



            XmlSerializer xml = new XmlSerializer(typeof(List<string>));

            try
            {

                Stream stream = await file.OpenStreamForReadAsync();

                listgroup = (List<string>)xml.Deserialize(stream);

                stream.Close();

            }
            catch { }

            obnovflexG();

            foreach (var item in listgroup)
            {
                groupsas.Items.Add(item);
            }

            groupsas.SelectedIndex = 0;

            return listgroup;

        }
        public void obnovflexG()
        {
            Group.Items.Clear();

            foreach (string group in listgroup)
            {
                Group.Items.Add(group);
            }
        }

        public async Task<List<string>> ZapmetG()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Group.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer xml = new XmlSerializer(typeof(List<string>));


            listgroup.Add(Namegroup.Text);


            Stream stream = await file.OpenStreamForWriteAsync();

            xml.Serialize(stream, listgroup);

            stream.Close();

            return listgroup;
        }

        private async void Addgr_Click(object sender, RoutedEventArgs e)
        {
            if (Namegroup.Text != "")
            {


                listgroup = await ZapmetG();

                Group.Items.Clear();

                foreach (string group in listgroup)
                {
                    Group.Items.Add(group);
                }

                Namegroup.Text = "";
            }
        }

        private async void Editgr_Click(object sender, RoutedEventArgs e)
        {
            if (Namegroup.Text != "")
            {


                listgroup[Group.SelectedIndex] = Namegroup.Text;

                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Group.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<string>));



                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, listgroup);

                stream.Close();

                obnovflexG();

                Namegroup.Text = "";
            }
        }

        private async void Deletegr_Click(object sender, RoutedEventArgs e)
        {
            if (Group.SelectedIndex > -1)
            {


                listgroup.RemoveAt(Group.SelectedIndex);


                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Group.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<string>));



                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, listgroup);

                stream.Close();

                obnovflexG();
            }
        }

        private void Addus_Click(object sender, RoutedEventArgs e)
        {

            /////////////////

            this.Frame.Navigate(typeof(Registration), true);


        }

        public async void Checkedus()
        {


            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Users.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml = new XmlSerializer(typeof(List<Users>));

            try
            {

                Stream stream = await file.OpenStreamForReadAsync();

                userlist = (List<Users>)xml.Deserialize(stream);

                stream.Close();

            }
            catch { }

            dategrid.ItemsSource = userlist;

        }

        private async void Editus_Click(object sender, RoutedEventArgs e)
        {

            int chet = 0;
            listgroup = await CheckedG();

            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist[i].pass.Length != 32)
                {
                    userlist[i].pass = Pass(userlist[i].pass);
                }
            }

            for (int i = 0; i < userlist.Count; i++)
            {
                for (int ii = 0; ii < listgroup.Count; ii++)
                {
                    if (userlist[i].group == listgroup[ii] && userlist[i].type == "2")
                    {
                        chet++;
                    }
                }
                if (chet == 0)
                {
                    userlist[i].group = null;
                }
            }

            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Users.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer xml = new XmlSerializer(typeof(List<Users>));



            Stream stream = await file.OpenStreamForWriteAsync();

            xml.Serialize(stream, userlist);

            stream.Close();

            Checkedus();


        }

        private async void Deleteus_Click(object sender, RoutedEventArgs e)
        {
            if (dategrid.SelectedIndex > -1)
            {


                userlist.RemoveAt(dategrid.SelectedIndex);


                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Users.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<Users>));



                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, userlist);

                stream.Close();


                Checkedus();
                
            }
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_Zur(object sender, RoutedEventArgs e)
        {

            using (ExcelPackage excel = new ExcelPackage())
            {

                List<Assess> selgr = new List<Assess>();

                foreach (var item in listassesss)
                {
                    if (item.group == groupsas.SelectedItem.ToString())
                    {
                        selgr.Add(item);
                    }
                }


                excel.Workbook.Properties.Title = groupsas.SelectedItem.ToString();

                ExcelWorksheet sheet = excel.Workbook.Worksheets.Add(groupsas.SelectedItem.ToString());

                if (selgr.Count > 0)
                {
                    for (int i = 1; i < 5; i++)
                    {

                        for (int ii = 2; ii < selgr.Count + 2; ii++)
                        {

                            if (i == 1)
                            {
                                sheet.Cells[1, i].Value = "Имя";
                                sheet.Cells[ii, i].Value = selgr[ii - 2].name.ToString();
                            }
                            if (i == 2)
                            {
                                sheet.Cells[1, i].Value = "Дата";
                                sheet.Cells[ii, i].Value = selgr[ii - 2].date.ToString();
                            }
                            if (i == 3)
                            {
                                sheet.Cells[1, i].Value = "Оценка";
                                sheet.Cells[ii, i].Value = selgr[ii - 2].assessments.ToString();
                            }
                            if (i == 4)
                            {
                                sheet.Cells[1, i].Value = "Диcциплина";
                                sheet.Cells[ii, i].Value = selgr[ii - 2].discip.ToString();
                            }
                        }
                    }
                }
                else
                {
                    sheet.Cells[1, 1].Value = "В данной группе нет оценок";
                }

                FileInfo file = new FileInfo(ApplicationData.Current.LocalFolder.Path + @"\" + "Zurnal.xlsx");

                excel.SaveAs(file);

                messageflex();

            }

        }

        public void messageflex()
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();

            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");

            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode("Уведомление"));

            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode("Файл успешно создан."));

            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");

            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);

            toastNotifier.Show(toast);

            
        }
        public async void CheckedAssess()
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;


            StorageFile file = await folder.CreateFileAsync("Assessments.xml", CreationCollisionOption.OpenIfExists);



            XmlSerializer xml = new XmlSerializer(typeof(List<Assess>));

            try
            {

                Stream stream = await file.OpenStreamForReadAsync();

                listassesss = (List<Assess>)xml.Deserialize(stream);

                stream.Close();

            }
            catch { }

        }
    }
}
