using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

/// <summary>
/// Flyweight Coding Exercise
/// You are given a class called Sentence, which takes a string such as "hello world". You need to provide an interface such that the indexer
/// returns a WordToken which can be used to capitalize a particular word in the sentence.
/// Typical use would be something like:
/// 
/// var sentence = new Sentence("hello world");
/// sentence[1].Capitalize = true;
/// WriteLine(sentence);  // hello WORLD
/// 
/// </summary>
namespace DesignPattern.Flyweight
{
    class Exercise
    {
    }
    public class Sentence
    {
        private readonly string[] text;
        private readonly Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            text = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                WordToken wt = new WordToken();
                tokens.Add(index, wt);
                return tokens[index];
            }
        }

        public override string ToString()
        {
            var lst = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                var w = text[i];
                if (tokens.ContainsKey(i) && tokens[i].Capitalize)
                    w = w.ToUpperInvariant();
                lst.Add(w);
            }

            return string.Join(" ", lst);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }

    [TestFixture]
    public class TestS
    {
        [Test]
        public void TestSent()
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Assert.That(sentence.ToString(), Is.EqualTo("hello WORLD"));
        }
    }
}
