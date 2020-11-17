using System;
using NUnit.Framework;
using DataStructure;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace DataStructure.Test
{
    public class ArrayListTests
    {
        [TestCase(new int[] {1,2,3,4,5})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {})]
        [TestCase(new int[] {0,0})]
        [TestCase(new int[] {0,1,2,3})]
        [TestCase(new int[] {0, 2,3})]
        public void AddTest(int[] arr)
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
        public void ReverseTest(int[] arr, int[] expectedArray)
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
        public void GetByIndexTest(int[] arr, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(arr);
            int actual = arrayList[index];
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {5,6,7}, 31)]
        [TestCase(new int[] {}, 1)]
        [TestCase(new int[] {18,91,34}, -2)]
        [TestCase(new int[] {6,2,3}, 10)]
        public void GetByIndexNegativeTest(int[] arr, int index)
        {
            ArrayList actual = new ArrayList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                int a = actual[index]; 
            });
        }
        
        

        [TestCase(new int[] {5,6,7}, 0, 31, new int[] {31,6,7})]
        [TestCase(new int[] {5,6,7}, 2, 2, new int[] {5,6,2})]
        [TestCase(new int[] {5,6,7}, 1, 31, new int[] {5,31,7})]
        [TestCase(new int[] {5,6,7}, 1, int.MaxValue, new int[] {5,int.MaxValue,7})]
        [TestCase(new int[] {5}, 0, 3, new int[] {3})]
        public void SetByIndexTest(int[] arr, int index, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(arr);
            ArrayList expected = new ArrayList(expectedArray);
            actual[index] = value;
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {5,6,7}, 7)]
        [TestCase(new int[] {-1,6,1,4,5,6,7,2,1}, -1)]
        [TestCase(new int[] {6,7,8,9,10}, 10)]
        [TestCase(new int[] {5,5,1}, 5)]
        [TestCase(new int[] {}, 77)]
        public void SetByIndexNegativeTest(int[] arr, int index)
        {
            ArrayList actual = new ArrayList(arr);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                actual[index]=0; 
            });
        }

        [TestCase(new int[] {1,2,3}, 2)]
        [TestCase(new int[] {5,5,5}, 0)]
        [TestCase(new int[] {5}, 0)]
        [TestCase(new int[] {-4,4}, 1)]
        [TestCase(new int[] {-4,-5}, 0)]
        [TestCase(new int[] {0,2,0}, 1)]
        [TestCase(new int[] {2,0,0}, 0)]
        public void GetMaxIndexTest(int[] arr, int expected)
        {
            ArrayList arraylist = new ArrayList(arr);
            int actual = arraylist.GetMaxIndex();
            Assert.AreEqual(expected, actual);
        }
        
        
        [TestCase(new int[] {})]
        public void GetMaxIndexNegativeTest(int[] arr)
        {
            ArrayList arrayList = new ArrayList(arr);
            Assert.Throws<NullReferenceException>(() =>
            {
                arrayList.GetMaxIndex();
            });
        }

        [TestCase(new int[] {1,2,3}, 0)]
        [TestCase(new int[] {5,5,5}, 0)]
        [TestCase(new int[] {5}, 0)]
        [TestCase(new int[] {-4,4}, 0)]
        [TestCase(new int[] {-4,-5}, 1)]
        [TestCase(new int[] {0,2,0}, 0)]
        [TestCase(new int[] {2,0,0}, 1)]
        public void GetMinIndexTest(int[] arr, int expected)
        {
            ArrayList arrayList = new ArrayList(arr);
            int actual = arrayList.GetMinIndex();
            Assert.AreEqual(expected,actual);
        }
        
        [TestCase(new int[] {})]
        public void GetMinIndexNegativeTest(int[] arr)
        {
            ArrayList arrayList = new ArrayList(arr);
            Assert.Throws<NullReferenceException>(() =>
            {
                arrayList.GetMaxIndex();
            });
        }
        
        [TestCase(new int[] {1,2,3}, 3)]
        [TestCase(new int[] {5,5,5}, 5)]
        [TestCase(new int[] {5}, 5)]
        [TestCase(new int[] {-4,4}, 4)]
        [TestCase(new int[] {-4,-5}, -4)]
        [TestCase(new int[] {0,2,0}, 2)]
        [TestCase(new int[] {2,0,0}, 2)]
        public void GetMaxTest(int[] arr, int expected)
        {
            ArrayList arraylist = new ArrayList(arr);
            int actual = arraylist.GetMax();
            Assert.AreEqual(expected, actual);
        }
        
        
        [TestCase(new int[] {})]
        public void GetMaxNegativeTest(int[] arr)
        {
            ArrayList arrayList = new ArrayList(arr);
            Assert.Throws<NullReferenceException>(() =>
            {
                arrayList.GetMax();
            });
        }

        [TestCase(new int[] {1,2,3}, 1)]
        [TestCase(new int[] {5,5,5}, 5)]
        [TestCase(new int[] {5}, 5)]
        [TestCase(new int[] {-4,4}, -4)]
        [TestCase(new int[] {-4,-5}, -5)]
        [TestCase(new int[] {0,2,0}, 0)]
        [TestCase(new int[] {2,0,0}, 0)]
        public void GetMinTest(int[] arr, int expected)
        {
            ArrayList arrayList = new ArrayList(arr);
            int actual = arrayList.GetMin();
            Assert.AreEqual(expected,actual);
        }
        
        [TestCase(new int[] {})]
        public void GetMinNegativeTest(int[] arr)
        {
            ArrayList arrayList = new ArrayList(arr);
            Assert.Throws<NullReferenceException>(() =>
            {
                arrayList.GetMin();
            });
        }

        [TestCase(new int[]{1,2,5,6}, new int[]{1,2,5,6})]
        [TestCase(new int[]{1,1,1,1}, new int[]{1,1,1,1})]
        [TestCase(new int[]{1}, new int[]{1})]
        [TestCase(new int[]{}, new int[]{})]
        [TestCase(new int[]{-1,8,0}, new int[]{-1,0,8})]
        [TestCase(new int[]{-1,0,0}, new int[]{-1,0,0})]
        [TestCase(new int[]{99,1,0}, new int[]{0,1,99})]
        public void SortAscendingTest(int[] arr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(arr);
            ArrayList expected = new ArrayList(expectedArr);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[]{1,2,5,6}, new int[]{6,5,2,1})]
        [TestCase(new int[]{1,1,1,1}, new int[]{1,1,1,1})]
        [TestCase(new int[]{1}, new int[]{1})]
        [TestCase(new int[]{}, new int[]{})]
        [TestCase(new int[]{-1,8,0}, new int[]{8,0,-1})]
        [TestCase(new int[]{-1,0,0}, new int[]{0,0,-1})]
        [TestCase(new int[]{99,1,0}, new int[]{99,1,0})]
        public void SortDescendingTest(int[] arr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(arr);
            ArrayList expected = new ArrayList(expectedArr);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }
        
    }
}