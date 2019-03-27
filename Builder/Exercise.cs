using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Builder Coding Exercise
 * You are asked to implement the Builder design pattern for rendering simple chunks of code.
 * Sample use of the builder you are asked to create:
 *
 * var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
 * Console.WriteLine(cb);
 *
 * The expected output of the above code is:
 *
 * public class Person
 * {
 *   public string Name;
 *   public int Age;
 * }
 *
 * Please observe the same placement of curly braces and use two-space indentation.
 */

namespace DesignPattern.Builder
{
    class Exercise
    {
    }

    public class CodeBuilder
    {
        private static readonly int indent = 2;
        protected string Name;
        protected string Type;
        protected IList<CodeBuilder> Child = new List<CodeBuilder>();

        public CodeBuilder(string name)
        {
            Name = name;
        }

        public CodeBuilder(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public CodeBuilder AddField(string name, string type)
        {
            Child.Add(new CodeBuilder(name, type));
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string indents = new string(' ', indent);
            sb.Append($"public class {Name}\n");
            sb.Append("{\n");

            if (Child.Count > 0)
            {
                foreach (var c in Child)
                {
                    sb.Append($"{indents}public {c.Type} {c.Name};\n");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
        //static void Main(string[] args)
        //{
        //    var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
        //    WriteLine(cb);


        //    // ------------------------------------
        //    ReadLine();
        //}
    }
}
