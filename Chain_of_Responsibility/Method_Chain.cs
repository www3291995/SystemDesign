using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Chain_of_Responsibility
{
    class Method_Chain
    {
//        static void Main(string[] args)
//        {
//            var goblin = new Creature("Goblin", 2, 2);
//            WriteLine(goblin);
//
//            var root = new CreatureModifier(goblin);
//
//            root.Add(new NoBounsModifier(goblin));
//
//            root.Add(new DoubleAttackModifier(goblin));
//            root.Add(new IncreaseDefenseModifier(goblin));
//
//            root.Handle();
//            WriteLine(goblin);
//
//
//
//
//
//            // ------------------------------------
//            ReadLine();
//        }
    }

    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next; //linked list

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier cm)
        {
            if (next != null)
                next.Add(cm);
            else
                next = cm;
        }

        public virtual void Handle()
        {
            next?.Handle();
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increase {creature.Name}'s defense");
            creature.Defense += 3;
            base.Handle();
        }
    }

    public class NoBounsModifier : CreatureModifier
    {
        public NoBounsModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {

        }
    }
}
