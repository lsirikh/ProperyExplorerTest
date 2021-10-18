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

        public int LabelSize
        {
            get { return (int)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly DependencyProperty LabelSizeProperty =
            DependencyProperty.Register(
                name: nameof(LabelSize),
                propertyType: typeof(int),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );

        public string LabelColor
        {
            get { return (string)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        public static readonly DependencyProperty LabelColorProperty =
            DependencyProperty.Register(
                name: nameof(LabelColor),
                propertyType: typeof(string),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );


        public static readonly DependencyProperty BodyLabelProperty = DependencyProperty.Register
        (
            name: nameof(BodyLabel),
            propertyType: typeof(string),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        public string BodyLabel
        {
            get => (string)GetValue(BodyLabelProperty);
            set => SetValue(BodyLabelProperty, value);
        }

        public static readonly DependencyProperty BodyLabelShowProperty = DependencyProperty.Register
        (
            name: nameof(BodyLabelShow),
            propertyType: typeof(bool),
            ownerType: typeof(DisplayPresenter),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        public bool BodyLabelShow
        {
            get => (bool)GetValue(BodyLabelShowProperty);
            set => SetValue(BodyLabelShowProperty, value);
        }

        public int BodyLabelSize
        {
            get { return (int)GetValue(BodyLabelSizeProperty); }
            set { SetValue(BodyLabelSizeProperty, value); }
        }

        public static readonly DependencyProperty BodyLabelSizeProperty =
            DependencyProperty.Register(
                name: nameof(BodyLabelSize),
                propertyType: typeof(int),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );

        public string BodyLabelColor
        {
            get { return (string)GetValue(BodyLabelColorProperty); }
            set { SetValue(BodyLabelColorProperty, value); }
        }

        public static readonly DependencyProperty BodyLabelColorProperty =
            DependencyProperty.Register(
                name: nameof(BodyLabelColor),
                propertyType: typeof(string),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );











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




        public double ShapeWidth
        {
            get { return (double)GetValue(ShapeWidthProperty); }
            set { SetValue(ShapeWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeWidthProperty =
            DependencyProperty.Register(
                name: nameof(ShapeWidth),
                propertyType: typeof(double),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );

        public double ShapeHeight
        {
            get { return (double)GetValue(ShapeHeightProperty); }
            set { SetValue(ShapeHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeHeightProperty =
            DependencyProperty.Register(
                name: nameof(ShapeHeight),
                propertyType: typeof(double),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );

        public double ShapeAngle
        {
            get { return (double)GetValue(ShapeAngleProperty); }
            set { SetValue(ShapeAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeAngleProperty =
            DependencyProperty.Register(
                name: nameof(ShapeAngle),
                propertyType: typeof(double),
                ownerType: typeof(DisplayPresenter),
                typeMetadata: new FrameworkPropertyMetadata(null)
                );


        static DisplayPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DisplayPresenter), new FrameworkPropertyMetadata(typeof(DisplayPresenter)));
        }

    }
}
