using AlongSkin.Controls.Metro;
using AlongSkin.Utility.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlongSkin.Controls
{
    public class Utility
    {
        /// <summary>
        /// 刷新模式
        /// </summary>
        /// <param name="control"></param>
        public static void Refresh(FrameworkElement control)
        {
            if (control == null)
            {
                return;
            }
            //正在运行的状态
            if (!DesignerProperties.GetIsInDesignMode(control))
            {
                if (control.IsLoaded)
                {
                    SetColor(control);
                }
                else
                {
                    control.Loaded += delegate { SetColor(control); };
                }
            }
        }

        private static void SetColor(FrameworkElement control)
        {
            var mw = Window.GetWindow(control) is MetroWindow ? Window.GetWindow(control) as MetroWindow : null;
            if (mw != null)
            {
                if (control is MetroTitleMenu metroTitleMenu)
                {
                    metroTitleMenu.Background = mw.BorderBrush;
                }
                if (control is MetroTextBox textbox)
                {
                    textbox.BorderBrush = mw.BorderBrush;
                    textbox.Foreground = mw.BorderBrush;
                }
                if (control is MetroCanvasGrid)
                {
                    if ((control as MetroCanvasGrid).IsApplyTheme)
                    {
                        (control as MetroCanvasGrid).Background = new RgbaColor(mw.BorderBrush).OpaqueSolidColorBrush; 
                    }
                }
                if (control is MetroColorPicker) { (control as MetroColorPicker).BorderBrush = mw.BorderBrush; }

                if (control is MetroMenuItem) { (control as MetroMenuItem).Foreground = mw.BorderBrush; } 
            }
        }
    }
}
