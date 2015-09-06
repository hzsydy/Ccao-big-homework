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
    public sealed class MyEllipse : SingleModeGraphic
    {
        public override bool isFillable() { return true; }
        public int Height { get; set; }
        public int Width { get; set; }
        /// <summary>
        /// 注意这只是一个方便你设置的只读变量，事实上它还是一个椭圆
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
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddEllipse(r);
            return p;
        }
        public MyEllipse() 
        { 
            Height = 0;
            Width = 0;
        }
        public MyEllipse(int radius) 
        { 
            Radius = radius; 
            Height = 2 * radius;
            Width = 2 * radius;
        }
        public MyEllipse(int height, int width) 
        { 
            Height = height;
            Width = width;
        }
    }
}
