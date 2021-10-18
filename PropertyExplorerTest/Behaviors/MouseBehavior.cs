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

namespace PropertyExplorerTest.Behaviors
{
    public class MouseBehavior : Behavior<Panel>
    {
        public static readonly DependencyProperty MouseYProperty = DependencyProperty.Register(
           "MouseY", typeof(double), typeof(MouseBehavior), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty MouseXProperty = DependencyProperty.Register(
           "MouseX", typeof(double), typeof(MouseBehavior), new PropertyMetadata(default(double)));

        public double MouseY
        {
            get { return (double)GetValue(MouseYProperty); }
            set { SetValue(MouseYProperty, value); }
        }

        public double MouseX
        {
            get { return (double)GetValue(MouseXProperty); }
            set { SetValue(MouseXProperty, value); }
        }

        protected override void OnAttached()
        {
            
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
            EventManager.RegisterClassHandler(typeof(ListBox), ListBox.MouseRightButtonDownEvent, new RoutedEventHandler(CanvasMouseButtonDown));

        }

        private void CanvasMouseButtonDown(object sender, RoutedEventArgs e)
        {
            MouseButtonEventArgs arg = e as MouseButtonEventArgs;
            Point curPoint = arg.GetPosition(AssociatedObject);

            Debug.WriteLine($"MouseBehavior CanvasMouseButtonDown:{curPoint.X}, {curPoint.Y}");
            MouseX = curPoint.X;
            MouseY = curPoint.Y;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
        }

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {

            var pos = mouseEventArgs.GetPosition(AssociatedObject);
            MouseX = pos.X;
            MouseY = pos.Y;
        }
    }
}
