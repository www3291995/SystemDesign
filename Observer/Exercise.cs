using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Observer Coding Exercise
/// Imagine a game where one or more rats can attack a player. Each individual rat has an Attack value of 1. However, rats attack as a swarm,
/// so each rat's Attack value is equal to the total number of rats in play.
///
/// Given that a rat enters play through the constructor and leaves play (dies) via its Dispose() method, please implement the Game and Rat
/// classes so that, at any point in the game, the Attack value of a rat is always consistent.
///
/// This exercise has two simple rules:
///     .The Game class cannot have properties or fields. It can only contain events and methods.
///     .The Rat class' Attack field is strictly a field, not a property.
/// </summary>
namespace DesignPattern.Observer
{
    class Exercise
    {
    }

    public class Game
    {
        public event EventHandler RatEnters, RatDies;
        public event EventHandler<Rat> NotifyRat;

        public void FireRatEnters(object sender)
        {
            RatEnters?.Invoke(sender, EventArgs.Empty);
        }

        public void FireRatDies(object sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }

        public void FireNotifyRat(object sender, Rat whichRat)
        {
            NotifyRat?.Invoke(sender, whichRat);
        }
    }

    public class Rat : IDisposable
    {
        private readonly Game game;
        public int Attack = 1;

        public Rat(Game game)
        {
            this.game = game;
            game.RatEnters += (sender, EventArgs) =>
            {
                if (sender != this)
                {
                    ++Attack;
                    game.FireNotifyRat(this, (Rat)sender);
                }
            };

            game.NotifyRat += (sender, rat) =>
            {
                if (rat == this) ++Attack;
            };

            game.RatDies += (sender, args) => --Attack;
            game.FireRatEnters(this);
        }


        public void Dispose()
        {
            game.FireRatDies(this);
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestGame()
        {
            var game = new Game();
            var rat = new Rat(game);

            Assert.That(rat.Attack, Is.EqualTo(1));
        }

        [Test]
        public void TwoRats()
        {
            var game = new Game();
            var rat = new Rat(game);

            Assert.That(rat.Attack, Is.EqualTo(1));
           
            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
        }

        [Test]
        public void MoreRatsDie()
        {
            var game = new Game();
            var rat = new Rat(game);

            Assert.That(rat.Attack, Is.EqualTo(1));

            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));

            var rat3 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(3));
            Assert.That(rat2.Attack, Is.EqualTo(3));
            Assert.That(rat3.Attack, Is.EqualTo(3));

            rat3.Dispose();
            Assert.That(rat.Attack, Is.EqualTo(2));
        }
    }
}
