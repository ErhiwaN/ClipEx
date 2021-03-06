﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices; //Marshal class (in mscorlib.dll)
using System.IO; //MemoryStream class (in mscorlib.dll)
using System.Windows.Media; //ImageSource class (PresentationCore (in PresentationCore.dll))
using System.Windows; //Clipboard class (PresentationCore (w PresentationCore.dll))
using System.Windows.Media.Imaging; //BitmapFrameclass (PresentationCore (w PresentationCore.dll))
using System.Threading; //Thread class

namespace ClipEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Image SwapClipboardImage(Image replacementImage)
        {
            Image returnImage = null;
            if (Clipboard.ContainsImage())
            {
                returnImage.Source = Clipboard.GetImage();
                Clipboard.SetDataObject(replacementImage);
            }
            return returnImage;
        }

        public bool LoadClipboardImage(object iDestination)
        {
            if (Clipboard.ContainsImage())
            {
                Image tempImage = new Image();
                ImageSource bmf = BitmapFrame.Create(Clipboard.GetImage());
                iImage.Source = bmf;
                return true;
            }
            else
            {
                MessageBox.Show("Clipboard does not contain an image", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        }

        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            //LoadClipboardImage(iImage);

            ClipboardCheckContent();

            if (opBitmap.ImageFromClipboardDib() != null)
            {
                iImage.Source = opBitmap.ImageFromClipboardDib();
            }
            else
            {
                MessageBox.Show("Clipboard does not contain any Image", "No Image", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        //thread for data transfering to clipboard
        public void SendToClipboard()
        {
            Thread clipboardThread = new Thread(() => Clipboard.SetText("Test!"));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.Start();
            clipboardThread.Join();
        }

        private void ClipboardCheckContent()
        {
            if (Clipboard.ContainsAudio() == true)
            {
                lblType.Content = "Audio";
            }

            if (Clipboard.ContainsFileDropList() == true)
            {
                lblType.Content = "FileDropList";
            }

            if (Clipboard.ContainsImage() == true)
            {
                lblType.Content = "Image";
            }

            if (Clipboard.ContainsData(DataFormats.Text) == true)
            {
                lblType.Content = "Text";
            }

            if (Clipboard.ContainsData(DataFormats.Rtf) == true)
            {
                lblType.Content = "RTF";
            }

            if (Clipboard.ContainsData(DataFormats.Html) == true)
            {
                lblType.Content = "HTML";
            }

            if (Clipboard.ContainsData(DataFormats.Dib) == true)
            {
                lblType.Content = "Dib";
            }

            if (Clipboard.ContainsData(DataFormats.SymbolicLink) == true)
            {
                lblType.Content = "SymbolicLink";
            }

            if (Clipboard.ContainsData(DataFormats.Tiff) == true)
            {
                lblType.Content = "TIFF";
            }
        }
    }
}
