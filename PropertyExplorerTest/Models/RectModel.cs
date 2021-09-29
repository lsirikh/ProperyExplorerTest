using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models
{
    public class RectModel : BaseModel
    {
        /// <summary>
        /// 사각형의 모서리를 둥글게 할 수 있는 옵션
        /// </summary>
        public double RadiusX { get; set; }

        public double RadiusY { get; set; }


        #region 생성자 및 생성자 오버라이드
        public RectModel() : base()
        {
        }

        public RectModel(double x, double y) : base(x, y)
        {
        }

        public RectModel(double w, double h, double x, double y) : base(w, h, x, y)
        {
        }
        #endregion
    }
}
