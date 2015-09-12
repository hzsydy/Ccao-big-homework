//Du 2015.9
//All rights reserved.

using System.Windows;
using System.Windows.Media;

namespace Ccao_big_homework_core_wpf
{
    public class DrawingUIElement : UIElement
    {
        public Drawing drawing { get; set; }
<<<<<<< HEAD
        public DrawingUIElement(Drawing d) : base() { drawing = d; }
        public DrawingUIElement() : base() { }
=======
        //public DrawingUIElement(Drawing d): base() { drawing = d; }
>>>>>>> origin/Pierre
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing(drawing);
        }
    }
}
