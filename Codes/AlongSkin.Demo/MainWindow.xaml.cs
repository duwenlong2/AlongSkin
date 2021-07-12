using AlongSkin.Controls.Metro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AlongSkin.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
           Theme.ColorChange += delegate
           {
               // 不要通过XAML来绑定颜色，无法获取到通知
               BorderBrush = Theme.CurrentColor.OpaqueSolidColorBrush;
           };
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // Debug.WriteLine(t.Text);
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button_PreviewMouseDown");
            e.Handled = false; 
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button_MouseDown");
        }
    }
}
