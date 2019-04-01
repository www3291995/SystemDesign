using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    class Factory
    {
    }

    public class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        //static void Main(string[] args)
        //{
        //    var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
        //    WriteLine(point);

        //    // ------------------------------------
        //    ReadLine();
        //}
    }
}
