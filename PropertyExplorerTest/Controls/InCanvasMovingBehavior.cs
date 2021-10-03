using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PropertyExplorerTest.Behaviors
{
    public class InCanvasMovingBehavior : DependencyObject
    {

        #region AttachedProperty 일명 AP 사용법
        /*
         *  DependencyProperty RegisterAttached용 설정 방법 예시

        public static readonly DependencyProperty MouseMoveProperty =
            DependencyProperty.RegisterAttached(
                name: "MouseMove", 
                propertyType: typeof(int), 
                ownerType: typeof(InCanvasMovingBehavior),
                defaultMetadata: new FrameworkPropertyMetadata(false, CaptureFromContianerCallback)
            );

        public int MouseMove
        {
            get { return (int)GetValue(MouseMoveProperty); }
            set { SetValue(MouseMoveProperty, value); }
        }
        하기 두 메소드는 상기 public int MouseMove의 메소드와
        같은 의미를 한다. 보통 DependencyPropery.Register로는 
        여기까지가 맞는것 같은데 DependencyProperty.RegisterAttached 
        이기 때문에 아래와 같은 메소드를 사용하는지 정확하진 않다.

        public static int GetMouseMove(DependencyObject obj)
        {
            return (int)obj.GetValue(MouseMoveProperty);
        }

        public static void SetMouseMove(DependencyObject obj, int vaule)
        {
            obj.SetValue(MouseMoveProperty, vaule);
        }

        */

        #endregion

        

        #region Attached Property 등록 Capture, Panning, X, Y
        /// <summary>
        /// DependencyProperty 등록을 통한 Xaml접근이 가능해진다.
        /// 정확하게 사용할 수 있는 컨트롤에 적용해야(같은 속성이나 타입이 있는 컨트롤) 
        /// 정상동작하는것은 당연한 얘기 겠지만...
        /// </summary>
        public static readonly DependencyProperty CapturedProperty = DependencyProperty.RegisterAttached
        (
            name: "Captured",
            propertyType: typeof(bool),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(false, CaptureFromContianerCallback)
        );

        /// <summary>
        /// CapturedProperty 용 Callback
        /// </summary>
        /// <param name="d">ViewModel이 넘어올 것이고,</param>
        /// <param name="e">New Selection이 있는 지 없는 지, NewValue로 볼 것</param>
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

        /// <summary>
        /// get { return (bool)GetValue(CaputreProperty);}
        /// 같은 의미이다.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetCaptured(DependencyObject obj)
        {
            return (bool)obj.GetValue(CapturedProperty);
        }
        /// <summary>
        /// set { SetValue(CapturedProperty, value); }
        /// 같은 의미이다.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetCaptured(DependencyObject obj, bool value)
        {
            obj.SetValue(CapturedProperty, value);
        }


        /// <summary>
        /// PanningTargetProperty AP 등록
        /// </summary>
        public static readonly DependencyProperty PanningTargetProperty = DependencyProperty.RegisterAttached
        (
            name: "PanningTarget",
            propertyType: typeof(FrameworkElement),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(null, PanningTargetPropertyChanged)
        );

        /// <summary>
        /// PanningTargetProperty의 Callback
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void PanningTargetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is FrameworkElement element))
            {
                return;
            }

            // 필요시 따로 보관한다.
            var infra = new PanningStructure(element);
        }

        /// <summary>
        /// Getter for Panning
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static FrameworkElement GetPanningTarget(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(PanningTargetProperty);
        }

        /// <summary>
        /// Setter for Panning
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetPanningTarget(DependencyObject obj, object value)
        {
            obj.SetValue(PanningTargetProperty, value);
        }

        /// <summary>
        /// XProperty AP 등록
        /// </summary>
        public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached
        (
            name: "X",
            propertyType: typeof(double),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PositinChangedCallback)
        );

        /// <summary>
        /// XProperty CallbackFunction은 할게 없나보네...
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void PositinChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        /// <summary>
        /// Getter for XProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetX(DependencyObject obj)
        {
            return (double)obj.GetValue(XProperty);
        }
        /// <summary>
        /// Setter for XProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetX(DependencyObject obj, object value)
        {
            obj.SetValue(XProperty, value);
        }

        /// <summary>
        /// YProperty AP 등록
        /// </summary>
        public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached
        (
            name: "Y",
            propertyType: typeof(double),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PositinChangedCallback)
        );

        /// <summary>
        /// Getter for YProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetY(DependencyObject obj)
        {
            return (double)obj.GetValue(YProperty);
        }

        /// <summary>
        /// Setter for YProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetY(DependencyObject obj, object value)
        {
            obj.SetValue(YProperty, value);
        }



        public static int GetZLevel(DependencyObject obj)
        {
            return (int)obj.GetValue(ZLevelProperty);
        }

        public static void SetZLevel(DependencyObject obj, int value)
        {
            obj.SetValue(ZLevelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Z.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZLevelProperty = DependencyProperty.RegisterAttached
        (
            name: "ZLevel",
            propertyType: typeof(int),
            ownerType: typeof(InCanvasMovingBehavior),
            defaultMetadata: new FrameworkPropertyMetadata((int)100, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PositinChangedCallback)
        );



        #endregion

        /// <summary>
        /// 엄마 찾아 삼만리....
        /// </summary>
        /// <typeparam name="T">원하는 엄마</typeparam>
        /// <param name="child">나는 그의 자식</param>
        /// <returns></returns>
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

            private bool _isZTop = false;

            private int _savedZLevel;

            private const int MAX_LEVEL = 255;

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
                    if (this._isZTop)
                        this.SetZLevelRevert();
                    return;
                }

                //InCanvasMovingBehavior.SetZLevel(this._element, this.GetZIndex(element) - 100);
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
                    if (this._isZTop)
                        this.SetZLevelRevert();

                    return;
                }

                this._isCaptured = true;

                this._originPoint = mouseArg.GetPosition(this._parent);

                var (left, top) = this.GetElementPosition(element);

                if (!this._isZTop)
                    this.SetTopLevel(this._element);

                //var z = this.GetZIndex(element);
                this._originPoint.X -= left;
                this._originPoint.Y -= top;
                
                //Temporally Set Z index to Highest Layer
                //this._parent.

                element.CaptureMouse();

                Debug.WriteLine($"[shwlee] 1111~~~~~~~~~~~~ element:{this._element.GetHashCode()}, IsCaptured:{this._isCaptured}, Mosue:{this._element.IsMouseCaptured}");
            }

            private void SetZLevelRevert()
            {
                InCanvasMovingBehavior.SetZLevel(this._element, this._savedZLevel);

                this._isZTop = false;
            }

            private void SetTopLevel(FrameworkElement element)
            {
                this._savedZLevel = this.GetZIndex(element);

                //Init Setting For ZLevel AttachedProperty
                InCanvasMovingBehavior.SetZLevel(this._element, MAX_LEVEL);
                

                this._isZTop = true;
            }

            /// <summary>
            /// ZIndex 가져와서 _savedZLevel에 저장
            /// </summary>
            /// <param name="element"></param>
            /// <returns></returns>
            private int GetZIndex(FrameworkElement element)
            {
                this._savedZLevel = Canvas.GetZIndex(element);
                //Canvas.SetZIndex(element);
                this._savedZLevel = this._savedZLevel == 0 ? 0 : this._savedZLevel;

                return this._savedZLevel;
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
