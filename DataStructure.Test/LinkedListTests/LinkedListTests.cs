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
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] {1, 2}, -1)]
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
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] {1, 2}, -1)]
        public void SetByIndexNegativeTests(int[] arr, int index)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            Assert.Throws<IndexOutOfRangeException>(() => { actual[index] = 1; });
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

        [TestCase(new int[] {1}, new int[] {1, 2}, 2)]
        [TestCase(new int[] { }, new int[] {1}, 1)]
        [TestCase(new int[] {1, 2, 3, 4, 5}, new int[] {1, 2, 3, 4, 5, 6}, 6)]
        [TestCase(new int[] {9, 2, 3}, new int[] {9, 2, 3, 6}, 6)]
        [TestCase(new int[] {9, 2, 3, 6}, new int[] {9, 2, 3, 6, -1}, -1)]
        [TestCase(new int[] {9, 2, 3, 6, -1}, new int[] {9, 2, 3, 6, -1, 7}, 7)]
        public void AddTests(int[] arr, int[] expectedArr, int value)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expectedArr);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1}, new int[] {1, 2}, new int[] {2})]
        [TestCase(new int[] { }, new int[] {1}, new int[] {1})]
        [TestCase(new int[] { }, new int[] {1, 2, 3, 4, 5, 6}, new int[] {1, 2, 3, 4, 5, 6})]
        [TestCase(new int[] {9, 2, 3}, new int[] {9, 2, 3, 1, 77, 7}, new int[] {1, 77, 7})]
        [TestCase(new int[] {9, 2, 3, 6}, new int[] {9, 2, 3, 6}, new int[] { })]
        [TestCase(new int[] {9, 2, 3, 6, -1}, new int[] {9, 2, 3, 6, -1, 7, 8, 9}, new int[] {7, 8, 9})]
        public void AddTests(int[] arr, int[] expectedArr, int[] values)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expectedArr);
            actual.Add(values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1, 2, 3}, 3)]
        [TestCase(new int[] {1, 3, 2}, 3)]
        [TestCase(new int[] {3, 1, 2}, 3)]
        [TestCase(new int[] {3}, 3)]
        [TestCase(new int[] {3, -1}, 3)]
        [TestCase(new int[] {-77, -1}, -1)]
        [TestCase(new int[] {-1, -77}, -1)]
        [TestCase(new int[] {0, 0, 0}, 0)]
        public void GetMaxTests(int[] arr, int expected)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);
            int actual = actualList.GetMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxNegativeTests(int[] arr)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);

            Assert.Throws<NullReferenceException>(() => { actualList.GetMax(); });
        }

        [TestCase(new int[] {1, 2, 3}, 1)]
        [TestCase(new int[] {1, 3, 2}, 1)]
        [TestCase(new int[] {3, 1, 2}, 1)]
        [TestCase(new int[] {3}, 3)]
        [TestCase(new int[] {3, -1}, -1)]
        [TestCase(new int[] {-77, -1}, -77)]
        [TestCase(new int[] {-1, -77}, -77)]
        [TestCase(new int[] {0, 0, 0}, 0)]
        public void GetMinTests(int[] arr, int expected)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);
            int actual = actualList.GetMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinNegativeTests(int[] arr)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);

            Assert.Throws<NullReferenceException>(() => { actualList.GetMin(); });
        }
        
        [TestCase(new int[] {1, 2, 3}, 2)]
        [TestCase(new int[] {1, 3, 2}, 1)]
        [TestCase(new int[] {3, 1, 2}, 0)]
        [TestCase(new int[] {3}, 0)]
        [TestCase(new int[] {3, -1}, 0)]
        [TestCase(new int[] {-77, -1}, 1)]
        [TestCase(new int[] {-1, -77}, 0)]
        [TestCase(new int[] {0, 0, 0}, 0)]
        public void GetMaxIndexTests(int[] arr, int expected)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);
            int actual = actualList.GetMaxIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxIndexNegativeTests(int[] arr)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);

            Assert.Throws<NullReferenceException>(() => { actualList.GetMaxIndex(); });
        }

        [TestCase(new int[] {1, 2, 3}, 0)]
        [TestCase(new int[] {3, 2, 1}, 2)]
        [TestCase(new int[] {3, 1, 2}, 1)]
        [TestCase(new int[] {3}, 0)]
        [TestCase(new int[] {3, -1}, 1)]
        [TestCase(new int[] {-77, -1}, 0)]
        [TestCase(new int[] {-1, -77}, 1)]
        [TestCase(new int[] {0, 0, 0}, 0)]
        public void GetMinIndexTests(int[] arr, int expected)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);
            int actual = actualList.GetMinIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinIndexNegativeTests(int[] arr)
        {
            LinkedList.LinkedList actualList = new LinkedList.LinkedList(arr);

            Assert.Throws<NullReferenceException>(() => { actualList.GetMinIndex(); });
        }

        [TestCase(new int[] {3,2,1}, new int[] {1,2,3})]
        [TestCase(new int[] {2,3,1}, new int[] {1,2,3})]
        [TestCase(new int[] {1,3,2}, new int[] {1,2,3})]
        [TestCase(new int[] {1}, new int[] {1})]
        [TestCase(new int[] {1,1,1}, new int[] {1,1,1})]
        [TestCase(new int[] {}, new int[] {})]
        public void SortAscendingTests(int[] arr, int[] expectedArr)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expectedArr);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] {3,2,1}, new int[] {3,2,1})]
        [TestCase(new int[] {2,3,1}, new int[] {3,2,1})]
        [TestCase(new int[] {1,3,2}, new int[] {3,2,1})]
        [TestCase(new int[] {1}, new int[] {1})]
        [TestCase(new int[] {1,1,1}, new int[] {1,1,1})]
        [TestCase(new int[] {}, new int[] {})]
        public void SortDescendingTests(int[] arr, int[] expectedArr)
        {
            LinkedList.LinkedList actual = new LinkedList.LinkedList(arr);
            LinkedList.LinkedList expected = new LinkedList.LinkedList(expectedArr);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }
    }
}