using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    class Multiple_Inheritance
    {
        //static void Main(string[] args)
        //{
        //    var d = new Dragon();
        //    d.Weight = 10;
        //    d.Fly();
        //    d.Crawl();



        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine($"fly {Weight}");
        }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawing in dirt {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizar = new Lizard();
        private int weight;

        public void Crawl()
        {
            lizar.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public int Weight
        {
            get { return weight;}
            set
            {
                weight = value;
                bird.Weight = value;
                lizar.Weight = value;
            }
        }
    }

}
