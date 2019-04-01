using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Factory;
using static System.Console;
using HotDrinkMachine = DesignPattern.Factory.Abstract_Factory_And_OCP.HotDrinkMachine;
using Point = DesignPattern.Factory_Inner_Factory.Point;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var p = new PersonFactory();
            p.CreatePerson("john");
            p.CreatePerson("emily");

            WriteLine(p);

            // ------------------------------------
            ReadLine();
        }
    }
}
