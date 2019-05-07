using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Command Coding Exercise
/// Implement the Account.Process() method to process different account commands. The rules are obvious:
///     .Success indicates whether the operation was successful
///     .You can only withdraw money if you have enough in your account
/// </summary>
namespace DesignPattern.Command.Exercise
{
    class Exercise
    {
    }

    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    c.Success = Balance >= c.Amount;
                    if (c.Success) Balance -= c.Amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestA()
        {
            var acct = new Account();
            var c1 = new Command
            {
                TheAction = Command.Action.Deposit,
                Amount = 100
            };
            acct.Process(c1);
            Assert.That(acct.Balance, Is.EqualTo(100));
            Assert.IsTrue(c1.Success);

            var c2 = new Command
            {
                TheAction = Command.Action.Withdraw,
                Amount = 200
            };
            acct.Process(c2);
            Assert.That(acct.Balance, Is.EqualTo(100));
            Assert.IsFalse(c2.Success);

            var c3 = new Command
            {
                TheAction = Command.Action.Withdraw,
                Amount = 50
            };
            acct.Process(c3);
            Assert.That(acct.Balance, Is.EqualTo(50));
            Assert.IsTrue(c3.Success);
        }
    }

}
