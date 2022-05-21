using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

    Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    You may assume that you have an infinite number of each kind of coin.
 */
namespace Cracking.Misc
{
    class LC322
    {
        public int CoinChange(int[] coins, int amount) 
        {
            int[] dp = new int[amount + 1];
            dp[0] = 0;

            for (int idx = 1; idx <= amount; idx++)
            {
                List<int> dpsAtIdx = new List<int>();

                foreach (int coin in coins)
                {
                    int amountLeft = idx - coin;

                    if (amountLeft == 0)
                    {
                        dpsAtIdx.Add(1);
                    }
                    else if (amountLeft < 0)
                    {
                        dpsAtIdx.Add(-1);
                    }
                    else 
                    {
                        dpsAtIdx.Add(dp[amountLeft] > 0 ? 1 + dp[amountLeft] : -1);
                    }
                }

                IEnumerable<int> hasSolution = dpsAtIdx.Where(x => x > 0);
                dp[idx] = hasSolution.Count() > 0 ? hasSolution.Min() : -1;
            }

            return dp[amount];
        }
    }

    [TestClass]
    public class Tests_LC322
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
