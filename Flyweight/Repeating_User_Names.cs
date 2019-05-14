using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DesignPattern.Flyweight
{
    class Repeating_User_Names
    {
    }

    public class User
    {
        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;

                strings.Add(s);
                return strings.Count - 1;
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullNames => string.Join(" ", names.Select(i => strings[i]));
    }

    [TestFixture]
    public class Demo
    {
        [Test]
        public void TestUser() //1899097
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User>();

            foreach (var fn in firstNames)
            {
                foreach (var ln in lastNames)
                {
                    users.Add(new User($"{fn} {ln}"));
                }
            }

            ForceGC();
            
            dotMemory.Check(memory => { Console.WriteLine(memory.SizeInBytes); });
        }

        [Test]
        public void TestUser2() //1899097 1601127
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User2>();

            foreach (var fn in firstNames)
            {
                foreach (var ln in lastNames)
                {
                    users.Add(new User2($"{fn} {ln}"));
                }
            }

            ForceGC();

            dotMemory.Check(memory => { Console.WriteLine(memory.SizeInBytes); });
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public string RandomString()
        {
            Random rand = new Random();
            return new string(Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        }
    }
}
