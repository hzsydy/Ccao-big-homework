using Ccao_big_homework_core_wpf.BasicGraphics;
using Ccao_big_homework_core_wpf.Draw_Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ccao_big_homework
{
    public partial class WorkWindow : Window
    {
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
    }
}
