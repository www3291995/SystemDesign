using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.Point_Example
{
    class Point_Example
    {
    }

    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private double x, y;

        /// <summary>
        /// Initial point 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="system"></param>
        public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            //this.x = x;
            //this.y = y;
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }

        //cannot do this
        //public Point(double rho, double theta)
        //{

        //}
    }
}
