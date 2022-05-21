using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    You are given a nested list of integers nestedList. Each element is either an integer or a list whose elements may also be integers or other lists. Implement an iterator to flatten it.

    Implement the NestedIterator class:

    NestedIterator(List<NestedInteger> nestedList) Initializes the iterator with the nested list nestedList.
    int next() Returns the next integer in the nested list.
    boolean hasNext() Returns true if there are still some integers in the nested list and false otherwise.

    Your code will be tested with the following pseudocode:

        initialize iterator with nestedList
        res = []
        while iterator.hasNext()
            append iterator.next() to the end of res
        return res

    If res matches the expected flattened list, then your code will be judged as correct.
 */
namespace Cracking.Misc
{
    class LC341
    {
        public class NestedIterator {

            Stack<NestedInteger> stack = new Stack<NestedInteger>();

            public NestedIterator(IList<NestedInteger> nestedList) 
            {
                for (int i = nestedList.Count - 1; i >= 0; i--)
                {
                    stack.Push(nestedList[i]);
                }
            }

            public bool HasNext() 
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                NestedInteger nestedInt = stack.Pop();

                if (nestedInt.IsInteger())
                {
                    stack.Push(nestedInt);
                    return true;
                }
                else
                {
                    IList<NestedInteger> nestedList = nestedInt.GetList();

                    for (int i = nestedList.Count - 1; i >= 0; i--)
                    {
                        stack.Push(nestedList[i]);
                    }

                    return HasNext();
                }
            }

            public int Next() 
            {
                NestedInteger nestedInt = stack.Pop();

                if (nestedInt.IsInteger())
                {
                    return nestedInt.GetInteger();
                }
                else 
                {
                    IList<NestedInteger> nestedList = nestedInt.GetList();
                    
                    for (int i = nestedList.Count - 1; i >= 0; i--)
                    {
                        stack.Push(nestedList[i]);
                    }

                    return Next();
                }    
            }
        }

        public class NestedInteger {
          
            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            public bool IsInteger()
            {
                return true;
            }
        
            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            public int GetInteger()
            {
                return 0;
            }
        
            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            public IList<NestedInteger> GetList()
            {
                return new List<NestedInteger>();
            }
        }
    }

    [TestClass]
    public class Tests_LC341
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
