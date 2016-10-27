using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a sorted array of n integers that has been rotated an unknown number of
 * times, write code to find an element in the array. You may assume that the array
 * was originally sorted in increasing order.
 * EXAMPLE
 * Input: find 5 in {15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}
 * Output: 8 (the index of 5 in the array)
 */
namespace Cracking.Chapter11
{
    /*
     * One half of the array will be sorted after a rotation. Determine which half is sorted, and check if value to search for lies in that subarray.
     * If it does, search that subarray, if it doesn't, search the other subarray - recursively.
     */
    class _03
    {
        public static int binarySearchRotatedArray(int[] array, int begin, int end, int search)
        {
            int mid = ((end - begin + 1) / 2) + begin;

            // found the element index, return
            if (array[mid] == search)
            {
                return mid;
            }
            // Since we make sure begin & end are always valid, we need to return here or we'll get a stackoverflow
            if (begin == end)
            {
                return -1;
            }

            // 3 possible cases:
            // Case 1: If array@[begin, mid, end] are the same values, then we can't really determine which side to do down, so we have to go down both.
            if (array[begin] == array[mid] && array[mid] == array[end])
            {
                return searchSubarray(array, begin, end, search);
            }
            // Case 2: Array@[begin < mid]; left subarray is sorted
            // If search falls between array@[begin, mid] recurse down array[begin, mid]
            // Otherwise, recurse down array[mid, end]
            else if (array[begin] <= array[mid])
            {
                if (array[begin] <= search && search <= array[mid])
                {
                    return searchSubarray(array, begin, mid, search);
                }
                else
                {
                    return searchSubarray(array, mid, end, search);
                }
            }
            // Case 3: Array@[mid < end]; right subarray is sorted
            // If search falls between array@[mid, end] recurse down array[mid, end]
            // Otherwise, recurse down array[begin, mid]
            else if (array[mid] <= array[end])
            {
                if (array[mid] <= search && search <= array[end])
                {
                    return searchSubarray(array, mid, end, search);
                }
                else
                {
                    return searchSubarray(array, begin, mid, search);
                }
            }
            // This should never happen
            else
            {
                throw new Exception();
            }
        }

        public static int searchSubarray(int[] array, int begin, int end, int search)
        {
            int midway = ((end - begin + 1) / 2) + begin;
            int leftIndex = binarySearchRotatedArray(array, begin, midway - 1, search);
            int rightIndex = binarySearchRotatedArray(array, midway, end, search);

            if (leftIndex > rightIndex)
            {
                return leftIndex;
            }
            else
            {
                return rightIndex;
            }
        }
    }

    [TestClass]
    public class Tests_11_03
    {
        [TestMethod]
        public void Test()
        {
            int[] array = new int[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int result = _03.binarySearchRotatedArray(array, 0, array.Length - 1, 5);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Test1()
        {
            int[] array = new int[] { 10, 15, 20, 0, 5 };
            int result = _03.binarySearchRotatedArray(array, 0, array.Length - 1, 5);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test2()
        {
            int[] array = new int[] { 50, 5, 20, 30, 40 };
            int result = _03.binarySearchRotatedArray(array, 0, array.Length - 1, 5);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test3()
        {
            int[] array = new int[] { 2, 2, 2, 3, 4, 2 };
            int result = _03.binarySearchRotatedArray(array, 0, array.Length - 1, 4);
            Assert.AreEqual(4, result);
        }
    }
}
