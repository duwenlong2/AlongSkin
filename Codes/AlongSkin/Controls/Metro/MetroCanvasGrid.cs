using AlongSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AlongSkin.Controls.Metro
{
    public class MetroCanvasGrid : ContentControl
    {
        public bool IsApplyTheme { get; set; } 
        
        public Rect Viewport        
        {
            get { return (Rect)GetValue(ViewportProperty); }
            set { SetValue(ViewportProperty, value); }
        }

        // Using a DependencyProperty as the backing store for rect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewportProperty =
            DependencyProperty.Register("Viewport", typeof(Rect), typeof(MetroCanvasGrid));



        public double GridOpacity
        {
            get { return (double)GetValue(GridOpacityProperty); }
            set { SetValue(GridOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridOpacityProperty =
            DependencyProperty.Register("GridOpacity", typeof(double), typeof(MetroCanvasGrid));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MetroCanvasGrid));




        public MetroCanvasGrid()
        {
            
            Utility.Refresh(this);
        }

        static MetroCanvasGrid()
        {
            ElementBase.DefaultStyle<MetroCanvasGrid>(DefaultStyleKeyProperty);
        }
    }
}
