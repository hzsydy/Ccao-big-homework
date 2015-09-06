using System;
using System.Windows;
using System.Windows.Input;
using System.Drawing;
using Ccao_big_homework_core;
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Windows.Ink;
using System.IO;
using System.Windows.Media.Imaging;

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window, IWindow
    {
        public WorkWindow()
        {
            InitializeComponent();
        }
        //淡入效果
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
            CompositeGraphic paint = new CompositeGraphic();

        }
        public void DrawPath(Pen pen, GraphicsPath path) 
        { 
            
        }
        public void FillPath(Brush brush, GraphicsPath path) 
        {
 
        }
        //窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnNew_Click(object sender, RoutedEventArgs args)
        {
            this.inkCanv.Strokes.Clear();

        }

        //通过浏览窗口打开文件
        private void btnOpen_Click(object sender, RoutedEventArgs args)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "All files (*.*)|*.*";

            if ((bool)dlg.ShowDialog(this))
            {
                this.inkCanv.Strokes.Clear();

                try
                {
                    using (FileStream file = new FileStream(dlg.FileName,
                                                FileMode.Open, FileAccess.Read))
                    {
                        if (!dlg.FileName.ToLower().EndsWith(".isf"))
                        {
                            MessageBox.Show("The requested file is not a Ink Serialized Format file\r\n\r\nplease retry", Title);
                        }
                        else
                        {
                            this.inkCanv.Strokes = new StrokeCollection(file);
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
        //通过浏览窗口保存文件
        private void btnSave_Click(object sender, RoutedEventArgs args)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "Bitmap files (*.bmp)|*.bmp";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    using (FileStream file = new FileStream(dlg.FileName,
                                            FileMode.Create, FileAccess.Write))
                    {
                        if (dlg.FilterIndex == 1)
                        {
                            this.inkCanv.Strokes.Save(file);
                            file.Close();
                        }
                        else
                        {
                            int marg = int.Parse(this.inkCanv.Margin.Left.ToString());
                            RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.inkCanv.ActualWidth - marg,
                                            (int)this.inkCanv.ActualHeight - marg, 0, 0, System.Windows.Media.PixelFormats.Default);
                            rtb.Render(this.inkCanv);
                            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(rtb));
                            encoder.Save(file);
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

        //剪切选中的对象
        private void btnCut_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CutSelection();
        }

        //复制选中的对象
        private void btnCopy_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CopySelection();
        }

        //粘贴复制的对象
        private void btnPaste_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.CanPaste())
                this.inkCanv.Paste();
        }

        //删除选中的对象
        private void btnDelete_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
            {
                foreach (Stroke strk in this.inkCanv.GetSelectedStrokes())
                    this.inkCanv.Strokes.Remove(strk);
            }
        }

        //选中所有对象
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            this.inkCanv.Select(this.inkCanv.Strokes);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.popExit.IsOpen = false;
        }
        private void btnStylusSettings_Click(object sender, RoutedEventArgs e)
        {

            /*StylusSettings dlg = new StylusSettings();
            dlg.Owner = this;
            dlg.DrawingAttributes = this.inkCanv.DefaultDrawingAttributes;
            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                this.inkCanv.DefaultDrawingAttributes = dlg.DrawingAttributes;
            }*/
        }

        private void btnFormat_Click(object sender, RoutedEventArgs e)
        {

            /*StylusSettings dlg = new StylusSettings();
            dlg.Owner = this;

            // Try getting the DrawingAttributes of the first selected stroke.
            StrokeCollection strokes = this.inkCanv.GetSelectedStrokes();

            if (strokes.Count > 0)
                dlg.DrawingAttributes = strokes[0].DrawingAttributes;
            else
                dlg.DrawingAttributes = this.inkCanv.DefaultDrawingAttributes;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                // Set the DrawingAttributes of all the selected strokes.
                foreach (Stroke strk in strokes)
                    strk.DrawingAttributes = dlg.DrawingAttributes;
            }

            */
        }
    }
}
