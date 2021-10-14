using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models
{
    /// <summary>
    /// BaseModel에 다 있어서 딱히 아직
    /// EllipseModel에 정의할게 없다.
    /// </summary>
    public class EllipseModel : BaseModel
    {
        #region 생성자 및 생성자 오버라이딩
        public EllipseModel()
        {
        }

        public EllipseModel(double x, double y) : base(x, y)
        {
        }

        public EllipseModel(double w, double h, double x, double y) : base(w, h, x, y)
        {
        }
        #endregion
    }
}
