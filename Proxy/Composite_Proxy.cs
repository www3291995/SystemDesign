using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Proxy.Composite_Proxy
{
    class Composite_Proxy
    {
        //static void Main(string[] args)
        //{
        //    // AOS
        //    var creatures = new Creature[100];
        //    for (int i = 0; i < creatures.Length; i++)
        //    {
        //        creatures[i] = new Creature();
        //    }
        //    // Age X Y Age X Y Age X Y

        //    // Age Age Age Age
        //    // X X X X 
        //    // Y Y Y Y 
        //    foreach (var c in creatures)
        //    {
        //        c.X++;
        //    }

        //    var creatures2 = new Creatures(100);   //SOA
        //    foreach (Creatures.CreatureProxy c in creatures2)
        //    {
        //        c.X++;
        //    }





        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    class Creature
    {
        public byte Age;
        public int X, Y;

        public Creature()
        {
            
        }
    }

    class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;

            public CreatureProxy(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; pos++)
            {
                yield return new CreatureProxy(this, pos);
            }
        }
    }
}
