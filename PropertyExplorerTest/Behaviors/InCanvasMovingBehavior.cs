using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PropertyExplorerTest.Behaviors
{
    public class InCanvasMovingBehavior : DependencyObject
    {

        public static readonly DependencyProperty CapturedProperty = DependencyProperty.RegisterAttached
        (
            name: "Captured",
            propertyType: typeof(bool),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(false, CaptureFromContianerCallback)
        );

        private static void CaptureFromContianerCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement element))
            { 
                return;
            }

            var isCaptured = (bool)e.NewValue;
            if (isCaptured)
            {
                element.CaptureMouse();
            }            
        }

        public static bool GetCaptured(DependencyObject obj)
        {
            return (bool)obj.GetValue(CapturedProperty);
        }

        public static void SetCaptured(DependencyObject obj, bool value)
        {
            obj.SetValue(CapturedProperty, value);
        }





        public static readonly DependencyProperty PanningTargetProperty = DependencyProperty.RegisterAttached
        (
            name: "PanningTarget",
            propertyType: typeof(FrameworkElement),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(null, PanningTargetPropertyChanged)
        );

        private static void PanningTargetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is FrameworkElement element))
            {
                return;
            }

            // 필요시 따로 보관한다.
            var infra = new PanningStructure(element);
        }

        public static FrameworkElement GetPanningTarget(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(PanningTargetProperty);
        }

        public static void SetPanningTarget(DependencyObject obj, object value)
        {
            obj.SetValue(PanningTargetProperty, value);
        }

        public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached
        (
            name: "X",
            propertyType: typeof(double),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PositinChangedCallback)
        );

        private static void PositinChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public static double GetX(DependencyObject obj)
        {
            return (double)obj.GetValue(XProperty);
        }

        public static void SetX(DependencyObject obj, object value)
        {
            obj.SetValue(XProperty, value);
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached
        (
            name: "Y",
            propertyType: typeof(double),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PositinChangedCallback)
        );

        public static double GetY(DependencyObject obj)
        {
            return (double)obj.GetValue(YProperty);
        }

        public static void SetY(DependencyObject obj, object value)
        {
            obj.SetValue(YProperty, value);
        }



        public static T FindParentOfType<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentDepObj = child;
            do
            {
                parentDepObj = VisualTreeHelper.GetParent(parentDepObj);
                T parent = parentDepObj as T;
                if (parent != null) return parent;
            }
            while (parentDepObj != null);
            return null;
        }

        public class PanningStructure : DependencyObject
        {
            private bool _isCaptured;

            /// <summary>
            /// 마우스 다운 위치로부터 오브젝트의 좌상단을 보정하기 위한 포인트.
            /// </summary>
            private Point _originPoint;

            private Canvas _parent;

            private FrameworkElement _element;

            public PanningStructure(FrameworkElement element)
            {
                this._element = element;

                this._parent = FindParentOfType<Canvas>(element);
                if (this._parent == null)
                {
                    // 부모 Canvas 를 못찾으면 실행하지 않는다.
                    return;
                }

                EventManager.RegisterClassHandler(typeof(ListBoxItem), ListBoxItem.MouseLeftButtonDownEvent, new RoutedEventHandler(this.OnMouseLeftButtonDown));

                //element.MouseDown += this.ElementOnMouseDown;
                element.MouseMove += this.ElementOnMouseMove;
                element.MouseUp += this.ElementOnMouseUp;
                element.LostMouseCapture += Element_LostMouseCapture;
            }

            private void Element_LostMouseCapture(object sender, MouseEventArgs e)
            {
                
            }

            private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
            {
                if (!(e is MouseButtonEventArgs mouseArg))
                { 
                    return;
                }

                if (!(sender is FrameworkElement element))
                {
                    return;
                }

                if (object.ReferenceEquals(element, this._element) == false)                
                { 
                    return;
                }

                this._isCaptured = true;

                this._originPoint = mouseArg.GetPosition(this._parent);

                var (left, top) = this.GetElementPosition(element);
                this._originPoint.X -= left;
                this._originPoint.Y -= top;

                element.CaptureMouse();

                Debug.WriteLine($"[shwlee] 1111~~~~~~~~~~~~ element:{this._element.GetHashCode()}, IsCaptured:{this._isCaptured}, Mosue:{this._element.IsMouseCaptured}");
            }

            //private void ElementOnMouseDown(object sender, MouseButtonEventArgs e)
            //{
            //    if (!(sender is FrameworkElement element))
            //    {
            //        return;
            //    }

            //    this._isCaptured = true;

            //    this._originPoint = e.GetPosition(this._parent);


            //    var (left, top) = this.GetElementPosition(element);
            //    this._originPoint.X -= left;
            //    this._originPoint.Y -= top;

            //    element.CaptureMouse();
            //}

            private (double, double) GetElementPosition(FrameworkElement element)
            {
                var left = Canvas.GetLeft(element);
                left = left == double.NaN ? 0 : left;
                var top = Canvas.GetTop(element);
                top = top == double.NaN ? 0 : top;

                return (left, top);
            }

            private void ElementOnMouseMove(object sender, MouseEventArgs e)
            {
                if (this._isCaptured == false)
                {
                    return;
                }

                var position = e.GetPosition(this._parent);

                var x = position.X - this._originPoint.X;
                var y = position.Y - this._originPoint.Y;

                InCanvasMovingBehavior.SetX(this._element, x);
                InCanvasMovingBehavior.SetY(this._element, y);


                Debug.WriteLine($"[shwlee] 222~~~~~~~~~~~~ element:{this._element.GetHashCode()}, IsCaptured:{this._isCaptured}, Mosue:{this._element.IsMouseCaptured}");
            }

            private void ElementOnMouseUp(object sender, MouseButtonEventArgs e)
            {
                if (!(sender is FrameworkElement element))
                {
                    return;
                }

                this._isCaptured = false;

                element.ReleaseMouseCapture();
            }
        }
    }
}
