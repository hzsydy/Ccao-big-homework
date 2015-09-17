//Du 2015.9
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf
{
    /// <summary>
    ///采用了Adapter（或者叫做Wrapper）设计模式
    ///将本类库的接口类型（System.Windows.Media.Drawing）转换为我的调用方
    ///邵键准同学的UI能够接受的参数UIElement。
    /// </summary>
    public class DrawingUIElement : UIElement
    {
        public Drawing drawing { get; set; }
        public DrawingUIElement(Drawing d) : base() { drawing = d; }
        public DrawingUIElement() : base() { }
        /// <summary>
        /// 重载OnRender
        /// </summary>
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing(drawing);
        }
    }
}
