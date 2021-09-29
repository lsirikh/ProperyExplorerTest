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
    public abstract class BaseShapeViewModel : BaseViewModel, IPropertyOperative
    {
        /// <summary>
        /// 공통속성을 갖는 BaseModel을 등록한다.
        /// 기본적으로 _model을 protected로 선언한 것은
        /// 자식 클래스로 활용하겠다는 의도
        /// </summary>
        protected BaseModel _model;

        /// <summary>
        /// IPropertySet으로 설정된 하기 필드 들은
        /// Generic 타입을 활용하여 클래스간 Loosely-Coupled
        /// 구조를 가져가기 위한 조치로 보임
        /// </summary>
        public IPropertySet Width { get; }

        public IPropertySet Height { get; }

        public IPropertySet X { get; }

        public IPropertySet Y { get; }

        public IPropertySet FillColor { get; }

        public IPropertySet BorderColor { get; }

        public IPropertySet BorderThickness { get; }

        public IPropertySet ToolTip { get; }

        /// <summary>
        /// _categories 역시 
        /// </summary>
        protected List<IPropertyCategory> _categories = new List<IPropertyCategory>();

        protected BaseShapeViewModel(BaseModel model)
        {
            this._model = model;

            this.Width = new DoublePropertySet(nameof(this.Width), ()=> model.Width, w => model.Width = w) ;
            this.Height = new DoublePropertySet(nameof(this.Height), () => model.Height, h => model.Height = h);
            this.X = new DoublePropertySet(nameof(this.X), () => model.X, x => model.X = x);
            this.Y = new DoublePropertySet(nameof(this.Y), () => model.Y, y => model.Y = y);
            this.FillColor = new ColorPropertySet(nameof(this.FillColor), () => model.FillColor, f => model.FillColor = f);
            this.BorderColor = new ColorPropertySet(nameof(this.BorderColor), () => model.BorderColor, bc => model.BorderColor = bc);
            this.BorderThickness = new DoublePropertySet(nameof(this.BorderThickness), () => model.BorderThickness, bt => model.BorderThickness = bt);
            this.ToolTip = new StringPropertySet(nameof(this.ToolTip), () => model.ToolTip, t => model.ToolTip = t);

            this.InitBaseCategories();
        }

        /// <summary>
        /// Category 구성을 등록하고 초기화 하는 메소드
        /// </summary>
        private void InitBaseCategories()
        {
            
            var size = new PropertyCategory("Size");
            size.Properties.Add(new PropertyContainer(this.Width, size));
            size.Properties.Add(new PropertyContainer(this.Height, size));
            this._categories.Add(size);

            var location = new PropertyCategory("Location");
            location.Properties.Add(new PropertyContainer(this.X, location));
            location.Properties.Add(new PropertyContainer(this.Y, location));
            this._categories.Add(location);

            var color = new PropertyCategory("Color");
            color.Properties.Add(new PropertyContainer(this.FillColor, color, "Fill"));
            color.Properties.Add(new PropertyContainer(this.BorderColor, color, "Border"));
            color.Properties.Add(new PropertyContainer(this.BorderThickness, color));
            this._categories.Add(color);

            var toolTip = new PropertyCategory("ToolTip");
            toolTip.Properties.Add(new PropertyContainer(this.ToolTip, toolTip));
            this._categories.Add(toolTip);

        }

        public IEnumerable<IPropertyCategory> GetCategories()
        {
            return this._categories.ToList();
        }
    }
}
