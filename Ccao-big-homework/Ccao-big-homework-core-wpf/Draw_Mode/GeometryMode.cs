//Du 2015.9
//All rights reserved.

using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    /// <summary>
    /// 会用到的常量。
    /// 被定义为partial以在每个要调用到它的地方使用
    /// </summary>
    public static partial class defaultConstant
    {
        public static readonly Color nullColor = Color.FromArgb(0, 255, 255, 255);
        public static readonly Color white = Color.FromArgb(255, 255, 255, 255);
        public static readonly Color black = Color.FromArgb(255, 0, 0, 0);
        public static readonly Brush defaultbrush = new SolidColorBrush(nullColor);
        public static readonly Pen defaultpen = new Pen(new SolidColorBrush(black), 2.0f);
    }

    /// <summary>
    /// 用brush和pen绘制一个drawing的drawmode
    /// </summary>
    public sealed class GeometryMode : DrawMode
    {
        public GeometryMode(Brush _brush, Pen _pen)
        {
            brush = _brush;
            pen = _pen;
        }
        public GeometryMode() 
            : this(defaultConstant.defaultbrush, defaultConstant.defaultpen) { }
        public Brush brush { get; set; }
        public Pen pen { get; set; }
        public override Drawing draw(Geometry g)
        {
            GeometryDrawing gd = new GeometryDrawing(brush, pen, g);
            return gd;
        }
    }
}
