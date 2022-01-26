using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Assume you have a method isSubstring which checks if one word is a
 * substring of another. Given two strings, s1 and s2, write code to check if s2 is
 * a rotation of s1 using only one call to isSubstring (e.g., "waterbottle"is a rota-
 * tion of "erbottlewat")
 */
namespace Cracking.Chapter01
{
    class _09
    {
        /*
         * Since the word is chopped in half at some point, you can tell if s2 is a rotation of s1
         * by appending s2 onto itself. s2 + s2 will thus have the ending part of the word in the
         * first s2 joined with the starting part of the word in s2. Searching if s2 + s2 contains
         * the substring s1 would answer whether s2 was a rotation of s1.
         */
        public static bool IsRotation(string original, string rotated)
        {
            if (String.IsNullOrEmpty(original) && String.IsNullOrEmpty(rotated))
            {
                return true;
            }

            if (String.IsNullOrEmpty(original) || String.IsNullOrEmpty(rotated))
            {
                return false;
            }

            if (original.Length != rotated.Length)
            {
                return false;
            }

            if ((rotated + rotated).Contains(original))
            {
                return true;
            }

            return false;
        }
    }

    [TestClass]
    public class Tests_01_09
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(_09.IsRotation("waterbottle", "erbottlewat"));
        }
    }
}
