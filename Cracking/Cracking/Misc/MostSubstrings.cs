using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Find the most frequent occurences of a substring 
 */
namespace Cracking.Misc
{
    class MostSubstrings
    {
        public static int mostSubstrings(string input, int smallestSubstrLen, int LongestSubstrLen, int maxDistinctChars)
        {
            int mostFreq = -1;

            // Need to search for substrings of length K to L
            for (int i = smallestSubstrLen; i <= LongestSubstrLen; i++)
            {

                // Go through the array, slide to find all possible substrings of size K to L
                for (int j = 0; j < input.Length - i; j++)
                {

                    // Possible optimization: Store substr so that we don't need to compute numOccurrences if encountered again for that substr
                    string substr = input.Substring(j, i);

                    // Substring may only contain M distinct characters
                    // Does this condition make sense? aaaaxyzxyzxyzxyzxyz (xyz not counted, appears 5 times),
                    // but would still get 5 appearances of x,y,z (1-char) | xy,yz (2-char) so end-result would be the same
                    // Does the question mean the full input can't have more than M distinct characters?
                    if (numberOfDistinctChars(substr) > maxDistinctChars)
                    {
                        continue;
                    }

                    int numOccurrences = findNumberOfSubstrings(input, substr);

                    mostFreq = numOccurrences > mostFreq ? numOccurrences : mostFreq;
                }
            }

            return mostFreq;
        }

        public static int findNumberOfSubstrings(string str, string substr)
        {

            int count = 0;
            int index = 0;

            while (index != -1)
            {
                index = str.IndexOf(substr, index);
                if (index != -1)
                {
                    count++;
                    index += substr.Length;
                }
            }

            return count;
        }

        public static int numberOfDistinctChars(string str)
        {
            return new String(str.Distinct().ToArray()).Length;
        }
    }

    [TestClass]
    public class Tests_11_5
    {
        [TestMethod]
        public void Test()
        {
            int result = MostSubstrings.mostSubstrings("aaaa", 2, 2, 2);
        }
    }
}
