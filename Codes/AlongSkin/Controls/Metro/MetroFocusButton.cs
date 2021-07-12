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
   public class MetroFocusButton:Button
    {


        public Brush MouseMoveForeground
        {
            get { return (Brush)GetValue(MouseMoveForegroundProperty); }
            set { SetValue(MouseMoveForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseMoveForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseMoveForegroundProperty =
            DependencyProperty.Register("MouseMoveForeground", typeof(Brush), typeof(MetroFocusButton));




        public Brush MouseMoveBorderBrush
        {
            get { return (Brush)GetValue(MouseMoveBorderBrushProperty); }
            set { SetValue(MouseMoveBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseMoveBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseMoveBorderBrushProperty =
            DependencyProperty.Register("MouseMoveBorderBrush", typeof(Brush), typeof(MetroFocusButton));




        public new  double BorderThickness
        {
            get { return (double)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        public static readonly new  DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(double), typeof(MetroFocusButton));



        public double MouseMoveBorderThickness
        {
            get { return (double)GetValue(MouseMoveBorderThicknessProperty); }
            set { SetValue(MouseMoveBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseMoveBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseMoveBorderThicknessProperty =
            DependencyProperty.Register("MouseMoveBorderThickness", typeof(double), typeof(MetroFocusButton));



        public DoubleCollection StrokeDashArray
        {
            get { return (DoubleCollection)GetValue(StrokeDashArrayProperty); }
            set { SetValue(StrokeDashArrayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.Register("StrokeDashArray", typeof(DoubleCollection), typeof(MetroFocusButton));



        public DoubleCollection MouseMoveStrokeDashArray
        {
            get { return (DoubleCollection)GetValue(MouseMoveStrokeDashArrayProperty); }
            set { SetValue(MouseMoveStrokeDashArrayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseMoveStrokeDashArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseMoveStrokeDashArrayProperty =
            DependencyProperty.Register("MouseMoveStrokeDashArray", typeof(DoubleCollection), typeof(MetroFocusButton));



        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MetroFocusButton));

        static MetroFocusButton()
        {
            ElementBase.DefaultStyle<MetroFocusButton>(DefaultStyleKeyProperty);
        }



    }
}
