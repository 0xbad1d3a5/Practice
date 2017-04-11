using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * An array A contains all the integers from 0 to n, except for one number which is
 * missing. In this problem, we cannot access an entire integer in A with a single
 * operation. The elements of A are represented in binary, and the only operation
 * we can use to access them is "fetch the jth bit of A[i]," which takes constant
 * time. Write code to find the missing integer. Can you do it in 0(n) time?
 */
namespace Cracking.Chapter05
{
    class _07
    {
        public static int getBit(List<int> list, int pos, int bit)
        {
            return (list[pos] >> bit) & 1;
        }

        public static int[] countBitsInPosition(List<int> list, int pos){
            
            int[] result = new int[2] {0, 0};

            for (int i = 0; i < list.Count; i++)
            {
                if (getBit(list, i, pos) == 0)
                {
                    result[0]++;
                }
                else
                {
                    result[1]++;
                }
            }

            return result;
        }

        public static int findMissingNumber(List<int> list)
        {
            int result = 0;

            for (int i = 0; i < 32; i++)
            {
                if (list.Count == 0)
                {
                    return result;
                }

                int[] zeroOneCount = countBitsInPosition(list, i);
                List<int> newList = new List<int>();

                if (zeroOneCount[1] >= zeroOneCount[0])
                {
                    result = result << 1;
                }
                else
                {
                    result = (result << 1) | 1;
                }

                for (int k = 0; k < list.Count; k++)
                {
                    if (zeroOneCount[1] >= zeroOneCount[0] && getBit(list, k, i) == 0)
                    {
                        newList.Add(list[k]);
                    }
                    else if (getBit(list, k, i) == 1)
                    {
                        newList.Add(list[k]);
                    }
                }

                list = newList;
            }

            return -1;
        }
    }

    [TestClass]
    public class Tests_05_07
    {
        [TestMethod]
        public void Test()
        {
            List<int> list = new List<int> { 0, 1, 2, 4, 5 };
            Assert.AreEqual(3, _07.findMissingNumber(list));
        }

        [TestMethod]
        public void TestRandom()
        {
            Random r = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int listSize = r.Next(2, Int32.MaxValue - 1) + 1;
                List<int> list = Enumerable.Range(0, listSize).ToList();

                int placeToRemove = r.Next(1, listSize - 1);
                int removedNum = list[placeToRemove];
                list.RemoveAt(placeToRemove);

                Assert.AreEqual(removedNum, _07.findMissingNumber(list));
            }
        }
    }
}
