//Du 2015.8
//All rights reserved.

using System;
using System.Drawing;
namespace Ccao_big_homework_core
{
    public abstract class MyWindow
    {
        /// <summary>
        /// 此处采用了bridge模式，将抽象部分Ccao_big_homework_core与实现部分Ccao_big_homework分离；
        /// 由此我们进行了分工，由我负责抽象，而邵键准同学负责实现；
        /// 采用bridge模式使得我们可以各自独立完成自己的部分而没有耦合。
        /// 以下是接口。所有的函数名都和system.drawing中的一样，这是为了方便邵键准同学的实现。
        /// </summary>
        public abstract void DrawRect(Pen pen, int left, int top, int width, int height);
        public abstract void DrawCircle(Pen pen, int left, int top, int radius);
        public abstract void DrawLine(Pen pen, int left1, int top1, int left2, int top2);
        public abstract void DrawClosedCurve(Pen pen, Point[] points);
        public abstract void DrawEllipse(Pen pen, int left, int top, int width, int height);
        public abstract void DrawString(String str, Font font, Brush brush, int left, int top);
        public abstract void DrawPie(Pen pen, int left, int top, int width, int height, int startAngle, int sweepAngle);
        public abstract void FillRect(Brush brush, int left, int top, int width, int height);
        public abstract void FillPolygon(Brush brush, Point[] points);
        public abstract void FillPie(Brush brush, int left, int top, int width, int height, int startAngle, int sweepAngle);
        public abstract void FillEllipse(Brush brush, int left, int top, int width, int height);
        public abstract void FillCircle(Brush brush, int left, int top, int radius);
        public abstract void FillClosedCurve(Brush brush, Point[] points);
    }
}
