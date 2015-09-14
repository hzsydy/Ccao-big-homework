using Ccao_big_homework_core_wpf;
using System.Windows;

namespace Ccao_big_homework
{
    /// <summary>
    /// 窗口类中用于新建画布的相关方法
    /// </summary>
    public partial class WorkWindow:Window
    {
        private void btnNew_Click(object sender, RoutedEventArgs args)
        {
            if (isSaved == false)
            {
                if (MessageBox.Show("尚未保存,真的要新建画板吗?", "新建确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    canvas1.Children.Clear();
                    canvas1.InvalidateVisual();
                    du = new DrawingUIElement();
                    compositeGraphic.Clear();
                    canvas1.Children.Add(du);
                    du_refresh();
                    isSaved = false;
                }
            }
            else
            {
                canvas1.Children.Clear();
                canvas1.InvalidateVisual();
                du = new DrawingUIElement();
                compositeGraphic.Clear();
                canvas1.Children.Add(du);
                du_refresh();
                isSaved = false;
            }
        }
    }
}
