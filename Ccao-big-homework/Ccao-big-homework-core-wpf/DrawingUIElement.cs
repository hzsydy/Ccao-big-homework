//Du 2015.9
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf
{
    class DrawingUIElement : UIElement
    {
        public Drawing drawing { get; set; }
        public DrawingUIElement(Drawing d): base() { drawing = d; }
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing(drawing);
        }
    }
}
