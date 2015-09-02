//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;
using Ccao_big_homework_core.Draw_Mode;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 整个graphic采用同一种drawmode的graphic。
    /// </summary>
    public abstract class SingleModeGraphic : MyGraphic
    {
        public static readonly PenMode DefaultMode = new PenMode(new Pen(Color.Black, 2.0f));
        /// <summary>
        /// 来确定一个图形能不能被fill。对于Line这种的来说，fill没有任何意义
        /// </summary>
        public abstract bool fillable();
        /// <summary>
        /// 设置填充模式
        /// </summary>
        public DrawMode drawmode { get; set; }
        /// <summary>
        /// 获得此图像的graphicspath
        /// </summary>
        /// <returns>graphicspath</returns>
        public abstract GraphicsPath GetGraphicsPath(int left, int top);
        /// <summary>
        /// 对图像进行填充
        /// </summary>
        /// <param name="w">window</param>
        /// <param name="p">graphicspath</param>
        public virtual void Fill(MyWindow w, GraphicsPath p)
        {
            drawmode.Fill(w, p);
        }
        public override void Draw(MyWindow w, int left, int top)
        {
            GraphicsPath p = GetGraphicsPath(left, top);
            if (fillable())
            {
                Fill(w, p);
            }
            else
            {
                if ((drawmode as PenMode) != null)
                {
                    Fill(w, p);
                }
                else
                {
                    //一定是程序写挂了才会运行到这个鬼地方，用不是penmode的fillmode是没有意义的
                    DefaultMode.Fill(w, p);
                }
            }
        }
    }
}
