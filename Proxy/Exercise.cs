using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Proxy Coding Exercise
/// You are given the Person class and asked to write a ResponsiblePerson proxy that does the following:
///     .Allows person to drink unless they are younger than 18 (in that case, return "too young")
///     .Allows person to drive unless they are younger than 16 (otherwise, "too young")
///     .In case of driving while drinking, returns "dead"
/// </summary>
namespace DesignPattern.Proxy
{
    class Exercise
    {
    }
    public class Person
    {
        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly Person person;

        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get => person.Age;
            set => person.Age = value;
        }

        public string Drink()
        {
            if (person.Age < 18)
                return "too young";
            return person.Drink();
        }

        public string Drive()
        {
            if (person.Age < 16)
                return "too young";
            return person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestE()
        {
            var p = new ResponsiblePerson(new Person(12));
            Assert.That(p.Drink(), Is.EqualTo("too young"));
            Assert.That(p.Drive(), Is.EqualTo("too young"));
            Assert.That(p.DrinkAndDrive(), Is.EqualTo("dead"));

            var p2 = new ResponsiblePerson(new Person(17));
            Assert.That(p2.Drink(), Is.EqualTo("too young"));
            Assert.That(p2.Drive(), Is.EqualTo("driving"));
            Assert.That(p2.DrinkAndDrive(), Is.EqualTo("dead"));
        }
    }

}
