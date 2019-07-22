using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace DesignPattern.Null_Object
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("WARNNING!!! " + msg);
        }
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited {amount}, balance now is {balance}");
        }
    }

    public class NullLog : ILog
    {
        public void Info(string msg)
        {

        }

        public void Warn(string msg)
        {
            
        }
    }

    class Null_Object
    {
        //static void Main(string[] args)
        //{
        //    var cb = new ContainerBuilder();
        //    cb.RegisterType<BankAccount>();
        //    cb.RegisterType<NullLog>().As<ILog>();
        //    using (var c = cb.Build())
        //    {
        //        var ba = c.Resolve<BankAccount>();
        //        ba.Deposit(100);
        //    }


        //    // ------------------------------------
        //    ReadLine();
        //}
    }
}
