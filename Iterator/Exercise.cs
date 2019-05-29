using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Given the following definition of a Node<T>, implement preorder traversal that returns a sequence of Ts.
/// https://en.wikipedia.org/wiki/Tree_traversal#Pre-order
/// </summary>
namespace DesignPattern.Iterator.Exercise
{
    class Exercise
    {
    }
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        private IEnumerable<Node<T>> Traverse(Node<T> current)
        {
            yield return current;
            if (current.Left != null)
            {
                foreach (var left in Traverse(current.Left))
                {
                    yield return left;
                }
            }

            if (current.Right != null)
            {
                foreach (var right in Traverse(current.Right))
                {
                    yield return right;
                }
            }
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in Traverse(this))
                {
                    yield return node.Value;
                }
            }
        }
    }

    [TestFixture]
    public class TestIterator
    {
        [Test]
        public void Test()
        {
            var node = new Node<char>('a', 
                new Node<char>('b', 
                    new Node<char>('c'), 
                    new Node<char>('d')),
                new Node<char>('e'));

            Assert.That(new string(node.PreOrder.ToArray()), Is.EqualTo("abcde"));
        }
    }
}
