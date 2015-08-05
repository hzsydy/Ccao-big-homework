//Du 2015.8;
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 弧线。
    /// </summary>
    public class MyArc : SingleModeGraphic
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddArc(left, top, Width, Height, StartAngle, SweepAngle);
            return p;
        }
        public override void Draw(MyWindow w, int left, int top)
        {
            GraphicsPath p = GetGraphicsPath(left, top);
            w.DrawPath(drawmode.pen, p);
        }
        public MyArc(int height, int width, float startangle, float sweepangle)
        {
            Height = height;
            Width = width;
            StartAngle = startangle; 
            SweepAngle = sweepangle; 
        }
    }
}
