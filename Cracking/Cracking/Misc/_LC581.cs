using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an integer array nums, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order.

    Return the shortest such subarray and output its length.
 */
namespace Cracking.Misc
{
    class LC581
    {
        public int FindUnsortedSubarray(int[] nums) 
        {
            int[] cNums = (int[])nums.Clone();
            Array.Sort(nums);

            int start = nums.Length;
            int end = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != cNums[i])
                {
                    start = Math.Min(start, i);
                    end = Math.Max(end, i);
                }
            }

            return (end - start) > 0 ? end - start + 1 : 0;
        }
    }

    [TestClass]
    public class Tests_LC581
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
