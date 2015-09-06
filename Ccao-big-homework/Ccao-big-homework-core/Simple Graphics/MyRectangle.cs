//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 矩形。
    /// </summary>
    public sealed class MyRectangle : SingleModeGraphic
    {
        public override bool isFillable() { return true; }
        public int Height { get; set; }
        public int Width { get; set; }
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddRectangle(r);
            return p;
        }
        public override void Draw(IWindow w, int left, int top)
        {
            GraphicsPath p = GetGraphicsPath(left, top);
            Fill(w, p);
        }
        public MyRectangle()
            : base()
        {
            Height = Width = 0;
        }
        public MyRectangle(int height, int width)
            : base()
        {
            Height = height;
            Width = width;
        }
    }
}
