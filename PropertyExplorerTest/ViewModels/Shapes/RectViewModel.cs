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
    public class RectViewModel : BaseShapeViewModel
    {
        /// <summary>
        /// 왜 IPropertySet의 타입으로 RadiusX와 RadiusY를
        /// 설정했을까?
        /// 기본적으로 어떤 형식이든 다 받을 수 있는 Generic Type
        /// 이지만 여기서는 Double 형식을 사용한다.
        /// </summary>
        public IPropertySet RadiusX { get; }

        public IPropertySet RadiusY { get; }

        /// <summary>
        /// RectViewModel은 먼저 base(Parent)의 ctor를 생성하고
        /// 추가적으로 생성하는 과정을 코드로 구현한 것.
        /// </summary>
        /// <param name="model"></param>
        public RectViewModel(BaseModel model): base(model)
        {
            var rectModel = (RectModel)this._model;

            //this.RadiusX의 타입을 확정지어주는 생성자를 할당한다.
            // nameof 식은 변수, 형식 또는 멤버의 이름을 문자열 상수로 가져옵니다 
            this.RadiusX = new DoublePropertySet(nameof(this.RadiusX), () => rectModel.RadiusX, x => rectModel.RadiusX = x);
            this.RadiusY = new DoublePropertySet(nameof(this.RadiusY), () => rectModel.RadiusY, y => rectModel.RadiusY = y);

            var corner = new PropertyCategory("Corner");
            corner.Properties.Add(new PropertyContainer(this.RadiusX, corner));
            corner.Properties.Add(new PropertyContainer(this.RadiusY, corner));
            this._categories.Add(corner);


        }

    }
}
