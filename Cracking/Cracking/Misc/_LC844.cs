using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

    Note that after backspacing an empty text, the text will continue empty.
 */
namespace Cracking.Misc
{
    class LC844
    {
        public bool BackspaceCompare(string s, string t) 
        {
            return build(s).Equals(build(t));
        }

        public string build(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else {
                    stack.Push(s[i]);
                }
            }

            return string.Join("", stack.ToArray());
        }
    }

    [TestClass]
    public class Tests_LC844
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
