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
        public abstract void Fill(MyWindow w, GraphicsPath p);
    }
}
