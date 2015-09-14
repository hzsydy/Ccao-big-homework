using System;
using System.Windows;
using System.Windows.Input;
using Ccao_big_homework_core_wpf;
using Ccao_big_homework_core_wpf.BasicGraphics;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;
using Ccao_big_homework_core_wpf.Draw_Mode;
using System.Windows.Threading;

namespace Ccao_big_homework
{
    /// <summary>
    /// WorkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WorkWindow :Window
    {
        #region 基础变量和构造函数
        public static Color color = Color.FromArgb(255, 0, 0, 0);
        public static Brush brush = new SolidColorBrush(color);
        public static Pen pen = new Pen(brush, 2.0f);
        private CompositeGraphic compositeGraphic = new CompositeGraphic();
        private DrawingUIElement du = new DrawingUIElement();
        private DispatcherTimer timer1 = new DispatcherTimer();
        public WorkWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 动画相关
        //淡入效果
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
            compositeGraphic.Width = canvas1.Width;
            compositeGraphic.Height = canvas1.Height;
            canvas1.Children.Add(du);
            selected();
        }
        //画面刷新
        private void du_refresh()
        {
            du.drawing = compositeGraphic.Draw();
            du.InvalidateVisual();
        }
        //计时器,选中的图形闪烁
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (MyGraphic mg in selectedGraphics)
            {
                mg.isVisible = !mg.isVisible;
            }
            du_refresh();
        }
        private void selected()
        {
            timer1.Interval = TimeSpan.FromSeconds(0.3);
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        //工具条隐藏尾部小箭头方法
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            FrameworkElement overflowGrid = (FrameworkElement)toolBar.Template.FindName("OverflowGrid", toolBar);
            if(overflowGrid != null)
                overflowGrid.Visibility = Visibility.Collapsed;
            FrameworkElement mainPanelBorder = (FrameworkElement)toolBar.Template.FindName("MainPanelBorder", toolBar);
            if(mainPanelBorder != null)
            mainPanelBorder.Margin = new Thickness(0);
        }
        #endregion
    }
}
