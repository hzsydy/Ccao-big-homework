//Du 2015.8
//All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Ccao_big_homework_core_wpf.Draw_Mode;

namespace Ccao_big_homework_core_wpf
{
    /// <summary>
    /// 整个graphic采用同一种drawmode的graphic。
    /// </summary>
    public abstract class SingleModeGraphic : MyGraphic
    {
        public SingleModeGraphic()
        {
            drawmode = new GeometryMode();
            SelectError = 2.0f;
        }
        /// <summary>
        /// 设置填充模式
        /// </summary>
        public DrawMode drawmode { get; set; }
        /// <summary>
        /// 获得此图像的Geometry
        /// </summary>
        /// <returns>graphicspath</returns>
        public abstract Geometry getGeometry(int left = 0, int top = 0);

        public override Drawing Draw(int left = 0, int top = 0)
        {
            return drawmode.draw(getGeometry(left, top));
        }


        /// <summary>
        /// 点取graphic时允许的误差
        /// </summary>
        public static float SelectError { get; set; }
        public override bool isContained(Point p, int left = 0, int top = 0)
        {
            return getGeometry(left, top).FillContains(p, SelectError, ToleranceType.Absolute);
        }
        public override MyGraphic SelectPoint(Point p, int left = 0, int top = 0)
        {
            return isContained(p, left, top) ? this : null;
        }
    }
}
