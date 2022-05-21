using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an integer array nums, move all the even integers at the beginning of the array followed by all the odd integers.

    Return any array that satisfies this condition.
 */
namespace Cracking.Misc
{
    class LC905
    {
        public int[] SortArrayByParity(int[] nums) 
        {
            if (nums.Length == 0)
            {
                return nums;
            }

            int i = 0;
            int k = nums.Length - 1;

            while (i != k)
            {
                if (nums[i] % 2 == 1 && nums[k] % 2 == 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[k];
                    nums[k] = temp;
                }
                else if (nums[i] % 2 == 0)
                {
                    i++;
                }
                else if (nums[k] % 2 == 1)
                { 
                    k--;
                }
            }

            return nums;
        }
    }

    [TestClass]
    public class Tests_LC905
    {
        [TestMethod]
        public void Test()
        {
            LC905 test = new LC905();
            test.SortArrayByParity(new [] {3,1,2,4});
        }
    }
}
