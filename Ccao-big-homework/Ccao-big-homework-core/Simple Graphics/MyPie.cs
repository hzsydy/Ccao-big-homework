//Du 2015.8;
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 带两条半斤的圆饼。
    /// </summary>
    public class MyPie : MyEllipse
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        public MyPie() : base() { StartAngle = SweepAngle = 0; }
        public MyPie(int height, int width, float startangle, float sweepangle)
            : base(height, width)
        {
            StartAngle = startangle; 
            SweepAngle = sweepangle; 
        }
        public MyPie(int radius, float startangle, float sweepangle)
            : base(radius)
        {
            StartAngle = startangle;
            SweepAngle = sweepangle; 
        }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddPie(left, top, Width, Height, StartAngle, SweepAngle);
            return p;
        }
    }
}
