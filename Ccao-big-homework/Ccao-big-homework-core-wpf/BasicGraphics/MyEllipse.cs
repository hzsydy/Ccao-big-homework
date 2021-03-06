﻿//Du 2015.8
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
        public double Height { get; set; }
        /// <summary>
        /// 长轴
        /// </summary>
        public double Width { get; set; }
        public override MyGraphic Clone()
        {
            MyEllipse me = new MyEllipse(Height, Width);
            me.isVisible = this.isVisible;
            me.drawmode = this.drawmode;
            return me;
        }
        protected override Geometry getGeometry(double left = 0.0f, double top = 0.0f)
        {
            return new EllipseGeometry(new Rect(left, top, Width, Height));
        }
        public MyEllipse(double height, double width)
            : base()
        {
            Height = height;
            Width = width;
        }
        public MyEllipse()
            : this(0, 0) { }
    }
}
