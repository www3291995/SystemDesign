using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

/// <summary>
/// Memento Coding Exercise
/// A TokenMachine is in charge of keeping tokens. Each Token is a reference type with a single numerical value. The machine supports
/// adding tokens and, when it does, it returns a memento representing the state of that system at that given time.
///
/// You are asked to fill in the gaps and implement the Memento design pattern for this scenario. Pay close attention to the situation where a
/// token is fed in as a reference and its value is subsequently changed on that reference - you still need to return the correct system
/// snapshot!
/// </summary>
namespace DesignPattern.Memento.Exercise
{
    class Exercise
    {
    }
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<Token> Tokens = new List<Token>();
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            return AddToken(new Token(value));
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            var m = new Memento();
            m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList();
            return m;
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens.Select(mm => new Token(mm.Value)).ToList();
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestSingleToken()
        {
            var tm = new TokenMachine();
            var m = tm.AddToken(123);
            tm.AddToken(456);
            tm.Revert(m);

            Assert.That(tm.Tokens.Count, Is.EqualTo(1));
            Assert.That(tm.Tokens[0].Value, Is.EqualTo(123));
        }

        [Test]
        public void TestTwoTokens()
        {
            var tm = new TokenMachine();
            tm.AddToken(1);
            var m = tm.AddToken(2);
            tm.AddToken(3);
            tm.Revert(m);

            Assert.That(tm.Tokens.Count, Is.EqualTo(2));
            Assert.That(tm.Tokens[0].Value, Is.EqualTo(1));
            Assert.That(tm.Tokens[1].Value, Is.EqualTo(2));
        }

        [Test]
        public void TestFiddledToken()
        {
            var tm = new TokenMachine();
            var token = new Token(111);
            tm.AddToken(token);
            var m = tm.AddToken(222);
            token.Value = 333;
            Assert.That(tm.Tokens[0].Value, Is.EqualTo(333));

            tm.Revert(m);

            Assert.That(tm.Tokens.Count, Is.EqualTo(2));
            Assert.That(tm.Tokens[0].Value, Is.EqualTo(111));
        }
    }

}
