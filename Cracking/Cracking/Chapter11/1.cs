using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are given two sorted arrays, A and B, where A has a large enough buffer at
 * the end to hold B. Write a method to merge B into A in sorted order.
 */
namespace Cracking.Chapter11
{
    /*
     * Start from the empty back of the longer array, and work your way up to the front by comparing
     * values between the non-empty end of the longer array with the end of the shorter array.
     */
    class _1
    {
        public static void mergeSortedArrays(int[] longer, int[] shorter, int longerLength)
        {
            int shorterIndex = shorter.Length - 1;
            int longerIndex = longerLength - 1;
            int val;

            for (int i = longer.Length - 1; i >= 0; i--)
            {
                if (longerIndex < 0)
                {
                    val = shorter[i];
                    shorterIndex--;
                }
                else if (shorterIndex < 0)
                {
                    val = longer[i];
                    longerIndex--;
                }
                else
                {
                    if (longer[longerIndex] > shorter[shorterIndex])
                    {
                        val = longer[longerIndex];
                        longerIndex--;
                    }
                    else
                    {
                        val = shorter[shorterIndex];
                        shorterIndex--;
                    }
                }

                longer[i] = val;
            }
        }
    }

    [TestClass]
    public class Tests_11_1
    {
        [TestMethod]
        public void Test()
        {
            int[] longer = new int[] { 1, 3, 5, 6, 7, 7, 9, 0, 0, 0, 0, 0, 0 };
            int[] shorter = new int[] { 1, 2, 2, 4, 5, 6 };

            _1.mergeSortedArrays(longer, shorter, 7);

            Assert.IsTrue(Enumerable.SequenceEqual(longer, new int[] { 1, 1, 2, 2, 3, 4, 5, 5, 6, 6, 7, 7, 9 }));
        }

        [TestMethod]
        public void Test1()
        {
            int[] longer = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] shorter = new int[] { 1, 2, 2, 4, 5, 6 };

            _1.mergeSortedArrays(longer, shorter, 0);

            Assert.IsTrue(Enumerable.SequenceEqual(longer, new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void Test2()
        {
            int[] longer = new int[] { 1, 3, 5, 6, 7, 7, 9 };
            int[] shorter = new int[] { };

            _1.mergeSortedArrays(longer, shorter, 7);

            Assert.IsTrue(Enumerable.SequenceEqual(longer, new int[] { 1, 3, 5, 6, 7, 7, 9 }));
        }
    }
}
