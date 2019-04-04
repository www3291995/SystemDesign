using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype
{
    class ICloneable_is_bad
    {
        //static void Main(string[] args)
        //{
        //    var john = new Person(new[] { "John", "Smith" }, new Address("London", 10));
        //    WriteLine(john.ToString());

        //    //var jane = john;
        //    //jane.Names[0] = "Jane";
        //    //WriteLine(jane.ToString());

        //    var jane = (Person)john.Clone();
        //    jane.Address = new Address("LA", 123);
        //    WriteLine(jane.ToString());


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        /// <summary>
        /// Deep Copy!
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}
