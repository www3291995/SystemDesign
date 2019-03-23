using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// high-level modules should not depend upon low-level ones; use abstractions
namespace DesignPattern
{
    class Dependency_Inversion_Principle
    {
    }

    public enum Relationship
    {
        Parent,
        Child,
        Silbing
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenof(string name);
    }

    // low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations
        = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person Parent, Person Child)
        {
            relations.Add((Parent, Relationship.Parent, Child));
            relations.Add((Child, Relationship.Child, Parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;
        public IEnumerable<Person> FindAllChildrenof(string name)
        {
            return relations.Where(
                    x => x.Item1.Name == name &&
                         x.Item2 == Relationship.Parent
                    ).Select(r => r.Item3);
            //{
            //    yield return r.Item3;
            //}
        }
    }

    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "John" &&
        //             x.Item2 == Relationship.Parent
        //        ))
        //    {
        //        Console.WriteLine($"John has a child: {r.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenof("John"))
            {
                Console.WriteLine($"John has a child: {p.Name}");
            }
        }
        //static void Main(string[] args)
        //{
        //    var parents = new Person() { Name = "John" };
        //    var child1 = new Person() { Name = "Chris" };
        //    var child2 = new Person() { Name = "Mary" };

        //    var relationship = new Relationships();
        //    relationship.AddParentAndChild(parents, child1);
        //    relationship.AddParentAndChild(parents, child2);

        //    var i = new Research(relationship);
        //    Console.ReadLine();
        //}
    }
}
