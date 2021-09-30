using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace PropertyExplorerTest.ViewModels.Behaviors
{
    public class InCanvasMovingBehavior : Behavior<FrameworkElement>
    {

        private bool _isCaptured;

        /// <summary>
        /// 마우스 다운 위치로부터 오브젝트의 좌상단을 보정하기 위한 포인트.
        /// </summary>
        private Point _originPoint;

        private Canvas _parent;

        protected override void OnAttached()
        {
            var element = AssociatedObject;
            this._parent = FindParentOfType<Canvas>(element);
            if (this._parent == null)
            {
                // 부모 Canvas 를 못찾으면 실행하지 않는다.
                return;
            }

            AssociatedObject.MouseDown += AssociatedObjectOnMouseDown;
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
            AssociatedObject.MouseUp += AssociatedObjectOnMouseUp;
        }

        private void AssociatedObjectOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this._isCaptured = true;

            var element = AssociatedObject;
            this._originPoint = e.GetPosition(this._parent);


            Debug.WriteLine($"[shwlee1] ~~~~~~~~~~~~~~~~~ {this._originPoint}");

            var (left, top) = this.GetElementPosition(element);
            this._originPoint.X -= left;
            this._originPoint.Y -= top;

            element.CaptureMouse();
        }

        private (double, double) GetElementPosition(FrameworkElement element)
        {
            var left = Canvas.GetLeft(element);
            left = left == double.NaN ? 0 : left;
            var top = Canvas.GetTop(element);
            top = top == double.NaN ? 0 : top;
            return (left, top);
        }

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs e)
        {
            if (this._isCaptured == false)
            {
                return;
            }

            var element = AssociatedObject;
            var position = e.GetPosition(this._parent);


            Canvas.SetLeft(element, position.X - this._originPoint.X);
            Canvas.SetTop(element, position.Y - this._originPoint.Y);

            Debug.WriteLine($"[shwlee2] ~~~~~~~~~~~~~~~~~ {position.X}, {position.Y}");

        }

        private void AssociatedObjectOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            this._isCaptured = false;

            var element = AssociatedObject;
            element.ReleaseMouseCapture();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseDown -= AssociatedObjectOnMouseDown;
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
            AssociatedObject.MouseUp -= AssociatedObjectOnMouseUp;

            this._parent = null;
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
    }
}
