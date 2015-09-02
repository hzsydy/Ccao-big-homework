//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core.Draw_Mode
{
    public sealed class PenMode : DrawMode
    {
        public Pen pen { get; set; }
        public PenMode(Pen p) : base() { pen = p;}
        public override void Fill(MyWindow w, GraphicsPath p)
        {
            w.DrawPath(pen, p);
        }
    }
}
