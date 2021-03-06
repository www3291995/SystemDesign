﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Iterator
{
    class Iterator_Object
    {
        //static void Main(string[] args)
        //{
        //    //      1
        //    //     / \
        //    //    2   3
        //    // in-order: 213
        //    // pre-order: 321
        //    var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
        //    var it = new InOrderIterator<int>(root);
        //    while (it.MoveNext())
        //    {
        //        Write(it.Current.Value);
        //        Write(',');
        //    }



        //    // ------------------------------------
        //    ReadLine();
        //}
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
    }

    public class InOrderIterator<T>
    {
        public Node<T> Current;
        private readonly Node<T> root;
        private bool yieldStart;

        public InOrderIterator(Node<T> root)
        {
            this.root = root;
            Current = root;

            while (Current.Left != null)
            {
                Current = Current.Left;
            }
        }

        public bool MoveNext()
        {
            if (!yieldStart)
            {
                yieldStart = true;
                return true;
            }

            if (Current.Right != null)
            {
                Current = Current.Right;
                while (Current.Left != null)
                {
                    Current = Current.Left;
                }

                return true;
            }
            else
            {
                var p = Current.Parent;
                while (p != null && Current == p.Right)
                {
                    Current = p;
                    p = p.Parent;
                }

                Current = p;
                return Current != null;
            }
        }

        public void Reset()
        {
            Current = root;
            yieldStart = false;
        }
    }
}
