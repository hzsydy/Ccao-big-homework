//Du 2015.8;
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 带两条半斤的圆饼。
    /// </summary>
    public sealed class MyPie : SingleModeGraphic
    {
        public override bool isFillable() { return true; }
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
        public MyPie() 
        {
            Height = 0;
            Width = 0;
            StartAngle = 0;
            SweepAngle = 0;
        }
        public MyPie(int height, int width, float startangle, float sweepangle)
        {
            Height = height;
            Width = width;
            StartAngle = startangle; 
            SweepAngle = sweepangle; 
        }
        public MyPie(int radius, float startangle, float sweepangle)
        {
            Radius = radius;
            Height = 2 * radius;
            Width = 2 * radius;
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
