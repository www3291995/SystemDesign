using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Memento.Undo_And_Redo
{
    class Undo_And_Redo
    {
        //static void Main(string[] args)
        //{
        //    var ba = new BankAccount(100);
        //    ba.Deposite(50);
        //    ba.Deposite(25);
        //    WriteLine(ba);

        //    ba.Undo();
        //    WriteLine($"Undo 1: {ba}");
        //    ba.Undo();
        //    WriteLine($"Undo 2: {ba}");

        //    ba.Redo();
        //    WriteLine($"Redo: {ba}");


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
        private List<Memento1> changes = new List<Memento1>();
        private int current;

        public BankAccount(int balance)
        {
            this.balance = balance;
            changes.Add(new Memento1(balance));
        }

        public Memento1 Deposite(int amount)
        {
            balance += amount;
            var m = new Memento1(balance);
            changes.Add(m);
            ++current;
            return m;
        }

        public Memento1 Restore(Memento1 m)
        {
            if (m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                return m;
            }

            return null;
        }

        public Memento1 Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }

            return null;
        }

        public Memento1 Redo()
        {
            if (current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }

            return null;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
