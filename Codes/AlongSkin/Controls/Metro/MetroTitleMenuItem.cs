using AlongSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlongSkin.Controls.Metro
{
    public class MetroTitleMenuItem : MenuItem
    {
        public new ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly new DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MetroTitleMenuItem));

        public MetroTitleMenuItem()
        {
            Utility.Refresh(this);
        }

        static MetroTitleMenuItem()
        {
            ElementBase.DefaultStyle<MetroTitleMenuItem>(DefaultStyleKeyProperty);
        }

    }
}
