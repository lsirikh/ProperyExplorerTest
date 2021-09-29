using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PropertyExplorerTest.Models
{
    public class BaseModel
    {
        public double Width { get; set; } = 100;

        public double Height { get; set; } = 100;

        public double X { get; set; } 

        public double Y { get; set; } 

        public Color FillColor { get; set; } = Color.FromRgb(0xff, 0x00, 0x00);

        public Color BorderColor { get; set; } = Color.FromRgb(0x24, 0x00, 0xff);

        public double BorderThickness { get; set; } = 1;

        public string ToolTip { get; set; }

        public BaseModel()
        {

        }

        public BaseModel(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public BaseModel(double w, double h, double x, double y)
        {
            this.Width = w;
            this.Height = h;

            this.X = x;
            this.Y = y;
        }

    }
}
