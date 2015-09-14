using System.Windows;

namespace Ccao_big_homework
{
    /// <summary>
    /// 主窗口上方一行按钮的事件处理方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        //保存按钮
        private void btnSave_Click(object sender, RoutedEventArgs args)
        {
            Save();
        }
        //打开文件按钮
        private void btnOpen_Click(object sender, RoutedEventArgs args)
        {
            Open();
        }
        //新建画布按钮
        private void btnNew_Click(object sender, RoutedEventArgs args)
        {
            New();
        }
        //退出按钮
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        //复制按钮
        private void btnCopy_Click(object sender, RoutedEventArgs args)
        {
            Copy();
        }
        //剪切按钮
        private void btnCut_Click(object sender, RoutedEventArgs args)
        {
            Cut();
        }
        //粘贴按钮
        private void btnPaste_Click(object sender, RoutedEventArgs args)
        {
            Paste();
        }
        //删除按钮
        private void btnDelete_Click(object sender, RoutedEventArgs args)
        {
            Delete();
        }
        //全选按钮
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            SelectAll();
        }
        //样式选择按钮
        private void btnStylusSettings_Click(object sender, RoutedEventArgs e)
        {
            StyleSettingWindow ssw = new StyleSettingWindow();
            ssw.Show();
        }
    }
}
