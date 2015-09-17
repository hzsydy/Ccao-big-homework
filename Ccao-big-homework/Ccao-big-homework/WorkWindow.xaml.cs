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
        public static Color color = Color.FromArgb(255, 100, 20, 255);
        public static Brush brush = new SolidColorBrush(color);
        public static Pen pen = new Pen(new SolidColorBrush(Color.FromArgb(255,0,0,0)), 2.0f);
        private bool isVisible = true;
        private double timeOfAnimation = 0.6;
        private CompositeGraphic compositeGraphic = new CompositeGraphic();
        private DrawingUIElement du = new DrawingUIElement();
        private DispatcherTimer timer1 = new DispatcherTimer();
        public WorkWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 动画相关
        //淡入效果和菜单进入效果
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            DoubleAnimation OpercityAnimation = new DoubleAnimation(0.01, 1.00, new Duration(TimeSpan.FromSeconds(0.4)));
            this.BeginAnimation(Window.OpacityProperty, OpercityAnimation);
            compositeGraphic.Width = canvas1.Width;
            compositeGraphic.Height = canvas1.Height;
            canvas1.Children.Add(du);
            selected();
            ThicknessAnimation ta1 = new ThicknessAnimation();
            ta1.From = new Thickness(15, -100, 15, 139);
            ta1.To = new Thickness(15, 26, 15, 13);
            ta1.Duration = TimeSpan.FromSeconds(timeOfAnimation);
            ta1.DecelerationRatio = 1;
            top.BeginAnimation(Border.MarginProperty, ta1);
            ThicknessAnimation ta2 = new ThicknessAnimation();
            ta2.From = new Thickness(-100, 10, 159, 98);
            ta2.To = new Thickness(20, 10, 39, 98);
            ta2.Duration = TimeSpan.FromSeconds(timeOfAnimation);
            ta2.DecelerationRatio = 1;
            left.BeginAnimation(Border.MarginProperty, ta2);
            ThicknessAnimation ta3 = new ThicknessAnimation();
            ta3.From = new Thickness(-100, 44, 136, 0);
            ta3.To = new Thickness(36, 44, 0, 0);
            ta3.Duration = TimeSpan.FromSeconds(timeOfAnimation);
            ta3.DecelerationRatio = 1;
            StartPanda.BeginAnimation(Border.MarginProperty, ta3);
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
            isVisible = !isVisible;
            foreach (MyGraphic mg in selectedGraphics)
            {
                mg.isVisible = isVisible;
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
