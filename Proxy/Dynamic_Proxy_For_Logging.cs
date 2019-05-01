using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;

namespace DesignPattern.Proxy
{
    class Dynamic_Proxy_For_Logging
    {
//        static void Main(string[] args)
//        {
//            //var ba = new BankAccount();
//
//            var ba = Log<BankAccount>.As<IBankAccount>();
//            ba.Deposit(100);
//            ba.Withdraw(50);
//            WriteLine(ba);
//
//
//
//
//
//            // ------------------------------------
//            ReadLine();
//        }
    }

    public interface IBankAccount
    {
        void Deposit(int amount);
        bool Withdraw(int amount);
        string ToString();
    }

    public class BankAccount : IBankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount; 
                Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public class Log<T> : DynamicObject where T : class, new()
    {
        private readonly T subject;
        private Dictionary<string, int> methodCallCount = new Dictionary<string, int>();

        public Log(T subject)
        {
            this.subject = subject;
        }

        public static I As<I>() where I : class
        {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("must be an interface type!");

            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                Console.WriteLine($"Invoking {subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");

                if (methodCallCount.ContainsKey(binder.Name)) methodCallCount[binder.Name]++;
                else methodCallCount.Add(binder.Name, 1);

                result = subject.GetType().GetMethod(binder.Name)?.Invoke(subject, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Info}{subject}";
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var kv in methodCallCount)
                {
                    sb.AppendLine($"{kv.Key} called {kv.Value} times");
                }

                return sb.ToString();
            }
        }
    }
}
