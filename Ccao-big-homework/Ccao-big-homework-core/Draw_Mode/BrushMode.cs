//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core.Draw_Mode
{
    public sealed class BrushMode : DrawMode
    {
        public Brush brush { get; set; }
        public BrushMode(Brush b) : base() { brush = b; }
        public override void Fill(MyWindow w, GraphicsPath p)
        {
            w.FillPath(brush, p);
        }
    }
}
