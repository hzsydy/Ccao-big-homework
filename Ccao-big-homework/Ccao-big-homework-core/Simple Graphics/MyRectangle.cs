//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 矩形。
    /// height和width分别代表矩形的高和宽。
    /// rectangle类也是所有闭合图形的基类（所有的闭合图形都存在一个矩形作为其border）
    /// 因此有fill方法
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
        /// <summary>
        /// 视fillmode的不同对图像进行填充
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
