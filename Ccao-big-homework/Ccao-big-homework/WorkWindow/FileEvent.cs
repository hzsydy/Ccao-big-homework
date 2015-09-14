using Ccao_big_homework_core_wpf;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Ccao_big_homework
{
    /// <summary>
    /// 文件读写相关事件
    /// </summary>

    public partial class WorkWindow : Window
    {
        #region 变量定义
        private bool isSaved = false;
        private bool C = false;
        DispatcherTimer timer = new DispatcherTimer();
        #endregion

        #region 新建画布方法
        private void New()
        {
            if (isSaved == false)
            {
                if (MessageBox.Show("尚未保存,真的要新建画板吗?", "新建确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    canvas1.Children.Clear();
                    canvas1.InvalidateVisual();
                    du = new DrawingUIElement();
                    compositeGraphic.Clear();
                    canvas1.Children.Add(du);
                    du_refresh();
                    isSaved = false;
                }
            }
            else
            {
                canvas1.Children.Clear();
                canvas1.InvalidateVisual();
                du = new DrawingUIElement();
                compositeGraphic.Clear();
                canvas1.Children.Add(du);
                du_refresh();
                isSaved = false;
            }
        }
        #endregion

        #region 打开文件方法
        private void Open()
        {
            if (MessageBox.Show("载入图片将会清空当前内容,真的要载入图片吗?", "警告", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
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
                                BitmapImage bmp = new BitmapImage(url);
                                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                                img.Source = bmp;
                                img.Height = canvas1.Height;
                                img.Width = canvas1.Width;
                                img.Stretch = Stretch.Uniform;
                                canvas1.Children.Add(img);
                                canvas1.Children.Remove(du);
                                canvas1.Children.Add(du);
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
        #endregion
        
        #region 保存方法
        void Save()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "位图 (*.bmp)|*.bmp|矢量图 (*.eps)|*.eps|所有格式 (*.*)|*.*";
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
        private void SaveToImage(FrameworkElement ui, string fileName)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)ui.Width, (int)ui.Height, 96d, 96d, PixelFormats.Pbgra32);
            bmp.Render(ui);
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        } 
        #endregion

        #region 退出方法
        private void Exit()
        {
            if (isSaved == false)
            {
                if (MessageBox.Show("尚未保存,真的要退出吗?", "退出确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
                    this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
                    C = true;
                    this.Close();
                }
            }
            else
            {
                DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
                this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
                C = true;
                this.Close();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        //关闭窗口时,若是彻底退出,则通过计时器载入淡出动画
        private void On_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (C == true)
            {
                e.Cancel = true;
                timer.Interval = TimeSpan.FromSeconds(0.5);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }
        }
        #endregion
    }
}
