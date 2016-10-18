using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
 * Therefore, in real life, we would likely start a new stack when the previous stack
 * exceeds some threshold. Implement a data structure SetOfStacks that mimics
 * this. SetOfStacks should be composed of several stacks and should create a
 * new stack once the previous one exceeds capacity. SetOfStacks.push() and
 * SetOfStacks.pop() should behave identically to a single stack (that is, pop()
 * should return the same values as it would if there were just a single stack).
 * 
 * FOLLOW UP
 * Implement a function popAt(int index) which performs a pop operation on
 * a specific sub-stack.
 */
namespace Cracking.Chapter03
{
    public class SetOfStacks
    {
        private List<Stack<int>> listOfStacks = new List<Stack<int>>();
        private int stackCount = 0;
        private int stackLimit = 5;

        public int pop()
        {
            if (stackCount == 0)
            {
                throw new ElementOutOfBoundsException();
            }

            var temp = listOfStacks[stackCount - 1].Pop();

            if (listOfStacks[stackCount - 1].Count == 0)
            {
                listOfStacks.RemoveAt(stackCount - 1);
                stackCount--;
            }

            return temp;
        }

        public void push(int val)
        {
            if (stackCount == 0 || listOfStacks[stackCount - 1].Count >= stackLimit)
            {
                Stack<int> newStack = new Stack<int>();
                newStack.Push(val);
                listOfStacks.Add(newStack);
                stackCount++;
            }
            else
            {
                listOfStacks[stackCount - 1].Push(val);
            }
        }

        public int peek()
        {
            if (stackCount == 0)
            {
                throw new ElementOutOfBoundsException();
            }

            return listOfStacks[stackCount - 1].Peek();
        }

        public int popAt(int index)
        {
            if (index < 0 || stackCount - 1 < index)
            {
                throw new ElementOutOfBoundsException();
            }

            var temp = listOfStacks[index].Pop();
            shiftLeft(index);
            return temp;
        }

        private void shiftLeft(int index)
        {
            if (index == stackCount - 1)
            {
                if (listOfStacks[index].Count == 0)
                {
                    listOfStacks.RemoveAt(index);
                    stackCount--;
                }
                return;
            }

            Stack<int> tempStackReversed = new Stack<int>();

            int count = listOfStacks[index + 1].Count;
            for (int i = 0; i < count; i++)
            {
                tempStackReversed.Push(listOfStacks[index + 1].Pop());
            }

            listOfStacks[index].Push(tempStackReversed.Pop());

            count = tempStackReversed.Count;
            for (int i = 0; i < count; i++)
            {
                listOfStacks[index + 1].Push(tempStackReversed.Pop());
            }

            shiftLeft(index + 1);
        }
    }

    [TestClass]
    public class Tests_03_3
    {
        [TestMethod]
        public void Test1()
        {
            SetOfStacks ss = new SetOfStacks();
            
            ss.push(1);
            ss.push(2);
            ss.push(3);
            ss.push(4);
            ss.push(5);

            ss.push(2);
            ss.push(3);
            ss.push(4);
            ss.push(5);
            ss.push(6);

            ss.push(3);
            ss.push(4);
            ss.push(5);

            Assert.AreEqual(5, ss.peek());
            Assert.AreEqual(5, ss.pop());
            Assert.AreEqual(4, ss.pop());
            Assert.AreEqual(3, ss.pop());

            Assert.AreEqual(6, ss.peek());
            Assert.AreEqual(6, ss.pop());
            Assert.AreEqual(5, ss.pop());
            Assert.AreEqual(4, ss.pop());
            Assert.AreEqual(3, ss.pop());
            Assert.AreEqual(2, ss.pop());

            Assert.AreEqual(5, ss.peek());
        }

        [TestMethod]
        public void Test2()
        {
            SetOfStacks ss = new SetOfStacks();

            ss.push(1);
            ss.push(2);
            ss.push(3);
            ss.push(4);
            ss.push(5);

            ss.push(2);
            ss.push(3);
            ss.push(4);
            ss.push(5);
            ss.push(6);

            ss.push(3);
            ss.push(4);
            ss.push(5);

            Assert.AreEqual(6, ss.popAt(1));
            Assert.AreEqual(5, ss.popAt(2));
            Assert.AreEqual(4, ss.popAt(2));
            Assert.AreEqual(3, ss.popAt(1));
        }
    }
}
