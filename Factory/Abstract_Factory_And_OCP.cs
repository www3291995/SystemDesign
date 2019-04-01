using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.Abstract_Factory_And_OCP
{
    class Abstract_Factory_And_OCP
    {
    }
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("coffee");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"tea, pour {amount} ml");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"coffee, pour {amount} ml");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) &&
                    !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("avail drink:");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index} : {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Console.WriteLine("amount: ");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("again");

            }
        }
    }

    //static void Main(string[] args)
    //{
    //    var machine = new HotDrinkMachine();
    //    var drink = machine.MakeDrink();

    //    // ------------------------------------
    //    ReadLine();
    //}
}
