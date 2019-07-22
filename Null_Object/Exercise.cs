using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Command.Exercise;
using NUnit.Framework;

/// <summary>
/// Null Object Coding Exercise
/// In this example, we have a class Account that is very tightly coupled to an ILog ... it also breaks SRP by performing all sorts of weird
/// checks in SomeOperation().
///
/// Your mission, should you choose to accept it, is to implement a NullLog class that can be fed into an Account and that doesn't throw
/// any exceptions.
/// </summary>
namespace DesignPattern.Null_Object.Exercise
{
    class Exercise
    {
    }

    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account
    {
        private ILog log;

        public Account(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        public int RecordLimit { get; } = int.MaxValue;
        public int RecordCount { get; set; } = int.MinValue;
        public void LogInfo(string message)
        {
            ++RecordCount;
        }
    }

    [TestFixture]
    public class TestNullObj
    {
        [Test]
        public void TestNull()
        {
            var log = new NullLog();
            var ba = new Account(log);
            ba.SomeOperation();
        }

        [Test]
        public void ManyTestNull()
        {
            var ba = new Account(new NullLog());
            for (int i = 0; i < int.MaxValue; i++)
            {
                ba.SomeOperation();
            }
        }
    }
}
