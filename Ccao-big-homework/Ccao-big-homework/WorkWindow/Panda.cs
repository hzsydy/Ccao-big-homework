using Ccao_big_homework_core_wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Ccao_big_homework_emgucv;
using System.Windows.Media;

namespace Ccao_big_homework
{
    public partial class WorkWindow : Window
    {
        private void Panda(object sender, RoutedEventArgs e)
        {
            BitmapImage face = new BitmapImage();
            canvas1.Children.Clear();
            canvas1.InvalidateVisual();
            du = new DrawingUIElement();
            compositeGraphic.Clear();
            canvas1.Children.Add(du);
            du_refresh();
            isSaved = false;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "所有格式 (*.*)|*.*|矢量图 (*.eps)|*.eps|位图 (*.bmp)|*.bmp";
            if ((bool)dlg.ShowDialog(this))
            {
                canvas1.Children.Clear();
                try
                {
                    using (FileStream file = new FileStream(dlg.FileName,
                                                FileMode.Open, FileAccess.Read))
                    {
                        if (!(dlg.FileName.ToLower().EndsWith(".png") || dlg.FileName.ToLower().EndsWith(".bmp") || dlg.FileName.ToLower().EndsWith(".eps") || dlg.FileName.ToLower().EndsWith(".jpg")))
                        {
                            MessageBox.Show("图片格式不符合要求", Title);
                        }
                        else
                        {
                            Uri url = new Uri(dlg.FileName);
                            face = new BitmapImage(url);
                            file.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }

            
            Uri uri233=new Uri("C:\\git_ssh\\Ccao-big-homework\\Ccao-big-homework\\image\\panda.jpg");
            BitmapImage pd = new BitmapImage(uri233);
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = pd;
            img.Height = canvas1.Height;
            img.Width = canvas1.Width;
            img.Stretch = Stretch.Uniform;
            canvas1.Children.Add(img);
            canvas1.Children.Remove(du);
            canvas1.Children.Add(du);
            Panda p = new Panda();
            BitmapSource bs = BitmapSource_Image.Image2BitmapSource(
                p.getPanda(
                BitmapSource_Image.BitmapSource2Image(face),
                BitmapSource_Image.BitmapSource2Image(pd),
                0,0,100,100
                )
                
                );
            img.Source = bs;
            img.InvalidateVisual();

        }
    }
}
