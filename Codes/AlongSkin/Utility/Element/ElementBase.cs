using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlongSkin.Utility.Element
{
    public static class ElementBase
    {
        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="element"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GoToState(FrameworkElement element, string state)
        {
            VisualStateManager.GoToState(element, state, false);
            return state;
        }

        /// <summary>
        /// 默认样式
        /// </summary>
        /// <typeparam name="thisType"></typeparam>
        /// <param name="dp"></param>
        public static void DefaultStyle<thisType>(DependencyProperty dp)
        {
            dp.OverrideMetadata(typeof(thisType), new FrameworkPropertyMetadata(typeof(thisType)));
        }

    }
}
