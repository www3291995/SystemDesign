using System;
using System.Collections.Generic;
using System.IO;

//  a class should only have on reason to change
// Separation of concerns - different classes handling different, independent tasks/problems
namespace DesignPattern.SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Presistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    class SingleResponsibilityPrinciple
    {
        //static void Main(string[] args)
        //{
        //    var j = new Journal();
        //    j.AddEntry("hello");
        //    j.AddEntry("bye");
        //    WriteLine(j);

        //    var p = new Presistence();
        //    var filename = @"d:\test\test.txt";
        //    p.SaveToFile(j, filename, true);
        //    Process.Start(filename);
        //}
    }
}
