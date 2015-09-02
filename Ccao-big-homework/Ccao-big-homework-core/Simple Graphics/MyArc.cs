//Du 2015.8;
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 弧线。
    /// </summary>
    public class MyArc : MyPie
    {
        public override bool fillable() { return false; }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddArc(left, top, Width, Height, StartAngle, SweepAngle);
            return p;
        }
        public MyArc(int height, int width, float startangle, float sweepangle)
            : base(height, width, startangle, sweepangle) { }
        public MyArc(int radius, float startangle, float sweepangle)
            : base(radius, startangle, sweepangle) { }
    }
}
