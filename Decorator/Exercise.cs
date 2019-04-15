using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Decorator Coding Exercise
/// The following code scenario shows a Dragon which is both a Bird and a Lizard.
/// Complete the Dragon's interface (there's no need to extract IBird or ILizard). Take special care when implementing the Age property! 
/// </summary>
namespace DesignPattern.Decorator.Exercise
{
    class Exercise
    {
    }

    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private int age;
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public int Age
        {
            get
            {
                return age;
            }
            set { age = bird.Age = lizard.Age = value; }
        }

        public string Fly()
        {
           return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestD()
        {
            var dragon = new Dragon();

            Assert.That(dragon.Fly(), Is.EqualTo("flying"));
            Assert.That(dragon.Crawl(), Is.EqualTo("too young"));

            dragon.Age = 20;

            Assert.That(dragon.Fly(), Is.EqualTo("too old"));
            Assert.That(dragon.Crawl(), Is.EqualTo("crawling"));
        }
    }
}
