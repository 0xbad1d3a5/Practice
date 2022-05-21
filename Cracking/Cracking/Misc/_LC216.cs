using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Find all valid combinations of k numbers that sum up to n such that the following conditions are true:

    Only numbers 1 through 9 are used.
    Each number is used at most once.

    Return a list of all possible valid combinations. The list must not contain the same combination twice, and the combinations may be returned in any order.
 */
namespace Cracking.Misc
{
    class LC216
    {
        public IList<IList<int>> CombinationSum3(int k, int n) 
        {
            IList<IList<int>> ans = new List<IList<int>>();

            recurse(k, n, 0, 0, ans);

            return ans;
        }

        public void recurse(int numsLeft, int targetNumber, int currNum, int currListBits, IList<IList<int>> ans)
        {
            if (currNum == targetNumber && numsLeft == 0)
            {
                IList<int> oneAns = new List<int>();

                for (int i = 1; i < 10; i++)
                {
                    if ((currListBits & (1 << i)) > 0)
                    {
                        oneAns.Add(i);
                    } 
                }
                ans.Add(oneAns);
                return;
            }

            if (currNum > targetNumber || numsLeft == 0)
            {
                return;
            }

            int currListBitsMask = currListBits >> 1;
            int startNum = 1;

            while (currListBitsMask > 0)
            {
                currListBitsMask = currListBitsMask >> 1;
                startNum++;
            }
            
            for (int i = startNum; i < 10; i++)
            {
                int mask = currListBits & 1 << i;
                if (mask == 0)
                {
                    int currList = currListBits | 1 << i;
                    recurse(numsLeft - 1, targetNumber, currNum + i, currList, ans);
                }
            }
        }
    }

    [TestClass]
    public class Tests_LC216
    {
        [TestMethod]
        public void Test()
        {
            LC216 test = new LC216();
            var a = test.CombinationSum3(4, 1);
        }
    }
}
