using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ccao_big_homework
{
    /// <summary>
    /// 窗口类中用于加载图片的相关方法 
    /// </summary>
    public partial class WorkWindow:Window
    {
        private void btnOpen_Click(object sender, RoutedEventArgs args)
        {
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
                        if (!(dlg.FileName.ToLower().EndsWith(".bmp") || dlg.FileName.ToLower().EndsWith(".eps") || dlg.FileName.ToLower().EndsWith(".jpg")))
                        {
                            MessageBox.Show("图片格式不符合要求", Title);
                        }
                        else
                        {
                            Uri url = new Uri(dlg.FileName);
                            BitmapImage bmp = new BitmapImage(url);
                            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                            img.Source = bmp;
                            img.Stretch = Stretch.Uniform;
                            canvas1.Children.Add(img);
                            img.Stretch = Stretch.Uniform;
                            file.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }
        }
    }
}
