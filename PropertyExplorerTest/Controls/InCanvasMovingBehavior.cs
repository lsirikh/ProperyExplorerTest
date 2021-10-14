using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        #region InCanvasMovingBehavior Field
        //멀티셀렉팅을 위한 Collection Type의 변수 선언
        private static List<ElementControl> _selectedList = new List<ElementControl>();

        private static ElementControl _curElementControl;

        private static Point _refPoint;

        private static bool _isRemoved;

        
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
            Debug.WriteLine($"infra was created");
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


        public class PanningStructure 
        {


            private bool _isCaptured;

            private bool _isZTop = false;

            private bool _isOnCavasClicked = false;

            private int _savedZLevel;

            private const int MAX_LEVEL = 255;

            /// <summary>
            /// 마우스 다운 위치로부터 오브젝트의 좌상단을 보정하기 위한 포인트.
            /// </summary>
            //private Point _originPoint;

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


                EventManager.RegisterClassHandler(typeof(ListBox), ListBox.MouseLeftButtonDownEvent, new RoutedEventHandler(CanvasMouseButtonDown));

                EventManager.RegisterClassHandler(typeof(ListBox), ListBox.MouseLeftButtonUpEvent, new RoutedEventHandler(CanvasMouseButtonUp));

                EventManager.RegisterClassHandler(typeof(ListBox), ListBox.MouseRightButtonDownEvent, new RoutedEventHandler(CanvasMouseButtonDown));

                EventManager.RegisterClassHandler(typeof(ListBox), ListBox.MouseRightButtonUpEvent, new RoutedEventHandler(CanvasMouseButtonUp));


                EventManager.RegisterClassHandler(typeof(ListBoxItem), ListBoxItem.MouseLeftButtonDownEvent, new RoutedEventHandler(this.OnMouseLeftButtonDown));


                //element.MouseDown += this.ElementOnMouseDown;
                element.MouseMove += this.ElementOnMouseMove;
                element.MouseUp += this.ElementOnMouseUp;
                element.LostMouseCapture += Element_LostMouseCapture;
            }
                        

            private void CanvasMouseButtonDown(object sender, RoutedEventArgs e)
            {
                _isOnCavasClicked = true;
            }

            private void CanvasMouseButtonUp(object sender, RoutedEventArgs e)
            {
                if (_isOnCavasClicked)
                {
                    var sv = sender as ListBox;
                    sv.UnselectAll();
                    _selectedList.Clear();
                    _refPoint = new Point();
                    //Debug.WriteLine($"SelectedList : {_selectedList.Count} ea");
                    _isOnCavasClicked = false;
                }
                
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
                    
                    return;
                }

                //InCanvasMovingBehavior.SetZLevel(this._element, this.GetZIndex(element) - 100);
            }

            private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
            {

                //e가 null이 아닌경우 MouseButtonEventArgs인 mouseArg로 캐스팅
                if (!(e is MouseButtonEventArgs mouseArg))
                { 
                    return;
                }

                //sender가 null이 아닌경우 FrameworkElement element 캐스팅
                if (!(sender is FrameworkElement element))
                {
                    return;
                }
                
                //전체 캔버스에 올라간 오브젝트 만큼 반복하기 때문에
                //선택한 오브젝트 이외에 다른 오브젝트는 무시
                if (object.ReferenceEquals(element, this._element) == false)
                {
                    return;
                }

                //ElementControl을 만들때, element가 존재하는지 확인하고,
                //만들어야 한다.

                ElementControl elementControl = new ElementControl(element);
                
                foreach (var item in _selectedList)
                {
                    if (item.selectedItem == element)
                    {
                        elementControl = item;
                        break;
                    }
                }
                Debug.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    //_selectedList 검증 프로세스
                    if (_selectedList.Contains(elementControl))
                    {
                        Debug.WriteLine($"{elementControl.selectedItem}({elementControl.selectedItem.GetHashCode()}) is contained and removed");
                        _selectedList.Remove(elementControl);
                        _isRemoved = true;
                    }
                    else
                    {
                        Debug.WriteLine($"{elementControl.selectedItem}({elementControl.selectedItem.GetHashCode()}) is not contained and added");
                        _selectedList.Add(elementControl);
                    }
                }
                else
                {
                    _selectedList.Clear();
                    _selectedList.Add(elementControl);
                    Debug.WriteLine($"{_selectedList.FirstOrDefault().selectedItem}({elementControl.selectedItem.GetHashCode()}) was added first");
                }

                Debug.WriteLine($"SelectedList : {_selectedList.Count} ea");
                Debug.WriteLine("---------------------------------------------------");
                (_refPoint.X, _refPoint.Y) = GetElementPosition(element);

                foreach (var item in _selectedList.Select((value, index) => (value, index)))
                {
                    item.value.isCaptured = true;
                    if ((item.index == _selectedList.Count - 1) && _isRemoved)
                    {
                        item.value.selectedItem.CaptureMouse();
                    }
                }

                if (!_isRemoved)
                {
                    elementControl.isCaptured = true;

                    elementControl.originPoint = mouseArg.GetPosition(this._parent);

                    (elementControl.left, elementControl.top) = GetElementPosition(element);

                    elementControl.originPoint.X -= elementControl.left;
                    elementControl.originPoint.Y -= elementControl.top;

                    _curElementControl = elementControl;

                    //Debug.WriteLine($"==============> _refPoint.X : {_refPoint.X}, _refPoint.Y : {_refPoint.Y}");

                    elementControl.selectedItem.CaptureMouse();
                }
                
                #region Single Object Control
                /*
                 * 
                this._isCaptured = true;

                this._originPoint = mouseArg.GetPosition(this._parent);

                var (left, top) = this.GetElementPosition(element);

                if (!this._isZTop)
                    this.SetTopLevel(this._element);

                this._originPoint.X -= left;
                this._originPoint.Y -= top;

                Debug.WriteLine($"SelectedList : {_selectedList.Count} ea");

                element.CaptureMouse();

                Debug.WriteLine($"[shwlee] 1111~~~~~~~~~~~~ element:{this._element.GetHashCode()}, IsCaptured:{this._isCaptured}, Mouse:{this._element.IsMouseCaptured}");*/
                #endregion
            }

            private void ElementOnMouseMove(object sender, MouseEventArgs e)
            {
                if (_isRemoved)
                    return;
                
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    //상대적 위치 이동을 계산하기 위해서 sender로 넘어온
                    //최종 오브젝트의 좌표값을 확보하기 위해서 referElement 받아옴
                    FrameworkElement referElement = sender as FrameworkElement;

                    //현재 클릭된 대상을 위한 기준 Position
                    var position = e.GetPosition(this._parent);
                    
                    //기존에 클릭된 대상을 위한 reference position 상대적 위치 이동 값
                    (double refX, double refY) = GetElementPosition(referElement);

                    //Debug.WriteLine($"+++++++++++++Point X:{position.X }, Point Y:{position.Y}");
                    //Debug.WriteLine($"*************dx:{refX - _refPoint.X}, dy:{refY - _refPoint.Y}");

                    //최종적으로 Canvas좌표 입력에 활용할 필드
                    double x, y;

                    //_selectedList에 있는 ElementControl 인스턴스를 순차적으로 컨트롤
                    foreach (var item in _selectedList)
                    {
                        //item.isCaptured 조건이 만족하는 경우 실행
                        //Debug.WriteLine($"Type:{item.selectedItem.GetHashCode()}, isCapture:{item.isCaptured}, left:{item.left}, top:{item.top}, origin:{item.originPoint.X}, {item.originPoint.Y}");

                        if (item.isCaptured)
                        {
                            //마우스 포인터의 상대적움직임을 반영해야된다.
                            //Debug.WriteLine($"Move Item : {item.selectedItem}");
                            //Debug.WriteLine($"item.originPoint.X: {item.originPoint.X}, position.X: {position.X}, _refPoint.X: {_refPoint.X}");
                            
                            //서로 참조하는 기준이 다르기 때문에 
                            //마우스 포인터가 위치한 오브젝트와 선택만 된 오브젝트는
                            //서로 다르게 동작한다.
                            if (item.selectedItem == referElement)
                            {
                                //현재 클릭한 오브젝트의 위치를 움직인다.
                                //즉, position에 있는 값을 기반으로 위치이동 
                                x = position.X - item.originPoint.X;
                                y = position.Y - item.originPoint.Y;
                            }
                            else
                            {
                                //마우스 움직임 Delta 값을 찾아서 넣어준다.
                                //x = item.left + delta.x 이렇게 변경
                                x = item.left + (refX - _refPoint.X);
                                y = item.top + (refY - _refPoint.Y);
                            }

                            //최종적으로 Canvas위치에 의존된 AttachedProperty에 입력
                            InCanvasMovingBehavior.SetX(item.selectedItem, x);
                            InCanvasMovingBehavior.SetY(item.selectedItem, y);

                            //인스턴스 값에도 반영
                            item.left = x;
                            item.top = y;
                        }
                    }
                    //레퍼런스 포인트를 갱신해준다.
                    (_refPoint.X, _refPoint.Y) = (refX, refY);
                }

            }

            private void ElementOnMouseUp(object sender, MouseButtonEventArgs e)
            {
                if (!(sender is FrameworkElement element))
                {
                    return;
                }
                
                /*
                    if (this._isZTop)
                        this.SetZLevelRevert();
                */

                foreach (var item in _selectedList)
                {
                    item.isCaptured = false;
                    item.selectedItem.ReleaseMouseCapture();
                }

                if (_isRemoved)
                    _isRemoved = false;

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
                var z = Panel.GetZIndex(element);
                //var z = Canvas.GetZIndex(element);
                //Canvas.SetZIndex(element);
                z = z == 0 ? 0 : z;

                return z;
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

            
        }
        
    }

    public class ElementControl
    {
        public FrameworkElement selectedItem { get; set; }

        public bool isCaptured;

        public Point originPoint;

        public double left;
        public double top;

        public ElementControl(FrameworkElement item)
        {
            isCaptured = false;
            selectedItem = item;
            (left, top) = this.GetElementPosition(selectedItem);

        }

        private (double, double) GetElementPosition(FrameworkElement element)
        {
            var left = Canvas.GetLeft(element);
            left = left == double.NaN ? 0 : left;
            var top = Canvas.GetTop(element);
            top = top == double.NaN ? 0 : top;

            return (left, top);
        }

        public void UpdateElementPosition()
        {
            (left, top) = this.GetElementPosition(selectedItem);
        }

    }
}
