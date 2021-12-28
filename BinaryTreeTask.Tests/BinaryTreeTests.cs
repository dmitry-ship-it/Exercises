using NUnit.Framework;
using System;
using System.Linq;

namespace BinaryTreeTask.Tests
{
    public class BinaryTreeTests
    {
        [TestCase(new[] { 91, -10, -88, -95, -39, -47, 73 }, new[] { -95, -88, -47, -39, -10, 73, 91 })]
        [TestCase(new[] { -25, 92, -14, 98, -65, 9, -96, 72, -5, 29, 41 }, new[] { -96, -65, -25, -14, -5, 9, 29, 41, 72, 92, 98 })]
        public void Insert_ValidValuesSpread_Int32(int[] values, int[] expected)
        {
            var tree = new BinaryTree<int>();

            for (var i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }

            var actual = tree.ToArray();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestCase(new[] { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing" },
            new[] { "adipiscing", "amet", "consectetur", "dolor", "ipsum", "Lorem", "sit" })]
        [TestCase(new[] { "Class", "aptent", "taciti", "sociosqu", "ad", "litora", "torquent", "per", "conubia", "nostra", "per" },
            new[] { "ad", "aptent", "Class", "conubia", "litora", "nostra", "per", "per", "sociosqu", "taciti", "torquent" })]
        public void Insert_ValidValuesSpread_String(string[] values, string[] expected)
        {
            var tree = new BinaryTree<string>();

            for (var i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }

            var actual = tree.ToArray();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
