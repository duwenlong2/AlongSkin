using AlongSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlongSkin.Controls.Metro
{
   public  class MetroTitleMenu:Menu
    {
        public MetroTitleMenu()
        {
            Utility.Refresh(this);
        }
        static MetroTitleMenu()
        {
            ElementBase.DefaultStyle<MetroTitleMenu>(DefaultStyleKeyProperty);
        }
    }
}
