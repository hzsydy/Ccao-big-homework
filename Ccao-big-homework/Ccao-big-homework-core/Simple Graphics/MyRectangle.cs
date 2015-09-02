//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 矩形。
    /// height和width分别代表矩形的高和宽。
    /// 许多图形都继承自矩形：注意，这不是说他们is-a矩形，
    /// 而是说他们is-implemented-in-terms-of矩形。Rectangle后面那条继承树很长，同理。
    /// </summary>
    public class MyRectangle : SingleModeGraphic
    {
        public override bool fillable() { return true; }
        public int Height { get; set; }
        public int Width { get; set; }
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
