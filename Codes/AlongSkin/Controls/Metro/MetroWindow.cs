using AlongSkin.Themes;
using AlongSkin.Utility.Element;
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

namespace AlongSkin.Controls.Metro
{
    [TemplatePart(Name = "PART_MINIMIZE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_RESTORE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CLOSE", Type = typeof(Button))]
    public class MetroWindow : Window
    {
        public bool IsSubWindowShow
        {
            get { return (bool)GetValue(IsSubWindowShowProperty); }
            set { SetValue(IsSubWindowShowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSubWindowShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSubWindowShowProperty =
            DependencyProperty.Register("IsSubWindowShow", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false, IsSubWindowShowCallback));

        private static void IsSubWindowShowCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GoToState((FrameworkElement)d, (bool)e.NewValue);
        }
        static void GoToState(FrameworkElement element, bool isSubWindowShow)
        {
            ElementBase.GoToState(element, isSubWindowShow ? "Enabled" : "Disable");
        }


        public object Menu
        {
            get { return (object)GetValue(MenuProperty); }
            set { SetValue(MenuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Menu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuProperty =
            DependencyProperty.Register("Menu", typeof(object), typeof(MetroWindow), new PropertyMetadata(null));

        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        public static readonly new DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(BorderBrushChange));

        private static void BorderBrushChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement win)
            {
                if (win.IsLoaded)
                {
                    Theme.Switch(win);
                }
            }
        }

        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitileForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(MetroWindow));


        public FontSizeConverter TitleFontSize
        {
            get { return (FontSizeConverter)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(FontSizeConverter), typeof(MetroWindow));

        public Brush SysButtonColor
        {
            get { return (Brush)GetValue(SysButtonColorProperty); }
            set { SetValue(SysButtonColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SysButtonColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SysButtonColorProperty =
            DependencyProperty.Register("SysButtonColor", typeof(Brush), typeof(MetroWindow));



        static MetroWindow()
        {
            ElementBase.DefaultStyle<MetroWindow>(DefaultStyleKeyProperty);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AllowsTransparency = false;
            if (WindowStyle == WindowStyle.None)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var minimizeButton = GetTemplateChild("PART_MINIMIZE") as Button;
            minimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;

            var restoreButton = GetTemplateChild("PART_RESTORE") as Button;
            restoreButton.Click += (s, e) =>
            {
                // if (WindowState == WindowState.Normal)
                //     WindowState = WindowState.Maximized;
                // else
                WindowState = WindowState.Normal;
            };
            var maxButton = GetTemplateChild("PART_MAXIMIZE") as Button;
            maxButton.Click += (s, e) =>
            {
                WindowState = WindowState.Maximized;
            };

              var closeButton = GetTemplateChild("PART_CLOSE") as Button;
            closeButton.Click += (s, e) => Close();
        }

        public bool EscClose { get; set; } = false;
        public MetroWindow()
        {
            var sizeToContent = SizeToContent.Manual;
            Loaded += (s, e) =>
              {
                  sizeToContent = SizeToContent;
              };
            ContentRendered += (s, e) =>
              {
                  SizeToContent = SizeToContent.Manual;
                  Width = ActualWidth;
                  Height = ActualHeight;
                  SizeToContent = sizeToContent;
              };
            KeyUp += MetroWindow_KeyUp;

            StateChanged += MetroWindow_StateChanged;
            Utility.Refresh(this);
        }

        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            if (ResizeMode == ResizeMode.CanMinimize || ResizeMode == ResizeMode.NoResize)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }

        private void MetroWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && EscClose)
            {
                Close();
            }
        }
    }
}
