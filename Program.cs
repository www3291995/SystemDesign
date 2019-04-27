using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MoreLinq;
using NUnit.Framework.Constraints;
using static System.Console;

using DesignPattern.Decorator.Static_Decorator_Composition;
using DesignPattern.Facade;
using DesignPattern.Flyweight;
using ColorShape = DesignPattern.Decorator.Static_Decorator_Composition.ColorShape;
using Square = DesignPattern.Decorator.Static_Decorator_Composition.Square;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft);

            var bft = new BetterFormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            bft.GetRange(0, 1).New = true;
            WriteLine(bft);


            // ------------------------------------
            ReadLine();
        }
    }
}
