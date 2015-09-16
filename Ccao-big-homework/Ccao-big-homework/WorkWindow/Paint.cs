using Ccao_big_homework_core_wpf.BasicGraphics;
using Ccao_big_homework_core_wpf.Draw_Mode;
using System;
using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework
{
    /// <summary>
    /// 绘图相关方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        //画线
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
        //画正方形
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
        //画长方形
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
        //画圆
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
        //画椭圆
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
        //画圆角矩形
        private void AddRoundedRectangle(Point pt1, Point pt2)
        {
            MyRectangle mr = new MyRectangle();
            mr.Width = Math.Abs(pt1.X - pt2.X);
            mr.Height = Math.Abs(pt1.Y - pt2.Y);
            mr.drawmode = new GeometryMode(brush, pen);
            mr.RadiusX = mr.Width / 10;
            mr.RadiusY = mr.Height / 10;
            compositeGraphic.Add(mr, Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
        //画贝塞尔曲线
        private void AddBezier(Point pt1, Point pt2, Point pt3)
        {
            MyBezier mb = new MyBezier(pt1, pt2, pt3);
            mb.drawmode = new GeometryMode(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)), pen);
            compositeGraphic.Add(mb);
            du_refresh();
            canvas1.ReleaseMouseCapture();
        }
    }
}
