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

namespace pz9
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.InkCanvas1.Strokes.Clear();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string imgPath = @"Рабочий стол\file.gif"; 
            MemoryStream ms = new MemoryStream();  
            FileStream fs = new FileStream(imgPath, FileMode.Create); 

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)InkCanvas1.Width, (int)InkCanvas1.Height, 96, 96, PixelFormats.Default);
            rtb.Render(InkCanvas1);

            GifBitmapEncoder gifEnc = new GifBitmapEncoder(); 
            gifEnc.Frames.Add(BitmapFrame.Create(rtb));
            gifEnc.Save(fs);
            fs.Close();
            MessageBox.Show("Файл сохранен, " + imgPath); 
        }
    }
}
