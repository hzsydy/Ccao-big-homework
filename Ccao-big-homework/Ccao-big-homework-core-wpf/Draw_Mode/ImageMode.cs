//Du 2015.9
//All rights reserved.

using System;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    /// <summary>
    /// 通过一个imagesource绘制一个drawing。
    /// 注意：无论你传过来的是怎样的图形，都只会按照这个图形的bound来画。
    /// 所以最好还是传个矩形过来对不对
    /// </summary>
    public sealed class ImageMode : DrawMode
    {
        public ImageMode(ImageSource _imagesource) 
        {
            imagesource = _imagesource;
        }
        /// <summary>
        /// 原图片。
        /// </summary>
        public ImageSource imagesource { get; set; }
        public override Drawing draw(Geometry g)
        {
            ImageDrawing id = new ImageDrawing(imagesource, g.Bounds);
            return id;
        }
    }
}
