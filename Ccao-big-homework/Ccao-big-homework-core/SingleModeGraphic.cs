//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 整个graphic采用同一种drawmode的graphic
    /// </summary>
    public abstract class SingleModeGraphic : MyGraphic
    {
        public DrawMode drawmode { get; set; }
        /// <summary>
        /// 获得此图像的graphicspath
        /// </summary>
        /// <returns>graphicspath</returns>
        public abstract GraphicsPath GetGraphicsPath(int left, int top);
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
    }
}
