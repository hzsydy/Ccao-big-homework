//Du 2015.8
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.BasicGraphics
{
    /// <summary>
    /// 贝塞尔曲线。
    /// </summary>
    public sealed class MyBezier : SingleModeGraphic
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        private static readonly Point zeropoint = new Point(0.0f, 0.0f);
        public override MyGraphic Clone()
        {
            MyBezier me = new MyBezier(Point1, Point2, Point3);
            me.isVisible = this.isVisible;
            me.drawmode = this.drawmode;
            return me;
        }
        protected override Geometry getGeometry(double left = 0.0f, double top = 0.0f)
        {
            Point p = new Point(left, top);
            Point p1 = _addpoint(p, Point1);
            Point p2 = _addpoint(p, Point2);
            Point p3 = _addpoint(p, Point3);
            PathSegment ps = new BezierSegment(p1, p2, p3, true);
            PathFigure pf = new PathFigure();
            pf.Segments.Add(ps);
            PathGeometry pg = new PathGeometry();
            pg.Figures.Add(pf);
            return pg;
        }
        public MyBezier(Point p1, Point p2, Point p3)
            : base()
        {
            Point1 = p1;
            Point2 = p2;
            Point3 = p3;
        }
        public MyBezier()
            : this(zeropoint, zeropoint, zeropoint) { }
    }
}
