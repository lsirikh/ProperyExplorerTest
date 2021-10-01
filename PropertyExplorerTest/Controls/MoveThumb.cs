using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PropertyExplorerTest.Controls
{
    // 사용 안 함.
    public class MoveThumb : Thumb
    {
        static MoveThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MoveThumb), new FrameworkPropertyMetadata(typeof(MoveThumb)));
        }

        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);
        //    e.Handled = false;
        //}
    }
}
