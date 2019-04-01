using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    class Factory_Method
    {
    }

    public class Point
    {
        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        //static void Main(string[] args)
        //{
        //    var point = Point.NewPolarPoint(1.0, Math.PI / 2);
        //    WriteLine(point);

        //    // ------------------------------------
        //    ReadLine();
        //}
    }
}
