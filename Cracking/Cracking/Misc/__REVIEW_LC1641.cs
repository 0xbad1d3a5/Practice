using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an integer n, return the number of strings of length n that consist only of vowels (a, e, i, o, u) and are lexicographically sorted.

    A string s is lexicographically sorted if for all valid i, s[i] is the same as or comes before s[i+1] in the alphabet.
 */
namespace Cracking.Misc
{
    class LC1641
    {
        public int CountVowelStrings(int n) 
        {
            int[,] dp = new int[5, n];

            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dp[i, k] = -1;
                }
            }

            return recurseDp(n, 0, dp);
        }

        public int recurseDp(int n, int i, int[,] dp)
        {
            if (n == 0)
            {
                return 1;
            }

            if (i >= 5)
            {
                return 0;
            }

            if (dp[i, n - 1] != -1)
            {
                return dp[i, n - 1];
            }

            int pick = recurseDp(n - 1, i, dp);
            int notPick = recurseDp(n, i + 1, dp);

            return dp[i, n - 1] = pick + notPick;
        }

        public int recurse(int n, string s)
        {
            if (n == 0)
            {
                return 1;
            }

            int lastChar = s.Length == 0 ? 0 : s[s.Length - 1];
            int count = 0;

            foreach (char c in "aeiou".Where(x => x >= lastChar))
            {
                count += recurse(n - 1, s + c);
            }

            return count;
        }
    }

    [TestClass]
    public class Tests_LC1641
    {
        [TestMethod]
        public void Test()
        {
            LC1641 test = new LC1641();
            var a = test.CountVowelStrings(33);
        }
    }
}
