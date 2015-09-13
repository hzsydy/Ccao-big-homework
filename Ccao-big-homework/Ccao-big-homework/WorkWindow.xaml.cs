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
        private List<Path> paths = new List<Path>();
        private List<MyGraphic> selectedGraphics = new List<MyGraphic>();
        private List<MyGraphic> movingGraphics = new List<MyGraphic>();
        private Point startPoint = new Point();
        private Shape rubberBand = null;
        Point currentPoint = new Point();
        private bool isDragging = false;
        private bool isDown = false;
        private Path originalElement = new Path();
        private Path movingElement = new Path();
        private Path path1 = new Path();
        private Path path2 = new Path();
        private Line line = null;
        private SolidColorBrush fillColor =
        new SolidColorBrush();
        private SolidColorBrush borderColor =
        new SolidColorBrush();
        private SolidColorBrush selectFillColor =
        new SolidColorBrush();
        private SolidColorBrush selectBorderColor = new SolidColorBrush();
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
            CompositeGraphic paint = new CompositeGraphic();
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
                canvas1.CaptureMouse();
                if (rbCombine.IsChecked == true)
                {
                    //SetCombineShapes(e);
                }
                else if (rbSelect.IsChecked == true)
                {
                    isDown = true;
                    e.Handled = true;
                }
                /*else if (rbDelete.IsChecked == true)
                {
                    originalElement = (Path)e.Source;
                    DeleteShape(originalElement);
                }*/
            }
        }
        //鼠标移动事件
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (canvas1.IsMouseCaptured)
            {
                if (rbLine.IsChecked == true)
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
                    rbEllipse.IsChecked == true || rbSelect.IsChecked == true)
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
                            DragStarting();
                        if (isDragging)
                            DragMoving();
                    }
                }
            }
        }

        private void DragStarting()
        {
            isDragging = true;
            movingGraphics.Clear();
            foreach (MyGraphic mg in selectedGraphics)
            {

            }
            /*movingElement = new Path();
            movingElement.Data = originalElement.Data;
            movingElement.Fill = selectFillColor;
            movingElement.Stroke = selectBorderColor;
            canvas1.Children.Add(movingElement);*/
        }

        private void DragMoving()
        {
            currentPoint = Mouse.GetPosition(canvas1);
            double xx = currentPoint.X - startPoint.Y;
            movingGraphics.Clear();
            TranslateTransform tt = new TranslateTransform();
            tt.X = currentPoint.X - startPoint.X;
            tt.Y = currentPoint.Y - startPoint.Y;
            movingElement.RenderTransform = tt;
        }

        private void DragFinishing(bool cancel)
        {
            Mouse.Capture(null);
            if (isDragging)
            {
                if (!cancel)
                {
                    currentPoint = Mouse.GetPosition(canvas1);
                    TranslateTransform tt0 = new TranslateTransform();
                    TranslateTransform tt = new TranslateTransform();
                    tt.X = currentPoint.X - startPoint.X;
                    tt.Y = currentPoint.Y - startPoint.Y;
                    Geometry geometry =
                    (RectangleGeometry)new RectangleGeometry();
                    string s = originalElement.Data.ToString();
                    if (s == "System.Windows.Media.EllipseGeometry")
                        geometry = (EllipseGeometry)originalElement.Data;
                    else if (s == "System.Windows.Media.RectangleGeometry")
                        geometry = (RectangleGeometry)originalElement.Data;
                    else if (s == "System.Windows.Media.CombinedGeometry")
                        geometry = (CombinedGeometry)originalElement.Data;
                    if (geometry.Transform.ToString() != "Identity")
                    {
                        tt0 = (TranslateTransform)geometry.Transform;
                        tt.X += tt0.X;
                        tt.Y += tt0.Y;
                    }
                    geometry.Transform = tt;
                    canvas1.Children.Remove(originalElement);
                    originalElement = new Path();
                    originalElement.Fill = fillColor;
                    originalElement.Stroke = borderColor;
                    originalElement.Data = geometry;
                    canvas1.Children.Add(originalElement);
                }
                canvas1.Children.Remove(movingElement);
                movingElement = null;
            }
            isDragging = false;
            isDown = false;
        }
        //鼠标抬起事件处理
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
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

                    MyGraphic mg = compositeGraphic.SelectPoint(e.GetPosition(canvas1));
                    if (!selectedGraphics.Contains(mg))
                        selectedGraphics.Add(mg);
                    else
                    {
                        mg.isVisible = true;
                        selectedGraphics.Remove(mg);
                    }
                    DragFinishing(false);
                    canvas1.ReleaseMouseCapture();
                    e.Handled = true;
                }
                else if (isDown && selectedGraphics.Count == 0)
                {
                    List<MyGraphic> mg = compositeGraphic.SelectRect(startPoint, e.GetPosition(canvas1));
                    if (mg != null)
                    {
                        foreach (MyGraphic mgg in mg)
                        {
                            selectedGraphics.Add(mgg);
                        }
                        mg.Clear();
                        DragFinishing(false);
                    }
                    canvas1.ReleaseMouseCapture();
                    e.Handled = true;
                }
                else if (isDown && ( (Math.Abs(currentPoint.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance)
                            || (Math.Abs(currentPoint.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                {
                    canvas1.ReleaseMouseCapture();
                    DragFinishing(false);
                    e.Handled = true;
                }
                
            }
            
        }

        private void AddLine(Point pt1, Point pt2)
        {
            if (line != null)
            {
                canvas1.Children.Remove(line);
                line = null;
            }
            MyLine line1 = new MyLine();
            line1.Left1 = pt1.X;
            line1.Top1 = pt1.Y;
            line1.Left2 = pt2.X;
            line1.Top2 = pt2.Y;
            line1.drawmode = new GeometryMode(brush, pen);
            compositeGraphic.Add(line1, 0, 0);
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
        private void AddSquare(Point pt1, Point pt2)
        {
            MyRectangle mr = new MyRectangle();
            mr.Width = Math.Abs(pt1.X - pt2.X);
            mr.Height = Math.Abs(pt1.Y - pt2.Y);
            if (mr.Width > mr.Height) mr.Width = mr.Height;
            else mr.Height = mr.Width;
            mr.drawmode = new GeometryMode(brush, pen);
            compositeGraphic.Add(mr, Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
        private void AddRectangle(Point pt1, Point pt2)
        {
            MyRectangle mr = new MyRectangle();
            mr.Width = Math.Abs(pt1.X - pt2.X);
            mr.Height = Math.Abs(pt1.Y - pt2.Y);
            mr.drawmode = new GeometryMode(brush, pen);
            compositeGraphic.Add(mr, Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
        private void AddCircle(Point pt1, Point pt2)
        {
            MyEllipse mr = new MyEllipse();
            mr.Width = Math.Abs(pt1.X - pt2.X);
            mr.Height = Math.Abs(pt1.Y - pt2.Y);
            if (mr.Width > mr.Height) mr.Width = mr.Height;
            else mr.Height = mr.Width;
            mr.drawmode = new GeometryMode(brush, pen);
            compositeGraphic.Add(mr, Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
        private void AddEllipse(Point pt1, Point pt2)
        {
            MyEllipse mr = new MyEllipse();
            mr.Width = Math.Abs(pt1.X - pt2.X);
            mr.Height = Math.Abs(pt1.Y - pt2.Y);
            mr.drawmode = new GeometryMode(brush, pen);
            compositeGraphic.Add(mr, Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            du_refresh();
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
            timer1.Interval = TimeSpan.FromSeconds(0.1);
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
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
            foreach (MyGraphic mg in selectedGraphics)
            {
                mg.Dispose();
            }
            selectedGraphics.Clear();
            du_refresh();
        }
        //选中所有对象
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            //this.inkCanv.Select(this.inkCanv.Strokes);
        }        


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.popExit.IsOpen = false;
        }
        private void btnStylusSettings_Click(object sender, RoutedEventArgs e)
        {
            StyleSettingWindow ssw = new StyleSettingWindow();
            ssw.Show();
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
