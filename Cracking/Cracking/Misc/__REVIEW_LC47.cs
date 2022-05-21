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
    class LC47
    {
        public IList<IList<int>> PermuteUnique(int[] nums) 
        {
            HashSet<IList<int>> ans = new HashSet<IList<int>>(new IntListComparer());
            recurse(nums.ToList(), new List<int>(), ans);
            return ans.ToList();
        }

        public void recurse(List<int> nums, List<int> curr, HashSet<IList<int>> ans)
        {
            if (nums.Count == 0 && curr.Count > 0)
            {
                if (!ans.Contains(curr))
                {
                    ans.Add(curr);
                }
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

        class IntListComparer : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int> x, IList<int> y)
            {
                string stringX = string.Join(",", x.Select(x => x.ToString()));
                string stringY = string.Join(",", x.Select(y => y.ToString()));

                return stringX == stringY;
            }

            public int GetHashCode(IList<int> obj)
            {
                string code = string.Join(",", obj.Select(x => x.ToString()));
                return code.GetHashCode();
            }
        }
    }

    [TestClass]
    public class Tests_LC47
    {
        [TestMethod]
        public void Test()
        {
            LC47 test = new LC47();
            test.PermuteUnique(new int[] { 1, 1, 2});
        }
    }
}
