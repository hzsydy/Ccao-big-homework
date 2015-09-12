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
        public float Height { get; set; }
        public float Width { get; set; }
        public float RadiusX { get; set; }
        public float RadiusY { get; set; }
        public override Geometry getGeometry(float left = 0, float top = 0)
        {
            return new RectangleGeometry(new Rect(left, top, Width, Height), RadiusX, RadiusY);
        }
        public MyRectangle(int height, int width, float radiusx, float radiusy)
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
