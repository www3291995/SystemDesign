using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPattern.Prototype.Copy_Through_Serialization
{
    class Copy_Through_Serialization
    {
        //static void Main(string[] args)
        //{
        //    var john = new Person(new[] { "John", "Smith" }, new Address("London", 10));
        //    WriteLine(john.ToString());

        //    var jane = john.DeepCopy();
        //    jane.Names[0] = "Jane";
        //    jane.Address.HouseNumber = 666;
        //    WriteLine(jane.ToString());

        //    var jane1 = john.DeepCopyXML();
        //    jane1.Names[0] = "Jane";
        //    jane1.Address.HouseNumber = 666;
        //    WriteLine(jane1.ToString());


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();

            return (T) copy;
        }

        public static T DeepCopyXML<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
    
    [Serializable]
    public class Person 
    {
        public string[] Names;
        public Address Address;

        public Person()
        {

        }

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

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address 
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {

        }

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

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}
