using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a positive integer, print the next smallest and the next largest number
 * that have the same number of 1 bits in their binary representation.
 */
namespace Cracking.Chapter05
{
    class _03
    {

        public static uint naiveNextLargestNumberSameBits(uint val)
        {
            int numBits = countNumberOfOnes(val);
            while (val != uint.MaxValue)
            {
                val++;
                if (countNumberOfOnes(val) == numBits)
                {
                    return val;
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        public static uint naiveNextSmallestNumberSameBits(uint val)
        {
            int numBits = countNumberOfOnes(val);
            while (val != uint.MinValue)
            {
                val--;
                if (countNumberOfOnes(val) == numBits)
                {
                    return val;
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        public static int countNumberOfOnes(uint num)
        {
            int count = 0;
            for (uint i = 0; i < 32; i++)
            {
                if ((num & 1) == 1)
                {
                    count++;
                }
                num = num >> 1;
            }
            return count;
        }

        public static uint nextLargestNumberSameBits(uint num)
        {
            uint mask = 1;
            int oneCount = 0;
            bool group = false;

            for (int i = 0; i < 32; i++)
            {
                group = group ? group : (num & mask) > 0;

                if (group)
                {
                    // end of group
                    if ((num & mask) == 0)
                    {
                        num = num | mask;
                        uint moveMask = 1;
                        for (int k = 1; k < mask; k = k << 1)
                        {
                            if (oneCount > 1)
                            {
                                num = num | moveMask;
                                oneCount--;
                            }
                            else
                            {
                                num = num & ~moveMask;
                            }
                            moveMask = moveMask << 1;
                        }
                        return num;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                mask = mask << 1;
            }

            throw new ArgumentOutOfRangeException();
        }

        /*
         * Doesn't work:
         * 		ruint	2959872977	uint 0b10110000011011000001001111010001
		 *       a	    2959872972	uint 0b10110000011011000001001111001100
		 *       b	    2959872963	uint 0b10110000011011000001001111000011
         */
        public static uint nextSmallestNumberSameBitsTry1(uint num)
        {
            int zeroPos = posOfFirstZero(num);
            return swapTwoBits(num, zeroPos, posOfFirstOneFromZero(num, zeroPos));
        }

        public static uint nextSmallestNumberSameBits(uint num)
        {
            int zeroPos = posOfFirstZero(num);
            int onePos = posOfFirstOneFromZero(num, zeroPos);
            uint result = swapTwoBits(num, onePos, onePos - 1);
            return moveTrailingOnes(result, onePos - 1);
        }

        private static int posOfFirstZero(uint num)
        {
            int pos = 0;
            uint mask = 1;

            for (int i = 0; i < 32; i++)
            {
                if ((num & mask ^ mask) > 0)
                {
                    return pos;
                }
                mask = mask << 1;
                pos++;
            }

            throw new ArgumentOutOfRangeException();
        }

        private static int posOfFirstOneFromZero(uint num, int startAt)
        {
            int pos = startAt;
            uint mask = Convert.ToUInt32(1) << startAt;

            for (int i = 0; i < 32 - startAt; i++)
            {
                if ((num & mask) > 0)
                {
                    return pos;
                }
                mask = mask << 1;
                pos++;
            }

            throw new ArgumentOutOfRangeException();
        }

        private static uint swapTwoBits(uint num, int bitOnePos, int bitTwoPos)
        {
            if (((num >> bitOnePos) & 1) != ((num >> bitTwoPos) & 1))
            {
                uint mask = (Convert.ToUInt32(1) << bitOnePos) | (Convert.ToUInt32(1) << bitTwoPos);
                num = num ^ mask;
            }

            return num;
        }

        private static uint moveTrailingOnes(uint num, int onePos)
        {
            int oneCount = 0;
            uint mask = 1;

            for (int i = 0; i < onePos; i++)
            {
                if ((num & mask) > 0)
                {
                    oneCount++;
                }
                mask = mask << 1;
            }

            mask = 1;

            for (int i = 0; i < onePos; i++)
            {
                if (onePos - i > oneCount)
                {
                    num = num & ~mask;
                }
                else
                {
                    num = num | mask;
                }
                mask = mask << 1;
            }

            return num;
        }
    }

    [TestClass]
    public class Tests_05_03
    {
        [TestMethod]
        public void TestNextLargestRandom()
        {
            Random r = new Random();

            for (int i = 0; i < 100000; i++)
            {
                Byte[] buffer = new byte[sizeof(uint)];
                r.NextBytes(buffer);
                uint ruint = BitConverter.ToUInt32(buffer, 0);

                uint a = _03.naiveNextLargestNumberSameBits(ruint);
                uint b = _03.nextLargestNumberSameBits(ruint);
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void TestNextSmallestRandom()
        {
            Random r = new Random();

            for (int i = 0; i < 100000; i++)
            {
                Byte[] buffer = new byte[sizeof(uint)];
                r.NextBytes(buffer);
                uint ruint = BitConverter.ToUInt32(buffer, 0);

                uint a = _03.naiveNextSmallestNumberSameBits(ruint);
                uint b = _03.nextSmallestNumberSameBits(ruint);
                Assert.AreEqual(a, b);
            }
        }
    }
}
