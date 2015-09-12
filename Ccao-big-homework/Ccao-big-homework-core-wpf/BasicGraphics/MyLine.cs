﻿//Du 2015.8
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.BasicGraphics
{
    public sealed class MyLine : SingleModeGraphic
    {
        public float Left1 { get; set; }
        public float Top1 { get; set; }
        public float Left2 { get; set; }
        public float Top2 { get; set; }

        public override Geometry getGeometry(float left = 0, float top = 0)
        {
            return new LineGeometry(
                new Point(Left1 + left, Top1 + top),
                new Point(Left2 + left, Top2 + top)
            );
        }

        public MyLine(float left1, float top1, float left2, float top2)
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
