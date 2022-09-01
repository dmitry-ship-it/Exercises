using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeTask
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private sealed class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (Left is not null)
                {
                    foreach (var value in Left)
                    {
                        yield return value;
                    }
                }

                yield return Value;

                if (Right is not null)
                {
                    foreach (var value in Right)
                    {
                        yield return value;
                    }
                }
            }
        }

        private Node _root;

        public void Insert(T value)
        {
            if (_root is null)
            {
                _root = new Node(value);
                return;
            }

            InsertHelper(_root, new Node(value));
        }

        private void InsertHelper(Node parent, Node newNode)
        {
            if (newNode.Value.CompareTo(parent.Value) < 0)
            {
                if (parent.Left is null)
                {
                    parent.Left = newNode;
                }
                else
                {
                    InsertHelper(parent.Left, newNode);
                }
            }
            else
            {
                if (parent.Right is null)
                {
                    parent.Right = newNode;
                }
                else
                {
                    InsertHelper(parent.Right, newNode);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
