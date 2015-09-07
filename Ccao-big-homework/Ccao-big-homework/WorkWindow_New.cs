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
                    isSaved = true;
                }
            }
            else
            {
                canvas1.Children.Clear();
                isSaved = false;
            }
        }
    }
}
