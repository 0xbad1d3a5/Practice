using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a program to swap odd and even bits in an integer with as few instructions
 * as possible (e.g., bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, and
 * so on).
 */
namespace Cracking.Chapter05
{
    /*
     * 
     */
    class _06
    {
        /*
         * When the left operand of the >> operator is of an unsigned integral type,
         * the operator performs a logical shift right wherein high-order empty bit
         * positions are always set to zero. 
         */
        public static uint swapEvenAndOddBits(uint n)
        {
            uint oddToEven = (n & 0x55555555) << 1;
            uint evenToOdd = (n & 0xAAAAAAAA) >> 1; // Must be logical right shift
            return oddToEven | evenToOdd;
        }
    }

    [TestClass]
    public class Tests_05_06
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(Convert.ToUInt32(2), _06.swapEvenAndOddBits(1));
            Assert.AreEqual(Convert.ToUInt32(1), _06.swapEvenAndOddBits(2));
            Assert.AreEqual(Convert.ToUInt32(10), _06.swapEvenAndOddBits(5));
            Assert.AreEqual(Convert.ToUInt32(5), _06.swapEvenAndOddBits(10));
            Assert.AreEqual(Convert.ToUInt32(4), _06.swapEvenAndOddBits(8));
        }
    }
}
