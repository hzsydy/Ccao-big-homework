using System.Windows;
using ColorPicker;
using System.Windows.Media;

namespace Ccao_big_homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StyleSettingWindow : Window
    {
        public StyleSettingWindow()
        {
            InitializeComponent();
            ColorPicker.SelectedColor = WorkWindow.color;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Color_Changed(object sender, RoutedEventArgs e)
        {
            WorkWindow.color = ColorPicker.SelectedColor;
            WorkWindow.brush = new SolidColorBrush(WorkWindow.color);
            WorkWindow.pen = new Pen(WorkWindow.brush, 2.0f);
            Close();
        }

        private void Border_Changed(object sender, RoutedEventArgs e)
        {
            WorkWindow.color = ColorPicker.SelectedColor;
            WorkWindow.pen = new Pen(new SolidColorBrush(WorkWindow.color), 2.0f);
            Close();
        }
        private void Fill_Changed(object sender, RoutedEventArgs e)
        {
            WorkWindow.color = ColorPicker.SelectedColor;
            WorkWindow.brush = new SolidColorBrush(WorkWindow.color);
            Close();
        }

        private void Color_Unchanged(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
