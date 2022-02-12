using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * One Away: There are three types of edits that can be performed on strings:
 * insert a character, remove a character, or replace a character.
 * Given two strings, write a function to check if they are one edit (or zero edits)
 * away.
 * 
 * Hint:
 * - since the question only asks if they are one/zero edits away, string
 * length is helpful
 * - delete is the same thing as insert, just strings flipped
 */
namespace Cracking.Chapter01
{
    class _05
    {
        public static bool OneEditAway(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                return CanReplaceChar(s1, s2);
            }
            if (s1.Length == s2.Length - 1)
            {
                return CanInsertChar(s1, s2);
            }
            if (s2.Length == s1.Length - 1)
            {
                return CanInsertChar(s1, s2);
            }

            return false;
        }

        private static bool CanReplaceChar(string s1, string s2)
        {
            bool hasReplaced = false;

            for (int i = 0; i < s1.Length; i++)
            {
                if(s1[i] != s2[i]) 
                {
                    if (hasReplaced)
                    {
                        return false;
                    }
                    else
                    {
                        hasReplaced = true;
                    }
                }
            }

            return true;
        }

        private static bool CanInsertChar(string s1, string s2)
        {
            bool hasInserted = false;
            int p1 = 0, p2 = 0;

            while (p1 < s1.Length && p2 < s2.Length)
            {
                if (s1[p1] != s2[p2])
                {
                    if (hasInserted)
                    {
                        return false;
                    }
                    else 
                    {
                        hasInserted = true;
                        p2++;
                    }
                }
                p1++; p2++;
            }

            return true;
        }
    }

    [TestClass]
    public class Tests_01_05
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(_05.OneEditAway("pale", "ple"));
            Assert.IsTrue(_05.OneEditAway("ple", "pale"));
            Assert.IsTrue(_05.OneEditAway("pales", "pale"));
            Assert.IsTrue(_05.OneEditAway("bale", "pale"));
            
            Assert.IsFalse(_05.OneEditAway("pale", "bake"));
        }
    }
}
