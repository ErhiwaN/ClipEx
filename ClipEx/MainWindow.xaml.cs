using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            LoadClipboardImage(iImage);

        }
    }
}
