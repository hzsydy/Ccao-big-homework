//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 椭圆。
    /// height和width分别表示纵向和横向的轴长。
    /// </summary>
    public class MyEllipse : MyRectangle
    {
        public int Radius
        {
            get
            {
                return Radius;
            }
            set
            {
                Radius = value;
                Height = Width = value * 2;
            }
        }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddEllipse(r);
            return p;
        }
        public MyEllipse() : base() { }
        public MyEllipse(int radius) : base(radius * 2, radius * 2) { }
        public MyEllipse(int height, int width) : base(height, width) { }
    }
}
