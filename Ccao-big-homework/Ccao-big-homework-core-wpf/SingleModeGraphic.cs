//Du 2015.9
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
            SelectError = 1.0f;
        }
        /// <summary>
        /// 设置填充模式
        /// </summary>
        public DrawMode drawmode { get; set; }
        /// <summary>
        /// 获得此图像的Geometry
        /// </summary>
        /// <returns>graphicspath</returns>
        protected abstract Geometry getGeometry(double left = 0.0f, double top = 0.0f);

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

        public override CompositeGraphic SelectRect(Rect r, double left = 0.0f, double top = 0.0f)
        {
            CompositeGraphic cg = new CompositeGraphic();
            RectangleGeometry rg = new RectangleGeometry(r);
            Geometry g = getGeometry(left, top);
            if (g.FillContainsWithDetail(rg) != IntersectionDetail.Empty)
            {
                cg.Add(this, left, top);
                cg.Width = g.Bounds.Width + 2 * SelectError;
                cg.Height = g.Bounds.Height + 2 * SelectError;
            }
            return cg;
        }
    }
}
