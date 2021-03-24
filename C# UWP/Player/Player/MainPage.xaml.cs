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
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using System.Collections.Generic;
using System.IO;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Player
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static bool lv = false; 
        static FileOpenPicker opener;
        static StorageFile file = null;
        static string path = ApplicationData.Current.LocalFolder.Path;
   
        public MainPage()
        {
            this.InitializeComponent();

            opener = new FileOpenPicker();

            opener.FileTypeFilter.Add(".mp3");

            playp.Icon.Name = "play";

            

            SetPlaylists();


        }

        private void Player(object sender, RoutedEventArgs e)
        {


            if(playp.Icon.Name == "play")
            {
                media.Play();
                playp.Icon = new SymbolIcon(Symbol.Pause);
                playp.Icon.Name = "pause";
            }
            else
            {
                media.Pause();
                playp.Icon = new SymbolIcon(Symbol.Play);
                playp.Icon.Name = "play";
            }

           
            
        }

        private async void direct(object sender, RoutedEventArgs e)
        {
            media.Stop();

            file = await opener.PickSingleFileAsync();

            if(file != null)
            {
                media.SetSource(await file.OpenReadAsync(), "");
            }
        }

        private async void playlistadd(object sender, RoutedEventArgs e)
        {
    
            media.Stop();

            string name = "";

         

            Directory.CreateDirectory(ApplicationData.Current.LocalFolder + @"\"+name);


        }

        private void Volslide_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
           
            Slider slider = sender as Slider;
            if(slider != null)
            {
                media.Volume = slider.Value / 100;
            }
          
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void ButCreatePlaylist_Click(object sender, RoutedEventArgs e)
        {

            if (path != ApplicationData.Current.LocalFolder.Path)
            {
         
                return;
            }

            if (!(NamePlaylist.Text == ""))
            {
                if (!Directory.Exists(ApplicationData.Current.LocalFolder.Path + @"\" + NamePlaylist.Text))
                {
                    Directory.CreateDirectory(ApplicationData.Current.LocalFolder.Path + @"\" + NamePlaylist.Text);
                    ListPlaylists.Items.Add(new Button() { Content = NamePlaylist.Text });
                    (ListPlaylists.Items[ListPlaylists.Items.Count - 1] as Button).Click += MainPage_Click;
                }

            }
        }

        private async void ButAddMusic_Click(object sender, RoutedEventArgs e)
        {

            if (path == ApplicationData.Current.LocalFolder.Path)
            {
                return;
            }

            var files = await opener.PickMultipleFilesAsync();

            if (files == null)
            {
                return;
            }

            for (int count = 0; count < files.Count; count++)
            {
                await files[count].CopyAsync(await StorageFolder.GetFolderFromPathAsync(path));
                ListPlaylists.Items.Add(new Button() { Content = files[count].Name });
                (ListPlaylists.Items[count] as Button).Click += MainPage_Click1;
            }


        }

        private void ButBackToFolders_Click(object sender, RoutedEventArgs e)
        {
            path = ApplicationData.Current.LocalFolder.Path;

            SetPlaylists();

        }

        async void SetPlaylists()
        {

            ListPlaylists.Items.Clear();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            var list = await folder.GetFoldersAsync();

            for (int count = 0; count < list.Count; count++)
            {
                ListPlaylists.Items.Add(new Button() { Content = list[count].DisplayName });
                (ListPlaylists.Items[count] as Button).Click += MainPage_Click;
            }

        }

        private async void MainPage_Click(object sender, RoutedEventArgs e)
        {

            path = path + @"\" + (sender as Button).Content;

            ListPlaylists.Items.Clear();

            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(path);

            var list = await folder.GetFilesAsync();

            for (int count = 0; count < list.Count; count++)
            {
                if (list[count].FileType == ".mp3")
                {
                    ListPlaylists.Items.Add(new Button() { Content = list[count].Name });
                    (ListPlaylists.Items[count] as Button).Click += MainPage_Click1;
                }
            }


        }

        private async void MainPage_Click1(object sender, RoutedEventArgs e)
        {
            string localpath;
            localpath = path + @"\" + (sender as Button).Content;

            StorageFile file = await StorageFile.GetFileFromPathAsync(localpath);

            media.Stop();

            media.SetSource(await file.OpenReadAsync(), "");

            lv = true;
        }


        

    }
}
