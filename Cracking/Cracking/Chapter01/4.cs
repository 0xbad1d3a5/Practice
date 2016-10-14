using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Write a method to replace all spaces in a string with'%20'. You may assume that
 * the string has sufficient space at the end of the string to hold the additional
 * characters, and that you are given the "true" length of the string. (Note: if imple-
 * menting in Java, please use a character array so that you can perform this opera-
 * tion in place.)
 *
 * EXAMPLE
 * Input: "Mr John Smith    "
 * Output: "Mr%20Dohn%20Smith"
 */
namespace Cracking.Chapter01
{
    class _4
    {
        public static char[] ReplaceSpacesWithPercentTwenty(char[] charArray)
        {
            int lastChar = charArray.Length - 1;
            int readingPointer = lastChar;
            int writingPointer = lastChar;

            while (charArray[readingPointer] == ' ')
            {
                readingPointer--;
            }

            while (readingPointer >= 0)
            {
                if (charArray[readingPointer] == ' ')
                {
                    charArray[writingPointer] = '0'; writingPointer--;
                    charArray[writingPointer] = '2'; writingPointer--;
                    charArray[writingPointer] = '%'; writingPointer--;
                }
                else
                {
                    charArray[writingPointer] = charArray[readingPointer]; writingPointer--;
                }
                readingPointer--;
            }

            return charArray;
        }

        public static char[] StringToCharArrayWithSpace(string str)
        {
            int spaceCount = str.Count(c => c == ' ');
            int arraySize = str.Length - spaceCount + (spaceCount * 3);
            char[] charArray = new char[arraySize];

            int charPos = 0;
            for (charPos = 0; charPos < str.Length; charPos++)
            {
                charArray[charPos] = str[charPos];
            }
            for (; charPos < charArray.Length; charPos++)
            {
                charArray[charPos] = ' ';
            }

            return charArray;
        }
    }

    [TestClass]
    public class Tests_1_4
    {

        [TestMethod]
        public void Test()
        {
            var charArray = _4.StringToCharArrayWithSpace("Mr John Smith");
            var result = _4.ReplaceSpacesWithPercentTwenty(charArray);
        }
    }
}
