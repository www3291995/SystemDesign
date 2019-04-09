using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

///Singleton Coding Exercise
///Since implementing a singleton is easy, you have a different challenge: write a method called IsSingleton().
///This method takes a factory method that returns an object and it's up to you to determine whether or not that object is a singleton instance.   
namespace DesignPattern.Singleton
{
    class Exercise
    {
    }
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var obj1 = func();
            var obj2 = func();

            return ReferenceEquals(obj1, obj2);
        }
    }

    [TestFixture]
    public class TestSingleton
    {
        [Test]
        public void Test()
        {
            var obj = new object();
            Assert.IsTrue(SingletonTester.IsSingleton(() => obj));
            Assert.IsFalse(SingletonTester.IsSingleton(() => new object()));
        }
    }
}
