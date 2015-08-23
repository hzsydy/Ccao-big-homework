//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 矩形。
    /// height和width分别代表矩形的高和宽。
    /// </summary>
    public class MyRectangle : SingleModeGraphic
    {
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddRectangle(r);
            return p;
        }
        public override void Draw(MyWindow w, int left, int top)
        {
            GraphicsPath p = GetGraphicsPath(left, top);
            Fill(w, p);
        }
        public MyRectangle()
        {
            Height = Width = 0;
        }
        public MyRectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
