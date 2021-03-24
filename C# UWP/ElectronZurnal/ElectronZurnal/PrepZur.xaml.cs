using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ElectronZurnal
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    [Serializable]
    public class Assess
    {
        public Assess(String Name, String Group, String Date, String Assessments, String Discip)
        {
            this.name = Name;
            this.group = Group;
            this.date = Date;
            this.assessments = Assessments;
            this.discip = Discip;
        }

        public Assess()
        {

        }
        public String name { get; set; }
        public String group { get; set; }
        public String date { get; set; }
        public String assessments { get; set; }
        public String discip { get; set; }



    }
    public sealed partial class PrepZur : Page
    {


        public static List<string> listdicp = new List<string>();
        public static List<string> listgroup = new List<string>();
        public List<Assess> listassesss = new List<Assess>();
        public List<Users> userlist = new List<Users>();

        public PrepZur()
        {
            this.InitializeComponent();
            date.Date = DateTime.Now;
            Assassment.SelectedIndex = 0;
            Checked();
            CheckedGr();
            CheckedAssess();
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

            foreach (var item in listdicp)
            {
                Discp.Items.Add(item);
            }

            Discp.SelectedIndex = 0;
            

        }
        public async void CheckedGr()
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

            foreach (var item in listgroup)
            {
                Group.Items.Add(item);
            }

            Group.SelectedIndex = 0;
            // obnovflex();

        }

        private async void Group_DropDownClosed(object sender, object e)
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

            foreach (var item in userlist)
            {
                if (Group.SelectedItem.ToString() == item.group)
                {
                    Stud.Items.Add(item.name);
                }

            }

            Stud.SelectedIndex = 0;
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

            Gridasses.ItemsSource = listassesss;



        }
        private async void flexassess()
        {


            listassesss = await ZapmetAssess();



        }
        public async Task<List<Assess>> ZapmetAssess()
        {
            string assesm;
            if (Assassment.SelectedIndex == 0) assesm = "нб";
            else assesm = (Assassment.SelectedIndex + 1).ToString();

            if (Stud.SelectedIndex >= 0 && Group.SelectedIndex >= 0 && Discp.SelectedIndex >= 0)
            {



                StorageFolder folder = ApplicationData.Current.LocalFolder;


                StorageFile file = await folder.CreateFileAsync("Assessments.xml", CreationCollisionOption.ReplaceExisting);

                XmlSerializer xml = new XmlSerializer(typeof(List<Assess>));

                Assess flexus = new Assess(Stud.SelectedItem.ToString(), Group.SelectedItem.ToString(), date.SelectedDate.ToString(), assesm, Discp.SelectedItem.ToString());


                listassesss.Add(flexus);

                Stream stream = await file.OpenStreamForWriteAsync();

                xml.Serialize(stream, listassesss);

                stream.Close();

                
            }
            return listassesss;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            flexassess();
            this.Gridasses.Columns.Clear();
            this.Gridasses.ItemsSource = null;


            Gridasses.ItemsSource = listassesss;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
