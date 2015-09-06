//Du 2015.8;
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 弧线。
    /// </summary>
    public sealed class MyArc : SingleModeGraphic
    {
        public override bool isFillable() { return false; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        /// <summary>
        /// 注意这只是一个方便你设置的只读变量
        /// </summary>
        public int Radius
        {
            set
            {
                Radius = value;
                Height = Width = value * 2;
            }
        }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddArc(left, top, Width, Height, StartAngle, SweepAngle);
            return p;
        }
        public MyArc()
            : base()
        {
            Height = 0;
            Width = 0;
            StartAngle = 0;
            SweepAngle = 0;
        }
        public MyArc(int height, int width, float startangle, float sweepangle) 
            : base()
        {
            Height = height;
            Width = width;
            StartAngle = startangle; 
            SweepAngle = sweepangle; 
        }
        public MyArc(int radius, float startangle, float sweepangle)
            : base()
        {
            Radius = radius;
            Height = 2 * radius;
            Width = 2 * radius;
            StartAngle = startangle;
            SweepAngle = sweepangle; 
        }
    }
}
