using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PropertyExplorerTest.Controls
{
    /// <summary>    
    /// </summary>
    public class DisplayPresenter : ContentControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register
        (
            name: nameof(Label),
            propertyType: typeof(string),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelShowProperty = DependencyProperty.Register
        (
            name: nameof(LabelShow),
            propertyType: typeof(bool),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        public bool LabelShow
        {
            get => (bool)GetValue(LabelShowProperty);
            set => SetValue(LabelShowProperty, value);
        }

        public static readonly DependencyProperty XProperty = DependencyProperty.Register
        (
            name: nameof(X),
            propertyType: typeof(double),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public double X
        {
            get => (double)GetValue(XProperty);
            set => SetValue(XProperty, value);
        }


        public static readonly DependencyProperty YProperty = DependencyProperty.Register
        (
            name: nameof(Y),
            propertyType: typeof(double),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public double Y
        {
            get => (double)GetValue(YProperty);
            set => SetValue(YProperty, value);
        }

        public static readonly DependencyProperty LocationShowProperty = DependencyProperty.Register
        (
            name: nameof(LocationShow),
            propertyType: typeof(bool),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        public bool LocationShow
        {
            get => (bool)GetValue(LocationShowProperty);
            set => SetValue(LocationShowProperty, value);
        }

        static DisplayPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DisplayPresenter), new FrameworkPropertyMetadata(typeof(DisplayPresenter)));
        }       
    }
}
