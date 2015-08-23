//Du 2015.8
//All rights reserved.

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 决定绘图所用的色彩、笔的粗细、填充模式等的类
    /// </summary>
    public class DrawMode
    {
        /// <summary>
        /// 各种填充模式。
        /// </summary>
        public enum MyFillMode
        {
            Empty = 1,  //不填充
            Filled      //用某种颜色完全填充

        }
        /// <summary>
        /// 决定填充模式。
        /// </summary>
        public MyFillMode fillmode { get; set; }
        /// <summary>
        /// 填充用色。
        /// </summary>
        public Brush brush { get; set; }
        /// <summary>
        /// 边框用笔。
        /// </summary>
        public Pen pen { get; set; }
        /// <summary>
        /// 初始化drawmode：黑色边框，黑色底色，不填充
        /// </summary>
        public DrawMode()
        {
            fillmode = MyFillMode.Empty;
            pen = new Pen(Color.Black, 2.0f);
            brush = new SolidBrush(Color.Black);
        }
    }
}
