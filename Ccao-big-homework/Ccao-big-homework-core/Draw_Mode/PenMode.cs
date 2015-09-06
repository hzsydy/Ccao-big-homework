//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core.Draw_Mode
{
    public sealed class PenMode : DrawMode
    {
        /// <summary>
        /// 用笔来按照graphicpath绘图
        /// </summary>
        public Pen pen { get; set; }
        public PenMode(Pen p) : base() { pen = p;}
        public override void Fill(IWindow w, GraphicsPath p)
        {
            w.DrawPath(pen, p);
        }
        public override bool isFillable() { return false; }
    }
}
