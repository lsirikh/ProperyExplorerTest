using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace PropertyExplorerTest.Controls
{
    public class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb)
            {
                Thumb thumb = (Thumb)sender;
                //IPropertySet myRectangle = (IPropertySet)thumb.DataContext;
                //myRectangle.X += e.HorizontalChange;
                //myRectangle.Y += e.VerticalChange;
            }
        }
    }
}
