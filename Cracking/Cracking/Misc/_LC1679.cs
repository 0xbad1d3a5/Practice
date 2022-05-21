using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given an integer array nums and an integer k.

    In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.

    Return the maximum number of operations you can perform on the array.
 */
namespace Cracking.Misc
{
    class LC1679
    {
        public int MaxOperations(int[] nums, int k) 
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int key = k - nums[i];

                if (map.ContainsKey(key) && map[key] > 0)
                {
                    count++;
                    map[key] = map[key] - 1;
                }
                else 
                {
                    map[nums[i]] = map.GetValueOrDefault(nums[i], 0) + 1;
                }
            }

            return count;
        }
    }

    [TestClass]
    public class Tests_LC1679
    {
        [TestMethod]
        public void Test()
        {
            LC1679 test = new LC1679();
            test.MaxOperations(new int[] {1, 2, 3, 4}, 5);
        }
    }
}
