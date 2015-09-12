//Du 2015.8
//All rights reserved.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Ccao_big_homework_core
{
    /// <summary>
    /// 此处采用了bridge模式，将抽象部分Ccao_big_homework_core与实现部分Ccao_big_homework分离；
    /// 由此我们进行了分工，由我负责抽象，而邵键准同学负责实现；
    /// 采用bridge模式使得我们可以各自独立完成自己的部分而没有耦合。
    /// 以下是接口。
    /// </summary>
    public interface IWindow
    {
        void DrawPath(Pen pen, GraphicsPath path);
        void FillPath(Brush brush, GraphicsPath path);
    }
}
