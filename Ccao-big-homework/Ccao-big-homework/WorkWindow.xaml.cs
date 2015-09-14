using System;
using System.Windows;
using System.Windows.Input;
using Ccao_big_homework_core_wpf;
using Ccao_big_homework_core_wpf.BasicGraphics;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;
using Ccao_big_homework_core_wpf.Draw_Mode;
using System.Windows.Threading;

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window
    {
        public static Color color = Color.FromArgb(255, 0, 0, 0);
        public static Brush brush = new SolidColorBrush(color);
        public static Pen pen = new Pen(brush, 2.0f);
        private CompositeGraphic compositeGraphic = new CompositeGraphic();
        private DrawingUIElement du = new DrawingUIElement();
        private List<CompositeGraphic> selectedGraphics = new List<CompositeGraphic>();
        private List<CompositeGraphic> clonedGraphics = new List<CompositeGraphic>();
        private Point startPoint = new Point();
        private Shape rubberBand = null;
        Point currentPoint = new Point();
        private bool isDragging = false;
        private bool isDown = false;
        private Line line = null;
        private DispatcherTimer timer1 = new DispatcherTimer();

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
            compositeGraphic.Width = canvas1.Width;
            compositeGraphic.Height = canvas1.Height;
            canvas1.Children.Add(du);
            selected();
        }
        //窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!canvas1.IsMouseCaptured)
                this.DragMove();
        }
        //鼠标左键落下事件
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!canvas1.IsMouseCaptured)
            {
                startPoint = e.GetPosition(canvas1);
                isDown = true;
                canvas1.CaptureMouse();
                if (rbSelect.IsChecked == true)
                {
                    isDown = true;
                    e.Handled = true;
                }
            }
        }
        //鼠标移动事件
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (canvas1.IsMouseCaptured)
            {
                if (rbLine.IsChecked == true || (rbSelect.IsChecked == true && selectedGraphics.Count > 0))
                {
                    if (line == null)
                    {
                        line = new Line();
                        line.Stroke = Brushes.LightCoral;
                        line.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });
                        canvas1.Children.Add(line);
                    }
                    currentPoint = e.GetPosition(canvas1);
                    line.X1 = startPoint.X;
                    line.Y1 = startPoint.Y;
                    line.X2 = currentPoint.X;
                    line.Y2 = currentPoint.Y;
                    return;
                }
                currentPoint = e.GetPosition(canvas1);
                if (rubberBand == null)
                {
                    rubberBand = new Rectangle();
                    rubberBand.Stroke = Brushes.LightCoral;
                    rubberBand.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });
                    if (rbSquare.IsChecked == true ||
                    rbRectangle.IsChecked == true ||
                    rbCircle.IsChecked == true ||
                    rbEllipse.IsChecked == true || 
                    (rbSelect.IsChecked == true && selectedGraphics.Count == 0)||
                    rbRoundedRectangle.IsChecked == true)
                    {
                        canvas1.Children.Add(rubberBand);
                    }
                }
                double width = Math.Abs(
                startPoint.X - currentPoint.X);
                double height = Math.Abs(
                startPoint.Y - currentPoint.Y);
                double left = Math.Min(
                startPoint.X, currentPoint.X);
                double top = Math.Min(
                startPoint.Y, currentPoint.Y);
                rubberBand.Width = width;
                rubberBand.Height = height;
                Canvas.SetLeft(rubberBand, left);
                Canvas.SetTop(rubberBand, top);
                if (rbSelect.IsChecked == true && selectedGraphics.Count > 0)
                {
                    if (isDown)
                    {
                        if (!isDragging
                            && (Math.Abs(currentPoint.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance)
                            && (Math.Abs(currentPoint.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance))
                            isDragging = true;
                    }
                }
            }
        }

        //鼠标抬起事件处理
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPoint = e.GetPosition(canvas1);
            if (isDown && startPoint == currentPoint)
            {
                if (selectedGraphics != null)
                {
                    foreach (CompositeGraphic mgg in selectedGraphics)
                    {
                        mgg.Move(currentPoint.X - startPoint.X, currentPoint.Y - startPoint.Y);
                        mgg.isVisible = true;
                    }
                    selectedGraphics.Clear();
                }
                CompositeGraphic mg = compositeGraphic.SelectPoint(e.GetPosition(canvas1));
                if (mg != null)
                selectedGraphics.Add(mg);
                canvas1.ReleaseMouseCapture();
                isDown = false;
                e.Handled = true;
                return;
            }
            if (rbLine.IsChecked == true)
                AddLine(startPoint, currentPoint);
            else if (rbSquare.IsChecked == true)
                AddSquare(startPoint, currentPoint);
            else if (rbRectangle.IsChecked == true)
                AddRectangle(startPoint, currentPoint);
            else if (rbCircle.IsChecked == true)
                AddCircle(startPoint, currentPoint);
            else if (rbEllipse.IsChecked == true)
                AddEllipse(startPoint, currentPoint);
            else if (rbRoundedRectangle.IsChecked == true)
                AddRoundedRectangle(startPoint, currentPoint);
            if (rubberBand != null)
            {
                canvas1.Children.Remove(rubberBand);
                rubberBand = null;
                canvas1.ReleaseMouseCapture();
            }
            if (rbSelect.IsChecked == true)
            {
                if (isDown && startPoint == currentPoint)
                {
                    if (selectedGraphics != null)
                    {
                        foreach (CompositeGraphic mgg in selectedGraphics)
                        {
                            mgg.Move(currentPoint.X - startPoint.X, currentPoint.Y - startPoint.Y);
                            mgg.isVisible = true;
                        }
                        selectedGraphics.Clear();
                    }
                    CompositeGraphic mg = compositeGraphic.SelectPoint(e.GetPosition(canvas1));
                    if (mg != null)
                    selectedGraphics.Add(mg);
                    canvas1.ReleaseMouseCapture();
                    isDown = false;
                    e.Handled = true;
                }
                else if (isDown && selectedGraphics.Count == 0)
                {
                    CompositeGraphic mg = compositeGraphic.SelectRect(startPoint, e.GetPosition(canvas1));
                    if (mg != null)
                    {
                        selectedGraphics.Add(mg);
                        canvas1.ReleaseMouseCapture();
                        e.Handled = true;
                    }
                    canvas1.ReleaseMouseCapture();
                    isDragging = false;
                    isDown = false;
                    e.Handled = true;
                }
                else if (isDown && selectedGraphics.Count > 0 && startPoint != currentPoint)
                {
                    foreach (CompositeGraphic mg in selectedGraphics)
                    {
                        mg.Move(currentPoint.X - startPoint.X, currentPoint.Y - startPoint.Y);
                        mg.isVisible = true;
                    }
                    selectedGraphics.Clear();
                    if (line != null)
                    {
                        canvas1.Children.Remove(line);
                        line = null;
                    }
                    
                    canvas1.ReleaseMouseCapture();
                    isDragging = false;
                    isDown = false;
                    e.Handled = true;
                }
                
            }
            canvas1.ReleaseMouseCapture();
        }

        

        private void du_refresh()
        {
            du.drawing = compositeGraphic.Draw();
            du.InvalidateVisual();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (MyGraphic mg in selectedGraphics)
            {
                mg.isVisible = !mg.isVisible;
            }
            du_refresh();
        }

        private void unselected()
        {
            timer1.Stop();
        }

        private void selected()
        {
            timer1.Interval = TimeSpan.FromSeconds(0.3);
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }      
        //剪切选中的对象
        private void btnCut_Click(object sender, RoutedEventArgs args)
        {
            if (selectedGraphics != null)
            {
                clonedGraphics.Clear();
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.isVisible = true;
                    clonedGraphics.Add((CompositeGraphic)cg.Clone());
                    cg.Dispose();
                }
                selectedGraphics.Clear();
            }
        }
        //复制选中的对象
        private void btnCopy_Click(object sender, RoutedEventArgs args)
        {
            if (selectedGraphics != null)
            {
                clonedGraphics.Clear();
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.isVisible = true;
                    clonedGraphics.Add((CompositeGraphic)cg.Clone());
                }
                selectedGraphics.Clear();
            }
        }
        //粘贴复制的对象
        private void btnPaste_Click(object sender, RoutedEventArgs args)
        {
            foreach (CompositeGraphic cg in clonedGraphics)
            {
                compositeGraphic.Add(cg, 10, 10);
                selectedGraphics.Add(cg);
            }
            clonedGraphics.Clear();
            du_refresh();
        }
        //删除选中的对象
        private void btnDelete_Click(object sender, RoutedEventArgs args)
        {
            foreach (MyGraphic mg in selectedGraphics)
            {
                if (mg != null)
                mg.Dispose();
            }
            if (selectedGraphics!=null)
                selectedGraphics.Clear();
            du_refresh();
        }
        //选中所有对象
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            CompositeGraphic mg = compositeGraphic.SelectRect(new Point(0, 0), new Point (canvas1.Width, canvas1.Height));
            if (mg != null)
                selectedGraphics.Add(mg);
            canvas1.ReleaseMouseCapture();
        }        

        private void btnStylusSettings_Click(object sender, RoutedEventArgs e)
        {
            StyleSettingWindow ssw = new StyleSettingWindow();
            ssw.Show();
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

        private void KeyPress(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.)
        }

    }
}
