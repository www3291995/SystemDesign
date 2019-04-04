using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype.Explicit_Deep_Copy_Interface
{
    class Explicit_Deep_Copy_Interface
    {
        //static void Main(string[] args)
        //{
        //    var john = new Person(new[] { "John", "Smith" }, new Address("London", 10));
        //    WriteLine(john.ToString());

        //    var jane = john.DeepCopy();
        //    jane.Address.HouseNumber = 666;
        //    WriteLine(jane.ToString());


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}
