using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
    class Fluent_builder_inheritance_with_recursive_generics
    {
    }

    public class Person
    {
        public string Name;
        public string Position;


        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Builder()
        {
            return person;
        }
    }

    // class Foo : Bar<Foo>
    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    //static void Main(string[] args)
    //{
    //    Person me = Person.New
    //        .Called("dmitri")
    //        .WorkAsA("quant")
    //        .Builder();


    //    WriteLine(me);

    //    ReadLine();
    //}
}
