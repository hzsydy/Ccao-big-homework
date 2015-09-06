//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core.Draw_Mode
{
    public sealed class PictureMode : DrawMode
    {
        /// <summary>
        /// 用规定图片按照graphicpath填充
        /// </summary>
        public PictureMode(Pen p) : base() { }
        public override void Fill(IWindow w, GraphicsPath p)
        {
        }
    }
}
