using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].

    Return true if there is a 132 pattern in nums, otherwise, return false.
 */
namespace Cracking.Misc
{
    class LC456
    {
        public bool Find132pattern(int[] nums) 
        {
            Stack<int> stack = new Stack<int>();

            int thirdEle = Int32.MinValue;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] < thirdEle)
                {
                    return true;
                }

                while (stack.Count > 0 && stack.Peek() < nums[i])
                {
                    thirdEle = stack.Pop();
                }

                stack.Push(nums[i]);
            }

            return false;
        }
    }

    [TestClass]
    public class Tests_LC456
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
