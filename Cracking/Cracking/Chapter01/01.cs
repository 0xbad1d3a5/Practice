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
    }
}
