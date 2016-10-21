using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a method to sort an array of strings so that all the anagrams are next to
 * each other
 */
namespace Cracking.Chapter11
{
    class _2
    {
        public static string[] sortArrayOfStrings(string[] array)
        {

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < array.Length; i++)
            {
                string sortedStr = sortedString(array[i]);

                if (!dict.ContainsKey(sortedStr))
                {
                    dict[sortedStr] = new List<String>();
                }
                dict[sortedStr].Add(array[i]);
            }

            return dict.Values.Aggregate(new List<string>(), (acc, x) => { acc.AddRange(x); return acc; }).ToArray();
        }

        private static string sortedString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Sort(arr);
            return new String(arr);
        }
    }

    [TestClass]
    public class Tests_11_2
    {
        [TestMethod]
        public void Test()
        {
            var result = _2.sortArrayOfStrings(new string[] { "cat", "dog", "tac", "god" });
        }
    }
}
