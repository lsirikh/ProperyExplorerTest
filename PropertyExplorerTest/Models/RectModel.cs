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
        public double RadiusX { get; set; }

        public double RadiusY { get; set; }


        public RectModel() : base()
        {

        }

        public RectModel(double x, double y) : base(x, y)
        {
            
        }

        public RectModel(double w, double h, double x, double y) : base(w, h, x, y)
        {
        }
    }
}
