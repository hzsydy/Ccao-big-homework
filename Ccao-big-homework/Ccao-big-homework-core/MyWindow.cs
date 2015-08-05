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
    /// 以下是接口。所有的函数名都和system.drawing中的一样，这是为了方便邵键准同学的实现。
    /// </summary>
    public abstract class MyWindow
    {
        public abstract void DrawPath(Pen pen, GraphicsPath path);
        public abstract void FillPath(Brush brush, GraphicsPath path);
    }
}
