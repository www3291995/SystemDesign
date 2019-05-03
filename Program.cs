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

using DesignPattern.Chain_of_Responsibility.Broker_Chain;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Creature(game, "Strong Goblin", 3, 3);
            WriteLine(goblin);

            using (new DoubleAttackModifier(game, goblin))
            {
                WriteLine(goblin);
                using (new IncreaseDefenseModifier(game, goblin))
                {
                    WriteLine(goblin);
                }
            }

            WriteLine(goblin);






            // ------------------------------------
            ReadLine();
        }
    }
}
