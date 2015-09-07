using System;
using System.Windows;
using System.Windows.Input;
using Ccao_big_homework_core;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window
    {
        private Line line = null;

        private List<Path> paths = new List<Path>();
        private Point startPoint = new Point();
        private Shape rubberBand = null;
        Point currentPoint = new Point();
        private bool isDragging = false;
        private bool isDown = false;
        private Path originalElement = new Path();
        private Path movingElement = new Path();
        private Path path1 = new Path();
        private Path path2 = new Path();
        private SolidColorBrush fillColor =
        new SolidColorBrush();
        private SolidColorBrush borderColor =
        new SolidColorBrush();
        private SolidColorBrush selectFillColor =
        new SolidColorBrush();
        private SolidColorBrush selectBorderColor = new SolidColorBrush();


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

        
        /*private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!canvas1.IsMouseCaptured)
            {
                startPoint = e.GetPosition(canvas1);
                canvas1.CaptureMouse();
                if (rbCombine.IsChecked == true)
                {
                    SetCombineShapes(e);
                }
                else if (rbSelect.IsChecked == true)
                {
                    if (canvas1 == e.Source)
                        return;
                    isDown = true;
                    originalElement = (Path)e.Source;
                    e.Handled = true;
                }
                else if (rbDelete.IsChecked == true)
                {
                    originalElement = (Path)e.Source;
                    DeleteShape(originalElement);
                }
            }
        }*/

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

        //工具条隐藏尾部小箭头的方法
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
