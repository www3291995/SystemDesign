using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Memento
{
    class Memento
    {
        //static void Main(string[] args)
        //{
        //    var ba = new BankAccount(100);
        //    var m1 = ba.Deposite(50);
        //    var m2 = ba.Deposite(25);
        //    WriteLine(ba);

        //    ba.Restore(m1);
        //    WriteLine(ba);

        //    ba.Restore(m2);
        //    WriteLine(ba);


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Memento1
    {
        public int Balance { get; set; }

        public Memento1(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        private int balance;

        public BankAccount(int balance)
        {
            this.balance = balance;
        }

        public Memento1 Deposite(int amount)
        {
            balance += amount;
            return new Memento1(balance);
        }

        public void Restore(Memento1 m)
        {
            balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
