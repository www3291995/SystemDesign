using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Chain of Responsibility Coding Exercise
/// You are given a game scenario with classes Goblin and GoblinKing. Please implement the following rules:
///     .A goblin has base 1 attack/1 defense (1/1), a goblin king is 3/3.
///     .When the Goblin King is in play, every other goblin gets +1 Attack.
///     .Goblins get +1 to Defense for every other Goblin in play (a GoblinKing is a Goblin!).
/// Example:
///     .Suppose you have 3 ordinary goblins in play. Each one is a 1/3 (1/1 + 0/2 defense bonus).
///     .A goblin king comes into play. Now every goblin is a 2/4 (1/1 + 0/3 defense bonus from each other + 1/0 from goblin king)
/// The state of all the goblins has to be consistent as goblins are added and removed from the game.
/// Here is an example of the kind of test that will be run on the system: 
///        [Test]
///        public void TestE()
///        {
///            var game = new Game();
///            var goblin = new Goblin(game);
///            game.Creatures.Add(goblin);
///            Assert.That(goblin.Attack, Is.EqualTo(1));
///            Assert.That(goblin.Defense, Is.EqualTo(1));
///        }
/// </summary>
namespace DesignPattern.Chain_of_Responsibility.Exercise
{
    class Exercise
    {
    }
    public abstract class Creature
    {
        protected Game game;
        protected readonly int baseAttack;
        protected readonly int baseDefense;

        protected Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game;
            this.baseAttack = baseAttack;
            this.baseDefense = baseDefense;
        }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public abstract void Query(object source, StatQuery sq);
    }

    public class Goblin : Creature
    {
        public Goblin(Game game) : base(game, 1, 1)
        {

        }

        protected Goblin(Game game, int baseAttack, int baseDefense) : base(game, baseAttack, baseDefense)
        {

        }

        public override void Query(object source, StatQuery sq)
        {
            if (ReferenceEquals(source, this))
            {
                switch (sq.Statistic)
                {
                    case Statistic.Attack:
                        sq.Result += baseAttack;
                        break;
                    case Statistic.Defense:
                        sq.Result += baseDefense;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                if (sq.Statistic == Statistic.Defense)
                {
                    sq.Result++;
                }
            }
        }

        public override int Attack
        {
            get
            {
                var q = new StatQuery {Statistic = Statistic.Attack};
                foreach (var c in game.Creatures)
                {
                    c.Query(this, q);
                }

                return q.Result;
            }
        }

        public override int Defense
        {
            get
            {
                var q = new StatQuery { Statistic = Statistic.Defense };
                foreach (var c in game.Creatures)
                {
                    c.Query(this, q);
                }

                return q.Result;
            }
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game, 3, 3)
        {
        }

        public override void Query(object source, StatQuery sq)
        {
            if (!ReferenceEquals(source, this) && sq.Statistic == Statistic.Attack)
            {
                sq.Result++;
            }
            else
            {
                base.Query(source, sq);
            }
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }

    public enum Statistic
    {
        Attack, Defense
    }

    public class StatQuery
    {
        public Statistic Statistic;
        public int Result;
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestE()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.That(goblin.Attack, Is.EqualTo(1));
            Assert.That(goblin.Defense, Is.EqualTo(1));

            var goblin2 = new Goblin(game);
            game.Creatures.Add(goblin2);
            Assert.That(goblin.Attack, Is.EqualTo(1));
            Assert.That(goblin.Defense, Is.EqualTo(2));

            var goblinK = new GoblinKing(game);
            game.Creatures.Add(goblinK);
            Assert.That(goblin.Attack, Is.EqualTo(2));
            Assert.That(goblin.Defense, Is.EqualTo(3));
        }
    }
}
