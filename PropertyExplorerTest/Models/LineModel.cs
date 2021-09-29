using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models
{
    public class LineModel : BaseModel
    {
        public double X1 { get; set; } = 10;

        public double X2 { get; set; } = 90;

        public double Y1 { get; set; } = 50;

        public double Y2 { get; set; } = 50;

        public LineModel()
        {

        }

        public LineModel(double x, double y) : base(x, y)
        {

        }

        public LineModel(double w, double h, double x, double y) : base(w, h, x, y)
        {

        }

    }
}
