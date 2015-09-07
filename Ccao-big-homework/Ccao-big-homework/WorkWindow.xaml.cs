using System;
using System.Windows;
using System.Windows.Input;
using Ccao_big_homework_core;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window
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

        //窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnNew_Click(object sender, RoutedEventArgs args)
        {

            canvas1.Children.Clear();
        }

        

        //通过浏览窗口打开文件
        
        

        //剪切选中的对象
        private void btnCut_Click(object sender, RoutedEventArgs args)
        {
           /* if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CutSelection();*/
        }

        //复制选中的对象
        private void btnCopy_Click(object sender, RoutedEventArgs args)
        {
           /* if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CopySelection();*/
        }

        //粘贴复制的对象
        private void btnPaste_Click(object sender, RoutedEventArgs args)
        {
           /* if (this.inkCanv.CanPaste())
                this.inkCanv.Paste();*/
        }

        //删除选中的对象
        private void btnDelete_Click(object sender, RoutedEventArgs args)
        {
           /* if (this.inkCanv.GetSelectedStrokes().Count > 0)
            {
                foreach (Stroke strk in this.inkCanv.GetSelectedStrokes())
                    this.inkCanv.Strokes.Remove(strk);
            }*/
        }

        //选中所有对象
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            //this.inkCanv.Select(this.inkCanv.Strokes);
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

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            FrameworkElement overflowGrid = (FrameworkElement)toolBar.Template.FindName("OverflowGrid", toolBar);
            if(overflowGrid != null)
                overflowGrid.Visibility = Visibility.Collapsed;
            FrameworkElement mainPanelBorder = (FrameworkElement)toolBar.Template.FindName("MainPanelBorder", toolBar);
            if(mainPanelBorder != null)
            mainPanelBorder.Margin = new Thickness(0);

        }
    }
}
