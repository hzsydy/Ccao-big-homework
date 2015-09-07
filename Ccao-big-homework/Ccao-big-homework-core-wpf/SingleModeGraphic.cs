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
        /// <summary>
        /// draw.
        /// 会尝试调用各种drawmode，都挂掉了之后会使用defaultmode
        /// </summary>
        /// <param name="w"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public override Drawing Draw(int left = 0, int top = 0)
        {
            return drawmode.draw(getGeometry(left, top));
        }
    }
}
