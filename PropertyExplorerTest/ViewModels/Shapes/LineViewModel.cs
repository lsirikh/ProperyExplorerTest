using PropertyExplorerTest.Defines.Interfaces;
using PropertyExplorerTest.Models;
using PropertyExplorerTest.Models.PropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.ViewModels.Shapes
{
    public class LineViewModel : BaseShapeViewModel
    {
        public IPropertySet X1 { get; }

        public IPropertySet X2 { get; }

        public IPropertySet Y1 { get; }

        public IPropertySet Y2 { get; }

        public LineViewModel(BaseModel model) : base(model)
        {
            var lineModel = (LineModel)this._model;

            this.X1 = new DoublePropertySet(nameof(this.X1), () => lineModel.X1, x => lineModel.X1 = x);
            this.X2 = new DoublePropertySet(nameof(this.X2), () => lineModel.X2, x => lineModel.X2 = x);
            this.Y1 = new DoublePropertySet(nameof(this.Y1), () => lineModel.Y1, y => lineModel.Y1 = y);
            this.Y2 = new DoublePropertySet(nameof(this.Y2), () => lineModel.Y2, y => lineModel.Y2 = y);

            var position = new PropertyCategory("Position");
            position.Properties.Add(new PropertyContainer(this.X1, position));
            position.Properties.Add(new PropertyContainer(this.X2, position));
            position.Properties.Add(new PropertyContainer(this.Y1, position));
            position.Properties.Add(new PropertyContainer(this.Y2, position));
            this._categories.Add(position);
        }
    }


}
