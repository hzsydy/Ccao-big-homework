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
using System.Windows.Shapes;
using System.Drawing;
using Ccao_big_homework_core;
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation; 

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window
    {
        public WorkWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)//淡入效果
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
        } 

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//窗口拖动
        {
            this.DragMove();
        }
    }
}
