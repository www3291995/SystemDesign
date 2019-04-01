using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    class Abstract_Factory
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
        public enum AvailableDrink
        {
            Coffee,
            Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories
            = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //private List<Tuple<string, IHotDrinkFactory>> namedFactories =
        //    new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("DesignPattern.Factory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory") ?? throw new InvalidOperationException()
                );
                factories.Add(drink, factory);
            }

            //foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            //{
            //    if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            //    {
            //        namedFactories.Add(Tuple.Create(
            //            t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
            //    }
            //}
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
    //static void Main(string[] args)
    //{
    //    var machine = new HotDrinkMachine();
    //    var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
    //    drink.Consume();

    //    // ------------------------------------
    //    ReadLine();
    //}
}
