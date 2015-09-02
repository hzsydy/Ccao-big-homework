//Du 2015.8
//All rights reserved.

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 直线。
    /// 注意直线直接存储其点相对的坐标，所以draw直线的时候left和top都应设0，或者调用只有参数w的模式
    /// </summary>
    public class MyLine : SingleModeGraphic
    {
        public override bool fillable() { return false; }
        public int left1{get; set;}
        public int top1{get; set;}
        public int left2{get; set;}
        public int top2{get; set;}
        public override GraphicsPath GetGraphicsPath(int left, int top)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddLine(left + left1, top + top1, left + left2, top + top2);
            return p;
        }
        public MyLine(int x1, int y1, int x2, int y2)
        {
            left1 = x1;
            left2 = x2;
            top1 = y1;
            top2 = y2;
        }
    }
}
