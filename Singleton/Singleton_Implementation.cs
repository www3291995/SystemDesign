using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace DesignPattern.Singleton
{
    class Singleton_Implementation
    {
        //static void Main(string[] args)
        //{
        //    //var db = new SingletonDatabase();
        //    var db = SingletonDatabase.Instance;
        //    var city = "Tokyo";
        //    WriteLine($"{city} has pop {db.GetPopulation(city)}");


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> captials;

        private SingletonDatabase()
        {
            Console.WriteLine("init");

            captials = File.ReadAllLines("Singleton/captials.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).TrimEnd(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return captials[name];
        }

        //private static SingletonDatabase instance = new SingletonDatabase();
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }
}
