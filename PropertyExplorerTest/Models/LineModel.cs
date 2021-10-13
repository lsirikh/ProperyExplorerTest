using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models
{
    public class LineModel : BaseModel
    {
        //선을 이루는 데 2개의 점이 필요하다.
        //1에 해당하는 것이 Point1
        //2에 해당하는 것이 Point2
        //
        //  (X1,Y1)*\
        //           \
        //            \*(X2, Y2)

        public double X1 { get; set; } = 10;

        public double Y1 { get; set; } = 50;

        public double X2 { get; set; } = 90;

        public double Y2 { get; set; } = 50;


        #region 생성자 및 생성자 오버라이딩
        public LineModel()
        {
        }

        public LineModel(double x, double y) : base(x, y)
        {
        }

        public LineModel(double w, double h, double x, double y) : base(w, h, x, y)
        {
        }
        #endregion
    }
}
