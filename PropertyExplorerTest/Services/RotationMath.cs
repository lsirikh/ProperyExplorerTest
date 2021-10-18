using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Services
{
    public static class RotationMath
    {

        public static double GetWidth(double a, double w, double h)
        {
            double angle = a;
            double width = w;
            double height = h;


            if (angle == 0.0)
            {
                Debug.WriteLine($"calWidth : {width}");
                return width;
            }
            else
            {
                //init
                double calWidth = 0.0;
                double calHeight = 0.0;
                double criteria = a;

                //라디안 변환
                double cos = Math.Abs(Math.Cos(angle * (Math.PI / 180)));
                double sin = Math.Abs(Math.Sin(angle * (Math.PI / 180)));

                calHeight = 2 * ((0.5 * height * cos) + (0.5 * width * sin));
                calWidth = 2 * ((0.5 * width * cos) + (0.5 * height * sin));
                Debug.WriteLine($"calWidth({calWidth}) = 2 * ((0.5 * {width} * {cos}) + (0.5 * {height} * {sin}))");
                
                return calWidth;
            }
        }

        public static double GetHeight(double a, double w, double h)
        {
            double angle = a;
            double width = w;
            double height = h;


            if (angle == 0.0)
            {
                Debug.WriteLine($"calHeight : {height}");
                return height;
            }
            else
            {
                //init
                double calWidth = 0.0;
                double calHeight = 0.0;
                double criteria = a;

                //라디안 변환
                double cos = Math.Abs(Math.Cos(angle * (Math.PI / 180)));
                double sin = Math.Abs(Math.Sin(angle * (Math.PI / 180)));

                calHeight = 2 * ((0.5 * height * cos) + (0.5 * width * sin));
                calWidth = 2 * ((0.5 * width * cos) + (0.5 * height * sin));
                Debug.WriteLine($"calHeight({calHeight}) = 2 * ((0.5 * {height} * {cos}) + (0.5 * {width} * {sin}))");

                return calHeight;
            }
        }
    }
}
