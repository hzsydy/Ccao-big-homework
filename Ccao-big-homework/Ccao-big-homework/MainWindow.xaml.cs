using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Ccao_big_homework
{
    /// <summary>
    /// 启动窗口
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool C = false;
        Button b;
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();
        
        //窗口启动时的淡入效果
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
        }

        //窗口关闭时的淡出动画
        private void Close_MainWindow(object sender, RoutedEventArgs e)
        {
            if (b != null) b.IsEnabled = true;
            b = sender as Button;
            b.IsEnabled = false;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
            C = true;
            this.Close();
            
        }
        //新建绘图按钮
        private void NewWindow(object sender, RoutedEventArgs e)
        {
            if (b != null) b.IsEnabled = true;
            b = sender as Button;
            b.IsEnabled = false;
            WorkWindow workwindow = new WorkWindow();
            workwindow.Show();
            this.Close();
        }

        //窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //计时器
        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
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
