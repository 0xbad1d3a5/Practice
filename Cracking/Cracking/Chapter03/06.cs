using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a program to sort a stack in ascending order (with biggest items on top).
 * You may use at most one additional stack to hold items, but you may not copy
 * the elements into any other data structure (such as an array). The stack supports
 * the following operations: push, pop, peek, and isEmpty.
 */
namespace Cracking.Chapter03
{
    class _06
    {
        public static void sortStack(Stack<int> stack)
        {
            if (stack.Count == 0 || stack.Count == 1)
            {
                return;
            }

            Stack<int> tempStack = new Stack<int>();
            
            while (true)
            {
                int node = stack.Pop();

                int count = stack.Count;
                for (int i = 0; i < count; i++)
                {
                    tempStack.Push(stack.Pop());
                }

                // Potential source of bug (infinite loop) - may never stop if only use '<'
                while (tempStack.Count > 0 && tempStack.Peek() <= node)
                {
                    stack.Push(tempStack.Pop());
                }
                stack.Push(node);

                if (tempStack.Count == 0)
                {
                    break;
                }

                count = tempStack.Count;
                for (int i = 0; i < count; i++)
                {
                    stack.Push(tempStack.Pop());
                }
            }
        }
    }

    [TestClass]
    public class Tests_03_06
    {
        [TestMethod]
        public void Test()
        {
            var stack = new Stack<int>(new[] { 6, 5, 4, 3, 2, 1 });
            var before = stack.ToArray();
            _06.sortStack(stack);
            var after = stack.ToArray();
        }

        [TestMethod]
        public void Test1()
        {
            var stack = new Stack<int>(new[] { 6, 6, 6, 6, 5, 4, 3, 2, 1, 1, 1 });
            var before = stack.ToArray();
            _06.sortStack(stack);
            var after = stack.ToArray();
        }

        [TestMethod]
        public void Test2()
        {
            var stack = new Stack<int>(new[] { 6, 6, 8, 6, 6, 5, 4, 6, 3, 1, 2, 1, 1, 1 });
            var before = stack.ToArray();
            _06.sortStack(stack);
            var after = stack.ToArray();
        }
    }
}
