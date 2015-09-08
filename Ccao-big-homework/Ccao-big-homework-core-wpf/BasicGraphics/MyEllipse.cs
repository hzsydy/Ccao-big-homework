//Du 2015.8
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.BasicGraphics
{
    /// <summary>
    /// 椭圆。注意：传过来的width和height表示长轴和短轴，而不是半~
    /// </summary>
    public sealed class MyEllipse : SingleModeGraphic
    {
        /// <summary>
        /// 短轴
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 长轴
        /// </summary>
        public int Width { get; set; }
        public override Geometry getGeometry(float left = 0, float top = 0)
        {
            return new EllipseGeometry(new Rect(left, top, Width, Height));
        }
        public MyEllipse(int height, int width)
            : base()
        {
            Height = height;
            Width = width;
        }
        public MyEllipse()
            : this(0, 0) { }
    }
}
