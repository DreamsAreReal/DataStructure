using System;
using NUnit.Framework;
using DataStructure;

namespace DataStructure.Test
{
    public class ArrayListTests
    {
        [TestCase(new int[] {1,2,3,4,5})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {})]
        [TestCase(new int[] {0,0})]
        [TestCase(new int[] {0,1,2,3})]
        public void AddTests(int[] arr)
        {
            ArrayList actual = new ArrayList();
            ArrayList expected = new ArrayList(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                actual.Add(arr[i]);
            }
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1,2,3}, new int[] {3,2,1})]
        [TestCase(new int[] {1,1,1}, new int[] {1,1,1})]
        [TestCase(new int[] {}, new int[] {})]
        [TestCase(new int[] {1,2}, new int[] {2,1})]
        [TestCase(new int[] {-10,7,6}, new int[] {6,7,-10})]
        public void ReverseTests(int[] arr, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(arr);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {5,6,7}, 2, 7)]
        [TestCase(new int[] {-1,6,1,4,5,6,7,2,1}, 0, -1)]
        [TestCase(new int[] {6,7,8,9,10}, 4, 10)]
        [TestCase(new int[] {5,5,1}, 1, 5)]
        [TestCase(new int[] {31}, 0, 31)]
        public void GetByIndexTests(int[] arr, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(arr);
            int actual = arrayList[index];
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {5,6,7}, 31)]
        [TestCase(new int[] {}, 1)]
        [TestCase(new int[] {18,91,34}, -2)]
        [TestCase(new int[] {6,2,3}, 10)]
        public void GetByIndexNegativeTests(int[] arr, int index)
        {
            ArrayList actual = new ArrayList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                int a = actual[index]; 
            });
        }
        
        
        [TestCase(new int[] {5,6,7}, 1, 7)]
        [TestCase(new int[] {-1,6,1,4,5,6,7,2,1}, 5, -1)]
        [TestCase(new int[] {6,7,8,9,10}, 3, 10)]
        [TestCase(new int[] {5,5,1}, 2, 5)]
        [TestCase(new int[] {31}, 0, 77)]
        public void SetByIndexTests(int[] arr, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(arr);
            arrayList[index] = expected;
            int actual = arrayList[index];
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {5,6,7}, 7)]
        [TestCase(new int[] {-1,6,1,4,5,6,7,2,1}, -1)]
        [TestCase(new int[] {6,7,8,9,10}, 10)]
        [TestCase(new int[] {5,5,1}, 5)]
        [TestCase(new int[] {}, 77)]
        public void SetByIndexNegativeTests(int[] arr, int index)
        {
            ArrayList actual = new ArrayList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                actual[index]=0; 
            });
        }
        
    }
}