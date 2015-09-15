using Ccao_big_homework_core_wpf;
using System.Windows;
using System.Windows.Input;

namespace Ccao_big_homework
{
    /// <summary>
    /// 键盘事件处理相关方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        private void KeyPress(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.A) SelectAll();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.C) Copy();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.X) Cut();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V) Paste();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.W) Exit();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.O) Open();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.N) New();
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.S) Save();
            else if (e.Key == Key.Delete) Delete();
            else if (e.Key == Key.Down)
            {
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.Move(0, 5);
                }
                du_refresh();
            }
            else if (e.Key == Key.Up)
            {
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.Move(0, -5);
                }
                du_refresh();
            }
            else if (e.Key == Key.Left)
            {
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.Move(-5, 0);
                }
                du_refresh();
            }
            else if (e.Key == Key.Right)
            {
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.Move(5, 0);
                }
                du_refresh();
            }
        }
    }
}
