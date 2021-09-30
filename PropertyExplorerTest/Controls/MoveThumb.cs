using PropertyExplorerTest.Defines.Interfaces;
using PropertyExplorerTest.Models;
using PropertyExplorerTest.Models.PropertyModels;
using PropertyExplorerTest.ViewModels.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace PropertyExplorerTest.Controls
{
    public class MoveThumb : Thumb
    {

        public static readonly DependencyProperty XProperty = DependencyProperty.Register
        (
            name: nameof(X),
            propertyType: typeof(double),
            ownerType: typeof(MoveThumb),
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
            ownerType: typeof(MoveThumb),
            typeMetadata: new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public double Y
        {
            get => (double)GetValue(YProperty);
            set => SetValue(YProperty, value);
        }

        static MoveThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MoveThumb), new FrameworkPropertyMetadata(typeof(MoveThumb)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (!(sender is MoveThumb control))
            {
                return;
            }

            control.X += e.HorizontalChange;
            control.Y += e.VerticalChange;
        }


        /*public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb)
            {
                Thumb thumb = (Thumb)sender;
                BaseShapeViewModel model = (BaseShapeViewModel)thumb.DataContext;
                model.X.Set(model.X.Get<double>() + e.HorizontalChange);
                model.Y.Set(model.Y.Get<double>() + e.VerticalChange);

            }
        }*/
    }
}
