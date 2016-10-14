using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Assume you have a method isSubstring which checks if one word is a
 * substring of another. Given two strings, si and s2, write code to check if s2 is
 * a rotation of si using only one call to isSubstring (e.g., "waterbottle"is a rota-
 * tion of "erbottlewat")
 */
namespace Cracking.Chapter01
{
    class _8
    {
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
    public class Tests_1_8
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(_8.IsRotation("waterbottle", "erbottlewat"));
        }
    }
}
