using AlongSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AlongSkin.Controls.Metro
{
   public class MetroTextBox:TextBox
    {


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MetroTextBox));



        public double TitleMinWidth
        {
            get { return (double)GetValue(TitleMinWidthProperty); }
            set { SetValue(TitleMinWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleMinWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleMinWidthProperty =
            DependencyProperty.Register("TitleMinWidth", typeof(double), typeof(MetroTextBox));
 
        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(MetroTextBox));
 
        public Brush MouseMoveBackground
        {
            get { return (Brush)GetValue(MouseMoveBackgroundProperty); }
            set { SetValue(MouseMoveBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseMoveBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseMoveBackgroundProperty =
            DependencyProperty.Register("MouseMoveBackground", typeof(Brush), typeof(MetroTextBox));



        public string InputHint
        {
            get { return (string)GetValue(InputHintProperty); }
            set { SetValue(InputHintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InputHint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputHintProperty =
            DependencyProperty.Register("InputHint", typeof(string), typeof(MetroTextBox));



        public string PopupHint
        {
            get { return (string)GetValue(PopupHintProperty); }
            set { SetValue(PopupHintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupHint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupHintProperty =
            DependencyProperty.Register("PopupHint", typeof(string), typeof(MetroTextBox));



        public string ButtonTitle
        {
            get { return (string)GetValue(ButtonTitleProperty); }
            set { SetValue(ButtonTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTitleProperty =
            DependencyProperty.Register("ButtonTitle", typeof(string), typeof(MetroTextBox));



        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MetroTextBox),new PropertyMetadata(null));



        public string State
        {
            get { return (string)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(string), typeof(MetroTextBox));



        public bool MultipleLine
        {
            get { return (bool)GetValue(MultipleLineProperty); }
            set { SetValue(MultipleLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MultipleLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MultipleLineProperty =
            DependencyProperty.Register("MultipleLine", typeof(bool), typeof(MetroTextBox),new PropertyMetadata(false));



        public bool IsPassWordBox
        {
            get { return (bool)GetValue(IsPassWordBoxProperty); }
            set { SetValue(IsPassWordBoxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPassWordBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPassWordBoxProperty =
            DependencyProperty.Register("IsPassWordBox", typeof(bool), typeof(MetroTextBox),new PropertyMetadata(false));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MetroTextBox));

        public Func<string, bool> ErrorCheckAction { get; set; }

        public event EventHandler ButtonClick;

        public static RoutedUICommand ButtonClickCommand = new RoutedUICommand("ButtonClickCommand", "ButtonClickCommand", typeof(MetroTextBox));

        public MetroTextBox()
        {
            ContextMenu = null;
            Loaded += MetroTextBox_Loaded;
            TextChanged += MetroTextBox_TextChanged;
            CommandBindings.Add(new System.Windows.Input.CommandBinding(ButtonClickCommand, delegate { if (ButtonClick != null) { ButtonClick(this, null); } }));
            Utility.Refresh(this);
        }
        void ErrorCheck()
        { 
            if (ErrorCheckAction != null) { State = ErrorCheckAction(Text) ? "true" : "false"; }
        }
        private void MetroTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorCheck();
        }

        private void MetroTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            ErrorCheck();
        }
        static MetroTextBox()
        {
            ElementBase.DefaultStyle<MetroTextBox>(DefaultStyleKeyProperty);
        }
    }
}
