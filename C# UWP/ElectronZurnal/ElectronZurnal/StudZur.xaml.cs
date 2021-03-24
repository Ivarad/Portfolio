using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class StudZur : Page
    {

        public static List<string> listdicp = new List<string>();
        public List<Assess> listassesss = new List<Assess>();
        public string glex;
        public StudZur()
        {
            this.InitializeComponent();
            Checked();
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            glex = Convert.ToString(e.Parameter);
        }
    
        private void Discp_DropDownClosed(object sender, object e)
        {
            flexob();
        }

        public void flexob()
        {
            string perflex;

            Gridasses.Items.Clear();
            foreach (var item in listassesss)
            {
                if (item.name == glex && item.discip == Discp.SelectedItem.ToString())
                {
                    perflex = "Дата и время: " + item.date + "  " + "Оценка: " + item.assessments;
                    Gridasses.Items.Add(perflex);
                }

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
