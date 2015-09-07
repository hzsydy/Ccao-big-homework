//Du 2015.9
//All rights reserved.

using System;
using System.Windows.Media;


namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    public sealed class ImageMode : DrawMode
    {
        public ImageMode(ImageSource _imagesource) 
        {
            imagesource = _imagesource;
        }
        public ImageSource imagesource { get; set; }
        public override Drawing draw(Geometry g)
        {
            ImageDrawing id = new ImageDrawing(imagesource, g.Bounds);
            return id;
        }
    }
}
