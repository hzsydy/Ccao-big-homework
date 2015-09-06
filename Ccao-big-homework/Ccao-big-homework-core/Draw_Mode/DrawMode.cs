//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core.Draw_Mode
{
    /// <summary>
    /// 决定绘图所用的填充模式的基类
    /// </summary>
    public abstract class DrawMode
    {
        public DrawMode() { }
        /// <summary>
        /// 指定填充方式
        /// </summary>
        /// <param name="w"></param>
        /// <param name="p"></param>
        public abstract void Fill(IWindow w, GraphicsPath p);
        /// <summary>
        /// 当这个参数为false的时候才表示它可以画线，为true的时候只能填充
        /// </summary>
        /// <returns></returns>
        public virtual bool isFillable() { return true; }
    }
}
