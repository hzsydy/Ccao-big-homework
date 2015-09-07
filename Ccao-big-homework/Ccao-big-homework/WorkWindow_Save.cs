using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ccao_big_homework
{
    /// <summary>
    /// 窗口类中用于保存图片的相关方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        //保存方法
         private void SaveToImage(FrameworkElement ui, string fileName)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)ui.Width, (int)ui.Height, 96d, 96d,PixelFormats.Pbgra32);
            bmp.Render(ui);
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        } 
        //通过浏览窗口保存文件
        private void btnSave_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "矢量图 (*.eps)|*.eps|位图 (*.bmp)|*.bmp|所有格式 (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.RestoreDirectory = true;
                if ((bool)dlg.ShowDialog(this))
                {
                    SaveToImage(canvas1, dlg.FileName.ToString());
                    isSaved = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Title);
            }
        }
    }
}
