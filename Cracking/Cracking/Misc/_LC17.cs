using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

    A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
 */
namespace Cracking.Misc
{
    class LC17
    {
        string[] lettersMap = {"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

        public IList<string> LetterCombinations(string digits) 
        {
            List<string> ans = new List<string>();

            if (digits == "")
            {
                return ans;
            }

            recurse(digits, "", ans);

            return ans;
        }

        public void recurse(string digits, string soFar, List<string> ans)
        {
            if (digits == "")
            {
                ans.Add(soFar);
                return;
            }

            string letters = lettersMap[Int32.Parse(digits[0].ToString())];
            
            foreach (char c in letters)
            {
                recurse(digits.Substring(1), soFar + c, ans);
            }
        }
    }

    [TestClass]
    public class Tests_LC17
    {
        [TestMethod]
        public void Test()
        {
            LC17 test = new LC17();
            var a = test.LetterCombinations("23");
        }
    }
}
