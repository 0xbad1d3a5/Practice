using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Implement a method to perform basic string compression using the counts
 * of repeated characters. For example, the string aabcccccaaa would become
 * a2blc5a3. If the "compressed" string would not become smaller than the orig-
 * inal string, your method should return the original string.
 */
namespace Cracking.Chapter01
{
    class _5
    {
        // Does not handle UTF-16 surrogate pairs
        public static string CompressString(string str)
        {
            if (str == null || str == "")
            {
                return str;
            }

            int charCount = 0;
            char currentChar = str[0];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == currentChar)
                {
                    charCount++;
                }
                else
                {
                    sb.Append(currentChar);
                    sb.Append(charCount);

                    charCount = 0;
                    currentChar = str[i];
                }
            }
            sb.Append(currentChar);
            sb.Append(charCount);

            if (sb.Length < str.Length)
            {
                return sb.ToString();
            }
            else
            {
                return str;
            }
        }
    }

    [TestClass]
    public class Tests_01_5
    {
       [TestMethod] 
        public void Test(){
            var s = _5.CompressString("aabbcccc");
            var c = _5.CompressString("aaaaaaaaaaaaaaaaAAAAAAAAAAAA");
       }
    }
}
