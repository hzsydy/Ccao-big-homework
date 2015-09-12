//Du 2015.9
//All rights reserved.

using System.Windows.Media;

namespace Ccao_big_homework_core_wpf.Draw_Mode
{
    /// <summary>
    /// 指示如何绘制一个Geometry形状的Mygraphic的基本类
    /// </summary>
    public abstract class DrawMode
    {
        public DrawMode() { }
        /// <summary>
        /// 对于给定的Geometry形状，绘制对应的drawing图形。
        /// </summary>
        public abstract Drawing draw(Geometry g);
    }
}
