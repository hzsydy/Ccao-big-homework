//Du 2015.8
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.BasicGraphics
{
    /// <summary>
    /// 圆角矩形(包括矩形)。
    /// </summary>
    public sealed class MyRectangle : SingleModeGraphic
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double RadiusX { get; set; }
        public double RadiusY { get; set; }
        protected override Geometry getGeometry(double left = 0.0f, double top = 0.0f)
        {
            return new RectangleGeometry(new Rect(left, top, Width, Height), RadiusX, RadiusY);
        }
        public override MyGraphic Clone()
        {
            MyRectangle me = new MyRectangle(Height, Width, RadiusX, RadiusY);
            me.isVisible = this.isVisible;
            me.drawmode = this.drawmode;
            return me;
        }
        public MyRectangle(double height, double width, double radiusx, double radiusy)
            : base()
        {
            Height = height;
            Width = width;
            RadiusX = radiusx;
            RadiusY = radiusy;
        }
        public MyRectangle(int height, int width)
            : this(height, width, 0.0f, 0.0f) { }
        public MyRectangle()
            : this(0, 0) { }
    }
}
