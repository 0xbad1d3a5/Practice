using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a function to determine the number of bits required to convert integer A
 * to integer B.
 * 
 * EXAMPLE
 * Input: 31,14
 * Output: 2
 */
namespace Cracking.Chapter05
{
    /*
     * 1) XOR integer A with integer B
     * 2) Count the number of 1's in the result
     */
    class _05
    {
        public static int countBits(uint num)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((num & 1) == 1)
                {
                    count++;
                }
                num = num >> 1;
            }
            return count;
        }

        public static int numBitsDifference(uint A, uint B)
        {
            return countBits(A ^ B);
        }
    }

    [TestClass]
    public class Tests_05_05
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2, _05.numBitsDifference(1, 2));
            Assert.AreEqual(0, _05.numBitsDifference(1, 1));
        }
    }
}
