using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

    REVIEW FOR BACKTRACKING
 */
namespace Cracking.Misc
{
    class LC46
    {
        public IList<IList<int>> Permute(int[] nums) 
        {
            HashSet<IList<int>> ans = new HashSet<IList<int>>();
            recurse(nums.ToList(), new List<int>(), ans);

            return ans.ToList();
        }

        public void recurse(List<int> nums, List<int> curr, HashSet<IList<int>> ans)
        {
            if (nums.Count == 0 && curr.Count > 0)
            {
                ans.Add(curr);
            }

            for (int i = 0; i < nums.Count; i++)
            {
                int takeIdx = i;
                List<int> newList = nums.Take(i).Concat(nums.TakeLast(nums.Count - 1 - i)).ToList();
                List<int> newCurr = curr.ToList();
                newCurr.Add(nums[takeIdx]);

                recurse(newList, newCurr, ans);
            }
        }
    }

    [TestClass]
    public class Tests_LC46
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
