using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Implement an algorithm to determine if a string has all unique characters. What
 * if you cannot use additional data structures?
 */
namespace Cracking.Chapter01
{
    class _01
    {
        /*
         * Simple: Use a dictionary to keep track of encountered characters
         * O(n) runtime and O(k) space, where k is number of unique characters
         */
        public static bool isUniqueHashMap(string str)
        {
            Dictionary<char, bool> dict = new Dictionary<char, bool>();
            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    dict[c] = true;
                }
            }
            return true;
        }

        /*
         * Keep track of a subsection of the string starting from the beginning of the string.
         * When you move to the next character, scan the subsection of the string, if you find
         * the character again, there is a duplicate.
         * 
         * This is a O(n^2) algorithm.
         */
        public static bool isUniqueScanPrev(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int sub = 0; sub < i; sub++)
                {
                    if (str[sub] == str[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    [TestClass]
    public class Tests_01_01
    {
        [TestMethod]
        public void TestUniqueHashMap(){
            Assert.IsTrue(_01.isUniqueHashMap("abc"));
            Assert.IsTrue(_01.isUniqueHashMap("あabc"));
            Assert.IsFalse(_01.isUniqueHashMap("aabc"));
        }

        [TestMethod]
        public void TestUniqueScanPrev()
        {
            Assert.IsTrue(_01.isUniqueScanPrev("abc"));
            Assert.IsTrue(_01.isUniqueScanPrev("あabc"));
            Assert.IsFalse(_01.isUniqueScanPrev("aabc"));
        }
    }
}
