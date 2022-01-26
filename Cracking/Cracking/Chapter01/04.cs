using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Palindrome Permutation:
 * 
 * Given a string, white a function to check if it is a permutation of a palindrome. A
 * palindrome is a word or phrase that is the same forwards or backwards. A permutation
 * is a rearrangement of letters. The palindrome does not need to be limited to just
 * dictionary words.
 * 
 * EX: Input: "Tact Coa"
 *    Output:  True ("taco cat", "atco cta", etc...)
 * 
 * Assumptions:
 * - Spaces do not matter, and we are only limited to A-Z. Case does not matter.
 * - A palindrome will always have a even number of each letter, except for one,
 * which can be in the center.
 */
namespace Cracking.Chapter01
{
    class _04
    {
        public static bool isPalindromePermutation(string input) 
        {
            string inputLower = input.ToLower();

            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int numOddCharCounts = 0;

            for (int i = 0; i < inputLower.Length; i++)
            {
                if (inputLower[i] == ' ')
                {
                    continue;
                }

                if (!charCount.ContainsKey(inputLower[i]))
                {
                    charCount[inputLower[i]] = 0;
                }

                charCount[inputLower[i]] += 1;

                if (charCount[inputLower[i]] % 2 == 1)
                {
                    numOddCharCounts += 1;
                }
                else
                {
                    numOddCharCounts -= 1;
                }
            }

            return numOddCharCounts == 0 || numOddCharCounts == 1;
        }

        public static bool isPalindromePermutationVectorBit(string input)
        {
            string inputLower = input.ToLower();

            int charCount = 0;
            int numOddCharCounts = 0;

            for (int i = 0; i < inputLower.Length; i++)
            {
                if (inputLower[i] == ' ')
                {
                    continue;
                }

                int letter = inputLower[i] - 'a';

                if (letter < 0 || letter > 23)
                {
                    return false; // characters outside a-z not supported
                }

                int bitmask = 1 << letter;
                charCount = charCount ^ bitmask;

                if ((charCount & bitmask) != 0)
                {
                    numOddCharCounts += 1;
                }
                else 
                {
                    numOddCharCounts -= 1;
                }
            }

            return numOddCharCounts == 0 || numOddCharCounts == 1;
        }
    }

    [TestClass]
    public class Tests_01_04
    {
        [TestMethod]
        public void TestTrue()
        {
            Assert.IsTrue(_04.isPalindromePermutation("Tact Coa"));
            Assert.IsTrue(_04.isPalindromePermutation("a a"));
            Assert.IsTrue(_04.isPalindromePermutation("a"));
            Assert.IsTrue(_04.isPalindromePermutation("aab ba"));
            Assert.IsTrue(_04.isPalindromePermutation(""));

            Assert.IsTrue(_04.isPalindromePermutationVectorBit("Tact Coa"));
            Assert.IsTrue(_04.isPalindromePermutationVectorBit("a a"));
            Assert.IsTrue(_04.isPalindromePermutationVectorBit("a"));
            Assert.IsTrue(_04.isPalindromePermutationVectorBit("aab ba"));
            Assert.IsTrue(_04.isPalindromePermutationVectorBit(""));
        }

        
        [TestMethod]
        public void TestFalse()
        {
            Assert.IsFalse(_04.isPalindromePermutation("abc"));
            Assert.IsFalse(_04.isPalindromePermutation("ab c"));

            Assert.IsFalse(_04.isPalindromePermutationVectorBit("abc"));
            Assert.IsFalse(_04.isPalindromePermutationVectorBit("ab c"));
        }
    }
}
