using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AlongSkin.Controls.Metro
{
    public class MetroThumb : Thumb
    {
        public double OldX
        {
            get { return (double)GetValue(OldXProperty); }
            set { SetValue(OldXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OldX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OldXProperty =
            DependencyProperty.Register("OldX", typeof(double), typeof(MetroThumb), new PropertyMetadata(-1.0));



        public double OldY
        {
            get { return (double)GetValue(OldYProperty); }
            set { SetValue(OldYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OldY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OldYProperty =
            DependencyProperty.Register("OldY", typeof(double), typeof(MetroThumb), new PropertyMetadata(-1.0));

        public double OffsetX { get; set; }
        public double OffsetY { get; set; }



        public double X
        {
            get { return (double)GetValue(XProperty) - OffsetX; }
            set { SetValue(XProperty, value + OffsetX); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(MetroThumb), new PropertyMetadata(-1.0, Change));



        public double Y
        {
            get { return (double)GetValue(YProperty) - OffsetY; }
            set { SetValue(YProperty, value + OffsetY); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(MetroThumb), new PropertyMetadata(-1.0, Change));

        public event EventHandler ValueChange;

        private static void Change(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MetroThumb thumb)
            {
                thumb.ValueChange?.Invoke(d, null);
            } 
        }

        public MetroThumb()
        {
            Focusable = true;
            FocusVisualStyle = null;
            Loaded += MetroThumb_Loaded;
            DragStarted += MetroThumb_DragStarted;
            DragDelta += MetroThumb_DragDelta;
        }

        private void MetroThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double x = OldX + e.HorizontalChange;
            double y = OldY + e.VerticalChange;

            if (x < 0) X = 0;
            else if (x > ActualWidth) X = ActualWidth;
            else X = x;

            if (y < 0) Y = 0;
            else if (y > ActualHeight) Y = ActualHeight;
            else Y = y;
        }

        private void MetroThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            Focus();
            OldX = e.HorizontalOffset;
            OldY = e.VerticalOffset;
            X = OldX;
            Y = OldY;
        }

        private void MetroThumb_Loaded(object sender, RoutedEventArgs e)
        {
            X = (double)GetValue(XProperty) == -1 ? 0 : X;
            Y = (double)GetValue(YProperty) == -1 ? 0 : Y;
        }

        public double XPercent
        {
            get
            {
                return X / ActualWidth;
            }
            set
            {
                X = ActualWidth * value;
            }
        }

        public double YPercent
        {
            get
            {
                return Y / ActualHeight;
            }
            set
            {
                Y = ActualHeight * value;
            }
        }
    }
}
