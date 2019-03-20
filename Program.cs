using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("hello");
            j.AddEntry("bye");
            WriteLine(j);

            var p = new Presistence();
            var filename = @"d:\test\test.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
