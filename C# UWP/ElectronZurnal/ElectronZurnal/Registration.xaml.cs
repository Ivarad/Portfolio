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
using System.Threading.Tasks;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ElectronZurnal
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 


    public sealed partial class Registration : Page
    {

        public static List<string> listgroup = new List<string>();
        public static List<Users> user = new List<Users>();
        public Registration()
        {
            this.InitializeComponent();
            
            Adminflexer flexadm = new Adminflexer();
            Checkgr();
            Checked();

        }

        public async void Checked()
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


        public async void Registr_Click(object sender, RoutedEventArgs e)
        {
            bool chekflex = true;
            string flexgroups;

            if (Reglog.Text == "" || Regpas.Password == "" || Name.Text == "" || Sername.Text == "" || Typechel.SelectedIndex < 0)
            {
                DisplayDialog();
            }
            else
            {

                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].login == Reglog.Text)
                    {
                        DisplayCopDialog();
                        chekflex = false;
                    }

                }

                if (chekflex == true)
                {


                    StorageFolder folder = ApplicationData.Current.LocalFolder;


                    StorageFile file = await folder.CreateFileAsync("Users.xml", CreationCollisionOption.OpenIfExists);

                    XmlSerializer xml = new XmlSerializer(typeof(List<Users>));

                    if (Groups.SelectedIndex<0)
                    {
                        flexgroups = null;
                    }
                    else
                    {
                        flexgroups = Groups.SelectedItem.ToString();
                    }

                    Users flexus = new Users(Reglog.Text, Pass(Regpas.Password), Name.Text, Sername.Text, Convert.ToString(Typechel.SelectedIndex),flexgroups);


                    user.Add(flexus);


                    Stream stream = await file.OpenStreamForWriteAsync();

                    xml.Serialize(stream, user);

                    stream.Close();


                    Reglog.Text = "";
                    Regpas.Password = "";
                    Name.Text = "";
                    Sername.Text = "";
                    Typechel.SelectedIndex = -1;


                    DisplaySuccDialog();

                }
            }


        }


        private async void DisplayDialog()
        {
            ContentDialog flexDialog = new ContentDialog
            {
                Title = "Ошибка",
                Content = "Все поля должны быть заполнены.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await flexDialog.ShowAsync();
        }
        private async void DisplaySuccDialog()
        {
            ContentDialog flexDialog = new ContentDialog
            {
                Title = "Произошел флекс успеха",
                Content = "Регистрация прошла успешно.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await flexDialog.ShowAsync();
        }

        private async void DisplayCopDialog()
        {
            ContentDialog flexDialog = new ContentDialog
            {
                Title = "Ошибка",
                Content = "Такой логин уже существует.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await flexDialog.ShowAsync();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Backforadmin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Adminflexer));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            test(Convert.ToBoolean(e.Parameter));
        }

        async void test(bool varible)
        {

            if (varible)
            {
                Backforadmin.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Collapsed;
            }
            else
            {
                Backforadmin.Visibility = Visibility.Collapsed;
                Back.Visibility = Visibility.Visible;
            }

        }

        private void Typechel_DropDownClosed(object sender, object e)
        {
            if (Typechel.SelectedIndex == 2) Groups.Visibility = Visibility.Visible;
            else Groups.Visibility = Visibility.Collapsed;

            Checkgr();

        }


        private async void Checkgr()
        {
            if (Typechel.SelectedIndex == 2)
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

                Groups.Items.Clear();

                foreach (string group in listgroup)
                {
                    Groups.Items.Add(group);
                }

                Groups.SelectedIndex = 0;
            }
            
        }

    }


}
