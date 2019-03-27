using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace DesignPattern.Builder.Faceted
{
    class Faceted_Builder
    {
    }

    public class Person
    {
        public string StreetAddress, Postcode, City;

        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return
                $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, " +
                $"{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    //facade
    public class PersonBuilder
    {
        //reference !
        protected Person person = new Person();

        public PersonJobBuilder works => new PersonJobBuilder(person);
        public PersonAddressBuilder lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string address)
        {
            person.StreetAddress = address;
            return this;
        }

        public PersonAddressBuilder withPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
    //static void Main(string[] args)
    //{
    //    var pb = new PersonBuilder();
    //    Person person = pb
    //        .lives.At("road")
    //        .In("lodn")
    //        .withPostcode("91777")
    //        .works
    //        .At("Fab")
    //        .AsA("Eng")
    //        .Earning(123000);

    //    WriteLine(person);
    //    ReadLine();
    //}
}
