using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Factory Coding Exercise
/// You are given a class called Person. The person has two fields: Id, and Name.
/// Please implement a non-static PersonFactory that has a CreatePerson() method that takes a person's name.
/// The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0,
/// second Id=1 and so on.
/// </summary>
namespace DesignPattern.Factory
{
    class Exercise
    {
        //static void Main(string[] args)
        //{
        //    var p = new PersonFactory();
        //    p.CreatePerson("john");
        //    p.CreatePerson("emily");

        //    WriteLine(p);

        //    // ------------------------------------
        //    ReadLine();
        //}
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private readonly IList<Person> person = new List<Person>();

        public Person CreatePerson(string name)
        {
            var p = new Person()
            {
                Id = GetNextId(),
                Name = name
            };
            person.Add(p);

            return p;
        }

        private int GetNextId()
        {
            if (person.Count <= 0)
                return 0;
            return person.Max(a => a.Id) + 1;
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var p in person)
            {
                s += $"{p.Id}: {p.Name}\n";
            }

            return s;
        }
    }
}
