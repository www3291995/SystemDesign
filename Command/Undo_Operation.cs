using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command.Undo_Operation
{
    class Undo_Operation
    {
//        static void Main(string[] args)
//        {
//            var bk = new BankAccount();
//            var command = new List<BankAccountCommand>
//            {
//                new BankAccountCommand(bk, BankAccountCommand.Action.Deposit, 100),
//                new BankAccountCommand(bk, BankAccountCommand.Action.Withdraw, 1000)
//            };
//
//            WriteLine(bk);
//            foreach (var c in command)
//            {
//                c.Call();
//            }
//            WriteLine(bk);
//
//            foreach (var c in Enumerable.Reverse(command))
//            {
//                c.Undo();
//            }
//            WriteLine(bk);
//
//
//
//
//
//            // ------------------------------------
//            ReadLine();
//        }
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

        public bool Draw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw ${amount}, balance is: ${balance}");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"balance is ${balance}";
        }
    }

    public interface ICommand
    {
        void Call();
        void Undo();
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
        private bool succeeded;

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
                    succeeded = true;
                    break;
                case Action.Withdraw:
                    succeeded = account.Draw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!succeeded) return;
            
            switch (action)
            {
                case Action.Deposit:
                    account.Draw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposit(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
