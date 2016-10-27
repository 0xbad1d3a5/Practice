using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a sorted array of strings which is interspersed with empty strings, write a
 * method to find the location of a given string.
 * EXAMPLE
 * Input: find "ball" in { "at", "", "", "", "ball", "", "", "car",
 *                         "", "", "dad", "", "" }
 * Output: 4
 */
namespace Cracking.Chapter11
{
    class _05
    {
        public static int binarySearchStringSpaces(string[] stringArray, int start, int end, string search)
        {
            int mid = (end - start + 1) / 2;
            mid = closestNonEmptyString(stringArray, start, end);

            if (mid == -1)
            {
                return -1;
            }

            if (stringArray[mid].Equals(search))
            {
                return mid;
            }

            if (stringArray[mid].CompareTo(search) > 0)
            {
                return binarySearchStringSpaces(stringArray, mid, end, search);
            }
            else
            {
                return binarySearchStringSpaces(stringArray, start, mid - 1, search);
            }
        }

        // Cornerstone of this algorithm is to find the closest non-empty string if we hand on a empty string
        public static int closestNonEmptyString(string[] stringArray, int start, int end)
        {
            int mid = (end - start + 1) / 2;
            int pos = 0;
            bool stringPtrIsEmptyString1 = stringArray[mid - pos].Equals("");
            bool stringPtrIsEmptyString2 = stringArray[mid + pos].Equals("");

            while (stringPtrIsEmptyString1 && stringPtrIsEmptyString2)
            {
                pos++;

                if (mid - pos < start && mid + pos > end)
                {
                    break;
                }

                if (mid - pos >= start)
                {
                    stringPtrIsEmptyString1 = stringArray[mid - pos].Equals("");
                }
                if (mid + pos <= start)
                {
                    stringPtrIsEmptyString2 = stringArray[mid + pos].Equals("");
                }
            }

            if (stringPtrIsEmptyString1 && stringPtrIsEmptyString2)
            {
                return -1;
            }

            return stringPtrIsEmptyString1 ? mid + pos : mid - pos;
        }
    }

    [TestClass]
    public class Tests_11_05
    {
        [TestMethod]
        public void Test()
        {
            string[] stringArray = new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            int result = _05.binarySearchStringSpaces(stringArray, 0, stringArray.Length - 1, "ball");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test1()
        {
            string[] stringArray = new string[] { "at" };
            int result = _05.binarySearchStringSpaces(stringArray, 0, stringArray.Length - 1, "at");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test2()
        {
            string[] stringArray = new string[] { "", "at" };
            int result = _05.binarySearchStringSpaces(stringArray, 0, stringArray.Length - 1, "at");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test3()
        {
            string[] stringArray = new string[] { "", "", "", "", "", "" };
            int result = _05.binarySearchStringSpaces(stringArray, 0, stringArray.Length - 1, "at");
            Assert.AreEqual(-1, result);
        }
    }
}
