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
using Windows.UI;
using Windows.ApplicationModel.Core;
using Windows.UI.Text;
using Windows.Graphics.Printing;
using Windows.UI.Xaml.Printing;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Provider;
using Windows.Storage.Streams;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Textred
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string[] fontsname = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();
   
        public List<BitmapImage> pageImages = new List<BitmapImage>();
        public static IRandomAccessStream randAccStream;
        public static StorageFile file;

        private PrintManager printMan;

        public  PrintDocument printDoc = new PrintDocument();
        public IPrintDocumentSource printDocSource;

        public MainPage()
        {
            this.InitializeComponent();

            Font.ItemsSource = fontsname;




            printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintTaskRequested;

            printDoc = new PrintDocument();
            printDocSource = printDoc.DocumentSource;
            printDoc.Paginate += Paginate;
            printDoc.GetPreviewPage += GetPreviewPage;
            printDoc.AddPages += AddPages;
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            flextextwrite.Document.Selection.CharacterFormat.Bold = Windows.UI.Text.FormatEffect.Toggle;
        }

        private void Italics_Click(object sender, RoutedEventArgs e)
        {
            flextextwrite.Document.Selection.CharacterFormat.Italic = Windows.UI.Text.FormatEffect.Toggle;
        }

        private void Underlined_Click(object sender, RoutedEventArgs e)
        {
            
            if (flextextwrite.Document.Selection.CharacterFormat.Underline == Windows.UI.Text.UnderlineType.None)
            {
                flextextwrite.Document.Selection.CharacterFormat.Underline = Windows.UI.Text.UnderlineType.Single;
            }
            else
            {
                flextextwrite.Document.Selection.CharacterFormat.Underline = Windows.UI.Text.UnderlineType.None;
            }
        }

        private void Font_DropDownClosed(object sender, object e)
        {
            if(Font.SelectedIndex >= 0)
            {
                flextextwrite.Document.Selection.CharacterFormat.Name = fontsname[Font.SelectedIndex];
            }
            
        }

      

        private void flexbeffont(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
           
            if (Fontsize.Text.Length != 0)
            {
                try
                {

                    if (!Char.IsDigit(Convert.ToChar(Fontsize.Text.Substring(Fontsize.Text.Length - 1, Fontsize.Text.Length))))
                    {
                        Fontsize.Text = "";
                    }
                }
                catch { }
                
            }

        }

        private void Fontsize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Fontsize.Text.Length != 0)
            {
                flextextwrite.FontSize = Convert.ToInt32(Fontsize.Text);
            }
        }

        private void ColorText_DropDownClosed(object sender, object e)
        {
            if(flextextwrite != null)
            {
                if (ColorText.SelectedIndex == 0) flextextwrite.Document.Selection.CharacterFormat.ForegroundColor = Colors.Black;
                if (ColorText.SelectedIndex == 1) flextextwrite.Document.Selection.CharacterFormat.ForegroundColor = Colors.Red;
                if (ColorText.SelectedIndex == 2) flextextwrite.Document.Selection.CharacterFormat.ForegroundColor = Colors.Green;
                if (ColorText.SelectedIndex == 3) flextextwrite.Document.Selection.CharacterFormat.ForegroundColor = Colors.Blue;
                if (ColorText.SelectedIndex == 4) flextextwrite.Document.Selection.CharacterFormat.ForegroundColor = Colors.Yellow;
            }
            

        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (flextextwrite.Document.CanUndo())
            {
                flextextwrite.Document.Undo();
            }
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
                flextextwrite.Document.Selection.Cut();
        }

        private void MenuFlyoutItem_Click_3(object sender, RoutedEventArgs e)
        {
            if (flextextwrite.Document.CanCopy())
            {
                flextextwrite.Document.Selection.Copy();
            }
        }

        private void MenuFlyoutItem_Click_4(object sender, RoutedEventArgs e)
        {
            if (flextextwrite.Document.CanPaste())
            {
                flextextwrite.Document.Selection.Paste(0);
            }
        }

        private void MenuFlyoutItem_Click_5(object sender, RoutedEventArgs e)
        {
            flextextwrite.Document.Selection.SetText(TextSetOptions.None, string.Empty);
        }

        private void MenuFlyoutItem_Click_6(object sender, RoutedEventArgs e)
        {
            flextextwrite.Focus(FocusState.Pointer);
            flextextwrite.Document.Selection.SetRange(0, flextextwrite.Document.Selection.EndPosition);

        }

        private async void MenuFlyoutItem_Click_7(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".rtf");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null)
            {
                try
                {
                    Windows.Storage.Streams.IRandomAccessStream randAccStream =
                await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                    flextextwrite.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
                catch (Exception)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "File open error",
                        Content = "Sorry, I couldn't open the file.",
                        PrimaryButtonText = "Ok"
                    };

                    await errorDialog.ShowAsync();
                }
            }
        }

        private async void MenuFlyoutItem_Click_8(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            savePicker.SuggestedFileName = "New Document";

            file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                 randAccStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                flextextwrite.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);


                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }
        }

        private async void MenuFlyoutItem_Click_9(object sender, RoutedEventArgs e)
        {

          


                if (file != null)
                {
                    flextextwrite.Document.SaveToStream(TextGetOptions.FormatRtf, randAccStream);
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                 
                }
                else
                    MenuFlyoutItem_Click_8(sender, e);
            
        }

        private void MenuFlyoutItem_Click_10(object sender, RoutedEventArgs e)
        {

        }

        private async void MenuFlyoutItem_Click_11(object sender, RoutedEventArgs e)
        {
            ContentDialog flexdialog = new ContentDialog
            {
                Title = "Help",
                Content = "Я не знаю чем вам помочь.",
                CloseButtonText = "ОК"
            };

            ContentDialogResult result = await flexdialog.ShowAsync();
        }

        private async void MenuFlyoutItem_Click_12(object sender, RoutedEventArgs e)
        {
            ContentDialog flexdialog = new ContentDialog
            {
                Title = "About a program",
                Content = "Тут должна быть информация о прграмме. Все что можно сказать о программе - это текстовый редактор",
                CloseButtonText = "ОК"
            };

            ContentDialogResult result = await flexdialog.ShowAsync();
        }

        private async void Print_Click(object sender, RoutedEventArgs e)
        {
            if (PrintManager.IsSupported())
            {
                try
                {
                    await PrintManager.ShowPrintUIAsync();
                }
                catch { }
            }
        }

        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            var printTask = args.Request.CreatePrintTask("Print", PrintTaskSourceRequrested);
        }
        private void PrintTaskSourceRequrested(PrintTaskSourceRequestedArgs args)
        {
            args.SetSource(printDocSource);
        }
        private void Paginate(object sender, PaginateEventArgs e)
        {
            printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
        }
        private void GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            string textStr = "";
            flextextwrite.Document.GetText(TextGetOptions.FormatRtf, out textStr);
            RichEditBox richTextBlock = new RichEditBox();
            richTextBlock.Document.SetText(TextSetOptions.FormatRtf, textStr);
            richTextBlock.Background = new SolidColorBrush(Windows.UI.Colors.White);
            printDoc.SetPreviewPage(e.PageNumber, richTextBlock);
        }
        private void AddPages(object sender, AddPagesEventArgs e)
        {
            string textStr = "";
            flextextwrite.Document.GetText(TextGetOptions.FormatRtf, out textStr);
            RichEditBox richTextBlock = new RichEditBox();
            richTextBlock.Document.SetText(TextSetOptions.FormatRtf, textStr);
            richTextBlock.Background = new SolidColorBrush(Windows.UI.Colors.White);
            richTextBlock.Padding = new Thickness(20, 20, 20, 20);
            printDoc.AddPage(richTextBlock);
        }

        private async void MenuFlyoutItem_Click_13(object sender, RoutedEventArgs e)
        {
            
            int start = 0, end = 0;
            string text = "";

            ContentDialog flexdialog = new ContentDialog
            {
             Title = "Find",
             Content = new TextBox() { PlaceholderText = "Find"},
             PrimaryButtonText = "find"
            };


            ContentDialogResult result = await flexdialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

                flextextwrite.Document.GetText(TextGetOptions.None, out text);

                start = text.IndexOf((flexdialog.Content as TextBox).Text);

                if(start > -1)
                {
                    end = start + (flexdialog.Content as TextBox).Text.Length;

                    flextextwrite.Focus(FocusState.Pointer);
                    flextextwrite.Document.Selection.SetRange(start, end);

                }

            }
        }

        private async void MenuFlyoutItem_Click_14(object sender, RoutedEventArgs e)
        {
            int start = 0, end = 0;
            string str = "";
            StackPanel Conteiner = new StackPanel();

            Conteiner.Children.Add(new TextBox() { PlaceholderText = "Find" });
            Conteiner.Children.Add(new TextBox() { PlaceholderText = "Replace" });

            ContentDialog flexdialog = new ContentDialog
            {
                Title = "Find",
                Content = Conteiner,
                PrimaryButtonText = "Replace"
            };

         

            ContentDialogResult result = await flexdialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {


                flextextwrite.Document.GetText(TextGetOptions.None, out str);

                flextextwrite.Document.SetText(TextSetOptions.None, str.Replace((Conteiner.Children[0] as TextBox).Text, (Conteiner.Children[1] as TextBox).Text));


            }
        }
    }
}
