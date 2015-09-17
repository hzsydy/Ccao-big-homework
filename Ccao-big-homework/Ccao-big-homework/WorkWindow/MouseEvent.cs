using Ccao_big_homework_core_wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ccao_big_homework
{
    /// <summary>
    /// 鼠标事件处理相关方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        #region 变量定义
        private Point startPoint = new Point();
        private Point[] Beizer = new Point [3];
        private int numOfPointInBezier = 0;
        private Shape rubberBand = null;
        Point currentPoint = new Point();
        private bool isDragging = false;
        private bool isDown = false;
        private Line line = null;
        #endregion

        #region 鼠标事件处理
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
                    (rbSelect.IsChecked == true && selectedGraphics.Count == 0) ||
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
            if (isDown && startPoint == currentPoint && rbBezier.IsChecked == false)
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
                rbSelect.IsChecked = true;
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
            else if (rbBezier.IsChecked == true)
            {
                if (numOfPointInBezier < 3)
                {
                    Beizer[numOfPointInBezier].X = currentPoint.X;
                    Beizer[numOfPointInBezier].Y = currentPoint.Y;
                    ++numOfPointInBezier;
                }
                else
                {
                    Beizer[numOfPointInBezier].X = currentPoint.X;
                    Beizer[numOfPointInBezier].Y = currentPoint.Y;
                    AddBezier(Beizer[1], Beizer[2], Beizer[3],Beizer[0]);
                    numOfPointInBezier = 0;
                }
            }
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
        #endregion

    }
}
