using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    class Command
    {
        //static void Main(string[] args)
        //{
        //    var bk = new BankAccount();
        //    var command = new List<BankAccountCommand>
        //    {
        //        new BankAccountCommand(bk, BankAccountCommand.Action.Deposit, 100),
        //        new BankAccountCommand(bk, BankAccountCommand.Action.Withdraw, 50)
        //    };

        //    WriteLine(bk);
        //    foreach (var c in command)
        //    {
        //        c.Call();
        //    }




        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposit ${amount}, balance is: ${balance}");
        }

        public void Draw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw ${amount}, balance is: ${balance}");
            }
        }

        public override string ToString()
        {
            return $"balance is ${balance}";
        }
    }

    public interface ICommand
    {
        void Call();
    }

    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        public enum Action
        {
            Deposit, Withdraw
        }

        private Action action;
        private int amount;

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    break;
                case Action.Withdraw:
                    account.Draw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
