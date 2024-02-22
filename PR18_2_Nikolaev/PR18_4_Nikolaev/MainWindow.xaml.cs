using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR18_4_Nikolaev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas.Strokes.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string imgPath = @"file.gif";
            FileStream fs = new FileStream(imgPath,FileMode.Create);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvas.Width, (int)inkCanvas.Height, 96, 96, PixelFormats.Default);
            rtb.Render(inkCanvas);

            GifBitmapEncoder gifEnc = new GifBitmapEncoder();
            gifEnc.Frames.Add(BitmapFrame.Create(rtb));
            gifEnc.Save(fs);
            MessageBox.Show($"Файл сохранен {imgPath}");


        }
    }
}
