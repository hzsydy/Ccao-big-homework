//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 圆。
    /// radius表示半径
    /// </summary>
    public sealed class MyCircle : MyRectangle
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
        public override void Draw(MyWindow w, int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddEllipse(r);
            Fill(w, p);
        }
        public MyCircle() : base() { }
        public MyCircle(int height, int width) : base(height, width) { }
    }
}
