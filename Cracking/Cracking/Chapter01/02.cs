﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Given two strings, write a method to decide if one is a permutation of the other.
 */
namespace Cracking.Chapter01
{
    class _02
    {
        /* IMPORTANT QUESTIONS TO ASK:
         * 
         * What character encoding?
         * Is it case sensitive?
         * Does whitespace matter?
         * 
         * This solution simply builds two dictionaries then checks if the dictionaries
         * are equal.
         * 
         * Alternative solution: sort the strings and check if they are equal.
         */
        public static bool ArePermutation(string str1, string str2)
        {
            Dictionary<char, int> d1 = BuildDictionary(str1);
            Dictionary<char, int> d2 = BuildDictionary(str2);

            return AreEqualDictionaries(d1, d2);
        }

        private static Dictionary<char, int> BuildDictionary(string str)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (d.ContainsKey(c))
                {
                    d[c]++;
                }
                else
                {
                    d[c] = 1;
                }
            }

            return d;
        }

        public static bool AreEqualDictionaries(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            
            if (d1.Count != d2.Count)
            {
                return false;
            }

            foreach (char k in d1.Keys)
            {
                if (d1[k] != d2[k])
                {
                    return false;
                }
            }

            return true;
        }
    }

    [TestClass]
    public class Tests_01_02
    {

        [TestMethod]
        public void test(){
            Assert.IsTrue(_02.ArePermutation("abc", "cba"));
            Assert.IsTrue(_02.ArePermutation("aabbcc", "ccbbaa"));
            Assert.IsFalse(_02.ArePermutation("abc", "aabc"));
        }
    }
}
