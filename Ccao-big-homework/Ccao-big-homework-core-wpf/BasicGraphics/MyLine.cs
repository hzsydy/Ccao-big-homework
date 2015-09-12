//Du 2015.8
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.BasicGraphics
{
    public sealed class MyLine : SingleModeGraphic
    {
        public double Left1 { get; set; }
        public double Top1 { get; set; }
        public double Left2 { get; set; }
        public double Top2 { get; set; }

        public override Geometry getGeometry(double left = 0.0f, double top = 0.0f)
        {
            return new LineGeometry(
                new Point(Left1 + left, Top1 + top),
                new Point(Left2 + left, Top2 + top)
            );
        }

        public MyLine(double left1, double top1, double left2, double top2)
            : base() 
        {
            Left1 = left1;
            Top1 = top1;
            Left2 = left2;
            Top2 = top2;
        }
        public MyLine()
            : this(0, 0, 0, 0) { }
    }
}
