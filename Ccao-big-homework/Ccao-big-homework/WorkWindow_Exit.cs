using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Ccao_big_homework
{
    public partial class WorkWindow:Window
    {
        private bool isSaved = false;
        private bool C = false;
        DispatcherTimer timer = new DispatcherTimer();
        
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (isSaved == false)
            {
                if (MessageBox.Show("尚未保存,真的要退出吗?", "退出确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
                    this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
                    C = true;
                    this.Close();
                }
            }
            else
            {
                DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
                this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
                C = true;
                this.Close();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        //关闭窗口时,若是彻底退出,则通过计时器载入淡出动画
        private void On_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (C == true)
            {
                e.Cancel = true;
                timer.Interval = TimeSpan.FromSeconds(0.5);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }
        }

    }
}
