//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 矩形。
    /// height和width分别代表矩形的高和宽。
    /// DrawPen
    /// </summary>
    public class MyRectangle : MyGraphic
    {
        public DrawMode drawmode { get; set; }
        public override void Draw(MyWindow w, int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            Rectangle r = new Rectangle(left, top, Width, Height);
            p.AddRectangle(r);
            Fill(w, p);
        }
        /// <summary>
        /// 向屏幕中画出内容
        /// </summary>
        /// <param name="w">window</param>
        /// <param name="p">graphicspath</param>
        protected virtual void Fill(MyWindow w, GraphicsPath p)
        {
            if (drawmode.fillmode == DrawMode.MyFillMode.Empty)
            {
                w.DrawPath(drawmode.pen, p);
            }
            else if (drawmode.fillmode == DrawMode.MyFillMode.Filled)
            {
                w.FillPath(drawmode.brush, p);
            }
            else
            {
                ;
            }

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
