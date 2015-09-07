//Du 2015.9
//All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;


namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    public static partial class defaultConstant
    {
        public static readonly Color nullColor = Color.FromArgb(0, 255, 255, 255);
        public static readonly Color white = Color.FromArgb(255, 255, 255, 255);
        public static readonly Color black = Color.FromArgb(255, 0, 0, 0);
        public static readonly Brush defaultbrush = new SolidColorBrush(nullColor);
        public static readonly Pen defaultpen = new Pen(new SolidColorBrush(black), 2.0f);
    }

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
