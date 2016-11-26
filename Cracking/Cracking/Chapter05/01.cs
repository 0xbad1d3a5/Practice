using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are given two 32-bit numbers, N and M, and two bit positions, i and j. Write
 * a method to insert M into N such that M starts at bit j and ends at bit i. You can
 * assume that the bits j through i have enough space to fit all of M. That is, if
 * M = 10011, you can assume that there are at least 5 bits between j and i. You
 * would not, for example, have j = 3 and i = 2, because M could not fully fit
 * between bit 3 and bit 2.
 * 
 * EXAMPLE
 * Input: N = 10000000000, M = 10011, i = 2, j = 6
 * Output: N = 10001001100
 */
namespace Cracking.Chapter05
{
    class _01
    {
        /*
         * Starts at bit x, ends at bit y
         * 
         * Steps:
         *
         * 1. Clear bits x through y in A
         * 2. Shift B to line up with cleared bits
         * 3. Merge A and B
         */
        public static int BitMerge(int A, int B, int x, int y)
        {
            // 1. Create bitmask to clear x through y
            int bitmask = ~0 << (y - x + 1) << x;
            bitmask = bitmask | unchecked((int)((uint)~0 >> (32 - x)));

            // Apply bitmask
            A = A & bitmask;
            
            // 2. Shift B to line up with bitmask
            B = B << x;

            // Return merged result
            return A | B;
        }
    }

    [TestClass]
    public class Tests_05_01
    {
        [TestMethod]
        public void Test()
        {
            int result = _01.BitMerge(-2147483648, 6, 1, 3);
            Assert.AreEqual(-2147483636, result);

            result = _01.BitMerge(-1, 6, 1, 3);
            Assert.AreEqual(-3, result);
        }
    }
}
