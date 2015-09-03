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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int C = 0;
        Button b;
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)//淡入效果
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
        } 
       
        private void Close_MainWindow(object sender, RoutedEventArgs e)//离开按钮
        {
            if (b != null) b.IsEnabled = true;
            b = sender as Button;
            b.IsEnabled = false;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(1, 0.01, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
            C = 1;
            this.Close();
            
        }


        private void NewWindow(object sender, RoutedEventArgs e)//新建绘图按钮
        {
            if (b != null) b.IsEnabled = true;
            b = sender as Button;
            b.IsEnabled = false;
            WorkWindow workwindow = new WorkWindow();
            workwindow.Show();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//窗口拖动
        {
            this.DragMove();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void On_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (C == 1)
            {
                e.Cancel = true;
                timer.Interval = TimeSpan.FromSeconds(0.5);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }
        }

        
    }
}
