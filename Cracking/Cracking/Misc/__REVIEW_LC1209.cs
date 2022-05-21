using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    You are given a string s and an integer k, a k duplicate removal consists of choosing k adjacent and equal letters from s and removing them, causing the left and the right side of the deleted substring to concatenate together.

    We repeatedly make k duplicate removals on s until we no longer can.

    Return the final string after all such duplicate removals have been made. It is guaranteed that the answer is unique.
 */
namespace Cracking.Misc
{
    class LC1209
    {
        public string RemoveDuplicates(string s, int k)
        {
            Stack<Tuple<char, int>> stack = new Stack<Tuple<char, int>>();

            foreach (char c in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(Tuple.Create(c, 1));
                }
                else 
                {
                    var prev = stack.Peek();
                    char prevChar = prev.Item1;
                    int prevTimes = prev.Item2;
                    
                    if (prevChar == c)
                    {
                        stack.Pop();
                        int newTimes = prevTimes + 1;

                        if (newTimes < k)
                        {
                            stack.Push(Tuple.Create(c, newTimes));
                        }
                    }
                    else 
                    {
                        stack.Push(Tuple.Create(c, 1));
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            while (stack.Count > 0)
            {
                var c = stack.Pop();

                for (int i = 0; i < c.Item2; i++)
                {
                    sb.Append(c.Item1);
                }
            }
            
            string ans = new string(sb.ToString().Reverse().ToArray());

            return ans;
        }
    }

    [TestClass]
    public class Tests_LC1209
    {
        [TestMethod]
        public void Test()
        {
            LC1209 test = new LC1209();
            test.RemoveDuplicates("pbbcggttciiippooaais", 2);
        }
    }
}
