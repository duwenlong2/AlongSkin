using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AlongSkin.Themes
{
    public class Theme
    {
        public static void Switch(Visual visual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (childVisual != null)
                {
                    Controls.Utility.Refresh(childVisual as FrameworkElement);
                     Switch(childVisual);
                }
            }
        }
    }
}
