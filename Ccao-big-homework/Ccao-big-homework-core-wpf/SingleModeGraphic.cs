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
            : base()
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
        public abstract Geometry getGeometry(double left = 0.0f, double top = 0.0f);

        public override Drawing Draw(double left = 0.0f, double top = 0.0f)
        {
            if (isVisible)
            {
                return drawmode.draw(getGeometry(left, top));
            } 
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 点取graphic时允许的误差
        /// </summary>
        public static double SelectError { get; set; }
        public override bool isContained(Point p, double left = 0.0f, double top = 0.0f)
        {
            return getGeometry(left, top).FillContains(p, SelectError, ToleranceType.Absolute);
        }
        public override MyGraphic SelectPoint(Point p, double left = 0.0f, double top = 0.0f)
        {
            return isContained(p, left, top) ? this : null;
        }
        public override List<MyGraphic> SelectRect(Point p1, Point p2, double left = 0.0f, double top = 0.0f)
        {
            List<MyGraphic> lm = new List<MyGraphic>();
            lm.Clear();
            Point p = new Point(left, top);
            RectangleGeometry rg = new RectangleGeometry(new Rect(_addpoint(p1, p), _addpoint(p2, p)));
            if (getGeometry(left, top).FillContainsWithDetail(rg) != IntersectionDetail.Empty)
            {
                lm.Add(this);
                return lm;
            }
            else
            {
                return null;
            }
        }
    }
}
