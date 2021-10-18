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
        /// 
        public IPropertySet Id { get; }

        public IPropertySet Name { get; }

        public IPropertySet NameSize { get; }

        public IPropertySet NameColor { get; }

        public IPropertySet IsNameShow { get; }

        public IPropertySet Body { get; }

        public IPropertySet BodySize { get; }

        public IPropertySet BodyColor { get; }

        public IPropertySet IsBodyShow { get; }

        public IPropertySet Group { get; }

        public IPropertySet ZLevel { get; }

        public IPropertySet Width { get; }

        public IPropertySet Height { get; }

        public IPropertySet ShapeAngle { get; }

        public IPropertySet X { get; set; }

        public IPropertySet Y { get; set; }

        public IPropertySet IsLocationShow { get; set; }

        public IPropertySet FillColor { get; }

        public IPropertySet BorderColor { get; }

        public IPropertySet BorderThickness { get; }

        public IPropertySet ToolTip { get; }

        /// <summary>
        /// _categories 
        /// </summary>
        protected List<IPropertyCategory> _categories = new List<IPropertyCategory>();

        /// <summary>
        /// BaseShapeViewModel의 생성자 오버라이딩으로
        /// model을 인자로 받게 된다.
        /// 구조적으로 Parent의 역할을 하게되고
        /// 자식 ViewModel이 해당 메소드나 생성자를 가져다
        /// 사용할 수 있도록 구현함.
        /// </summary>
        /// <param name="model"></param>
        protected BaseShapeViewModel(BaseModel model)
        {
            this._model = model;

            //왜 이렇게 처리하는지 이해가 안됨.
            this.Id = new IntPropertySet(nameof(this.Id), () => model.Id, id => model.Id = id);
            
            this.Name = new StringPropertySet(nameof(this.Name), () => model.Name, name => model.Name = name);

            this.NameColor = new ColorPropertySet(nameof(this.NameColor), () => model.NameColor, nameColor => model.NameColor = nameColor);

            this.NameSize = new IntPropertySet(nameof(this.NameSize), () => model.NameSize, size => model.NameSize = size);

            this.IsNameShow = new BoolPropertySet(nameof(this.IsNameShow), () => model.IsNameShow, showName => model.IsNameShow = showName);

            this.Body = new StringPropertySet(nameof(this.Body), () => model.Body, body => model.Body = body);

            this.BodyColor = new ColorPropertySet(nameof(this.BodyColor), () => model.BodyColor, bodyColor => model.BodyColor = bodyColor);

            this.BodySize = new IntPropertySet(nameof(this.BodySize), () => model.BodySize, size => model.BodySize = size);

            this.IsBodyShow = new BoolPropertySet(nameof(this.IsBodyShow), () => model.IsBodyShow, showBody => model.IsBodyShow = showBody);


            this.Group = new IntPropertySet(nameof(this.Group), () => model.Group, group => model.Group = group);

            this.Width = new DoublePropertySet(nameof(this.Width), ()=> model.Width, width => model.Width = width) ;
            this.Height = new DoublePropertySet(nameof(this.Height), () => model.Height, height => model.Height = height);
            this.ShapeAngle = new DoublePropertySet(nameof(this.ShapeAngle), () => model.ShapeAngle, shapeAngle => model.ShapeAngle = shapeAngle);

            this.X = new DoublePropertySet(nameof(this.X), () => model.X, x => model.X = x);
            this.Y = new DoublePropertySet(nameof(this.Y), () => model.Y, y => model.Y = y);
            this.ZLevel = new IntPropertySet(nameof(this.ZLevel), () => model.ZLevel, level => model.ZLevel = level);
            this.IsLocationShow = new BoolPropertySet(nameof(this.IsLocationShow), ()=> model.isLocationShow, location => model.isLocationShow = location);

            this.FillColor = new ColorPropertySet(nameof(this.FillColor), () => model.FillColor, fill => model.FillColor = fill);
            this.BorderColor = new ColorPropertySet(nameof(this.BorderColor), () => model.BorderColor, bc => model.BorderColor = bc);
            this.BorderThickness = new DoublePropertySet(nameof(this.BorderThickness), () => model.BorderThickness, bt => model.BorderThickness = bt);
            this.ToolTip = new StringPropertySet(nameof(this.ToolTip), () => model.ToolTip, tip => model.ToolTip = tip);

            this.InitBaseCategories();
        }

        /// <summary>
        /// Category 구성을 등록하고 초기화 하는 메소드
        /// 주로 BaseModel을 근간으로 하는 속성과 카테고리임
        /// </summary>
        private void InitBaseCategories()
        {

            var data = new PropertyCategory("Data");
            data.Properties.Add(new PropertyContainer(this.Id, data));
            data.Properties.Add(new PropertyContainer(this.Group, data));
            this._categories.Add(data);

            var content = new PropertyCategory("Content");
            data.Properties.Add(new PropertyContainer(this.Name, content));
            data.Properties.Add(new PropertyContainer(this.NameSize, content));
            data.Properties.Add(new PropertyContainer(this.NameColor, content));
            data.Properties.Add(new PropertyContainer(this.IsNameShow, content));
            data.Properties.Add(new PropertyContainer(this.Body, content));
            data.Properties.Add(new PropertyContainer(this.BodySize, content));
            data.Properties.Add(new PropertyContainer(this.BodyColor, content));
            data.Properties.Add(new PropertyContainer(this.IsBodyShow, content));
            this._categories.Add(content);

            var size = new PropertyCategory("Size");
            size.Properties.Add(new PropertyContainer(this.Width, size));
            size.Properties.Add(new PropertyContainer(this.Height, size));
            size.Properties.Add(new PropertyContainer(this.ShapeAngle, size));
            this._categories.Add(size);

            var location = new PropertyCategory("Location");
            location.Properties.Add(new PropertyContainer(this.X, location));
            location.Properties.Add(new PropertyContainer(this.Y, location));
            location.Properties.Add(new PropertyContainer(this.IsLocationShow, location));
            size.Properties.Add(new PropertyContainer(this.ZLevel, location));
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

        /// <summary>
        /// IEnumerable의 용법도 아직 잘 이해가 안됨..ㅠㅠ
        /// Collection Type으로 넘겨줄수 있다 정도???
        /// 그래서 이걸 List<IPropertyCategory>가 받을 수 있다??
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPropertyCategory> GetCategories()
        {
            return this._categories.ToList();
        }
    }
}
