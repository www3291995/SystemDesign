using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Composite Coding Exercise
/// Consider the code presented below. The Sum() extension method adds up all the values in a list of IValueContainer elements it gets
/// passed. We can have a single value or a set of values.
/// Complete the implementation of the interfaces so that Sum() begins to work correctly.
/// </summary>
namespace DesignPattern.Composite
{
    class Exercise
    {
    }
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
            {
                foreach (var i in c)
                {
                    result += i;
                }
            }

            return result;
        }
    }

    [TestFixture]
    public class TestComposite
    {
        [Test]
        public void Test()
        {
            var s = new SingleValue {Value = 10};
            var m = new ManyValues();
            m.Add(20);
            m.Add(30);

            Assert.That(new List<IValueContainer>{s,m}.Sum(), Is.EqualTo(60));
        }
    }
}
