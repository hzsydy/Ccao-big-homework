//Du 2015.9
//All rights reserved.

using System.Windows.Media;


namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    public abstract class DrawMode
    {
        public DrawMode() { }
        public abstract Drawing draw(Geometry g);
    }
}
