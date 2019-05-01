﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy
{
    class Property_Proxy
    {
        //static void Main(string[] args)
        //{
        //    var c = new Creature();
        //    c.Agility = 10;  // not ------> c.set_Agility(10);
        //                     // Really IS -----> c.Agility = new Property<int>(10);

        //    c.Agility = 10;



        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Property<T> : IEquatable<Property<T>> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning Value to {value}");
                this.value = value;
            }
        }

        public Property() : this(Activator.CreateInstance<T>())
        {
            
        }

        public Property(T value)
        {
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value; // int n = p_int;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); // Property<int> p = 123;
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }
    }

    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }
}
