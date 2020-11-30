using System;
using NUnit.Framework;

namespace DataStructure.Test.LinkedListTests
{
    public class LinkedListTests
    {
        [TestCase(new int[] {1, 2, 3, 4, 5}, 0, 1)]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 2, 3)]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 4, 5)]
        [TestCase(new int[] {-1, -2, -3, -4, -5}, 4, -5)]
        [TestCase(new int[] {1}, 0, 1)]
        public void GetByIndexTests(int[] array, int index, int expected)
        {
            LinkedList.LinkedList linkedList = new LinkedList.LinkedList(array);

            int actual = linkedList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1}, 1)]
        [TestCase(new int[] {}, 0)]
        [TestCase(new int[] {1,2}, -1)]
        public void GetByIndexNegativeTests(int[] arr, int index)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var value = actual[index];
            });
        }

        [TestCase(new int[] {1, 2, 3, 4, 5}, 0, int.MaxValue, new int[] {int.MaxValue, 2, 3, 4, 5})]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 2, 10, new int[] {1, 2, 10, 4, 5})]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 4, -9, new int[] {1, 2, 3, 4, -9})]
        [TestCase(new int[] {-1, -2, -3, -4, -5}, 4, -100, new int[] {-1, -2, -3, -4, -100})]
        [TestCase(new int[] {1}, 0, 0, new int[] {0})]
        public void SetByIndexTests(int[] array, int index, int value, int[] expArray)
        {
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expArray);
            LinkedList.LinkedList actual = new LinkedList.LinkedList(array);
            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {1}, 1)]
        [TestCase(new int[] {}, 0)]
        [TestCase(new int[] {1,2}, -1)]
        public void SetByIndexNegativeTests(int[] arr, int index)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                actual[index] = 1;
            });
        }

        [TestCase(new int[] {1, 2, 3, 4, 5}, 0, int.MaxValue, new int[] {int.MaxValue, 1, 2, 3, 4, 5})]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 2, 10, new int[] {1, 2, 10, 3, 4, 5})]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 4, -9, new int[] {1, 2, 3, 4, -9, 5})]
        [TestCase(new int[] {-1, -2, -3, -4, -5}, 4, -100, new int[] {-1, -2, -3, -4, -100, -5})]
        [TestCase(new int[] {1}, 0, 0, new int[] {0, 1})]
        [TestCase(new int[] { }, 0, 0, new int[] {0})]
        public void AddByIndexTests(int[] array, int index, int value, int[] expArray)
        {
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expArray);
            LinkedList.LinkedList actual = new LinkedList.LinkedList(array);
            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
    }
}