using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy
{
    class Value_Proxy
    {
        static void foo(Price price)
        {

        }
        //static void Main(string[] args)
        //{
        //    WriteLine(10f * 5.Percent());

        //    WriteLine(2.Percent() + 3.Percent());



        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public struct Price
    {
        private int value;

        public Price(int value)
        {
            this.value = value;
        }
    }

    // 50% = 0.5
    public struct Percentage : IEquatable<Percentage>
    {
        [DebuggerDisplay("{value*100.0f}%")]
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public bool Equals(Percentage other)
        {
            return value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a.value + b.value);
        }

        public override string ToString()
        {
            return $"{value * 100}%";
        }
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }
}
