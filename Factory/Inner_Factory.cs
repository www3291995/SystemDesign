using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory_Inner_Factory
{
    class Inner_Factory
    {
    }
    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        //public static PointFactory Factory => new PointFactory();
        public static Point Origin => new Point(0, 0);
        public static Point Origin2 = new Point(0, 0); // better 

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
        //static void Main(string[] args)
        //{
        //    var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
        //    WriteLine(point);

        //    var origin = Point.Origin;
        //    var o = Point.Origin2;

        //    // ------------------------------------
        //    ReadLine();
        //}
    }
}
