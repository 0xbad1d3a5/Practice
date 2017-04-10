using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Describe how you could use a single array to implement three stacks.
 */
namespace Cracking.Chapter03
{
    /*
     * This solution is the simpler one, where we just split the array into 3 even pieces
     */
    class NaiveMultiStack
    {
        private static int stackCount = 3;
        private int[] stackPointer = Enumerable.Repeat(-1, stackCount).ToArray();

        private int stackSize;
        private int[] buffer;

        public NaiveMultiStack(int stackSize)
        {
            this.stackSize = stackSize;
            this.buffer = new int[stackSize * stackCount];
        }

        public void push(int stack, int value)
        {
            if (stack < 0 || stack > stackCount)
            {
                throw new IndexOutOfRangeException();
            }
            if (stackPointer[stack] >= stackSize - 1)
            {
                throw new IndexOutOfRangeException();
            }
            stackPointer[stack]++;
            buffer[stackPointer[stack] + stack * stackSize] = value;
        }

        public int pop(int stack)
        {
            if (stackPointer[stack] < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int temp = buffer[stackPointer[stack] + stack * stackSize];
            stackPointer[stack]--;
            return temp;
        }
    }

    /*
     * WTF is this bullshit
     */
    class MultiStack
    {
        private int[] array;
        private StackContainer[] stacks;

        public MultiStack(int arraySize, int numOfStacks)
        {
            if (numOfStacks > arraySize)
            {
                throw new ArgumentException();
            }

            array = new int[arraySize];
            stacks = new StackContainer[numOfStacks];

            for (int i = 0; i < numOfStacks; i++)
            {
                stacks[i] = new StackContainer(i);
            }
        }

        public void push(int stack, int num)
        {
            int total = 0;
            for (int i = 0; i < stacks.Length; i++)
            {
                total += stacks[i].actualSize();
            }

            if (stacks[stack].stackSize > 0 && total >= array.Length)
            {
                throw new StackFullException();
            }

            StackContainer currStack = stacks[stack];
            int nextStackPos = getNextStackPos(stack);
            if ((currStack.headPos + currStack.stackSize) % array.Length == stacks[nextStackPos].headPos)
            {
                shiftStack(nextStackPos);
            }

            array[(currStack.headPos + currStack.stackSize) % array.Length] = num;
            currStack.stackSize++;
        }

        public int pop(int stack)
        {
            if (stacks[stack].stackSize < 1)
            {
                throw new StackEmptyException();
            }

            StackContainer currStack = stacks[stack];
            
            int temp = array[(currStack.headPos + currStack.stackSize - 1) % array.Length];
            currStack.stackSize--;

            return temp;
        }

        private int getNextStackPos(int stackPos){
            if (stacks.Length - 1 == stackPos){
                return 0;
            }
            return stackPos + 1;
        }

        private void shiftStack(int stackPos)
        {
            StackContainer currStack = stacks[stackPos];
            int nextStackPos = getNextStackPos(stackPos);
            
            if ((currStack.headPos + currStack.stackSize) % array.Length == stacks[nextStackPos].headPos)
            {
                shiftStack(nextStackPos);
            }

            for (int i = currStack.stackSize; i > 0; i--)
            {
                array[(currStack.headPos + i) % array.Length] = array[(currStack.headPos + i - 1) % array.Length];
            }
            currStack.headPos++;
        }
    }

    class StackContainer
    {
        public int headPos { get; set; }
        public int stackSize { get; set; }

        public StackContainer(int pos)
        {
            headPos = pos;
            stackSize = 0;
        }

        // Even if the stackSize is 0, since we don't allow headPos to collide
        // the actual size of the stack within the array is 1
        public int actualSize()
        {
            if (stackSize == 0)
            {
                return 1;
            }
            return stackSize;
        }
    }

    class StackFullException : Exception { }

    class StackEmptyException : Exception { }

    [TestClass]
    public class Tests_03_01
    {
        private static int stackSize = 2;

        [TestMethod]
        public void Test1(){

            NaiveMultiStack multiStack = new NaiveMultiStack(stackSize);

            multiStack.push(0, 0);
            multiStack.push(0, 0);
            multiStack.push(1, 1);

            Assert.AreEqual(0, multiStack.pop(0));
            Assert.AreEqual(1, multiStack.pop(1));

            multiStack.push(2, 2);

            Assert.AreEqual(0, multiStack.pop(0));
            Assert.AreEqual(2, multiStack.pop(2));

            multiStack.push(0, 1);
            multiStack.push(0, 1);
            multiStack.push(1, 2);

            Assert.AreEqual(1, multiStack.pop(0));
            Assert.AreEqual(2, multiStack.pop(1));

            multiStack.push(2, 3);

            Assert.AreEqual(1, multiStack.pop(0));
            Assert.AreEqual(3, multiStack.pop(2));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test2()
        {
            NaiveMultiStack multiStack = new NaiveMultiStack(stackSize);

            multiStack.push(0, 0);
            multiStack.push(0, 0);
            multiStack.push(0, 0);
        }

        [TestMethod]
        public void Test3()
        {
            MultiStack multiStack = new MultiStack(6, 3);

            multiStack.push(0, 0);
            multiStack.push(0, 0);
            multiStack.push(1, 1);

            Assert.AreEqual(0, multiStack.pop(0));
            Assert.AreEqual(1, multiStack.pop(1));

            multiStack.push(2, 2);

            Assert.AreEqual(0, multiStack.pop(0));
            Assert.AreEqual(2, multiStack.pop(2));

            multiStack.push(0, 1);
            multiStack.push(0, 1);
            multiStack.push(1, 2);

            Assert.AreEqual(1, multiStack.pop(0));
            Assert.AreEqual(2, multiStack.pop(1));

            multiStack.push(2, 3);

            Assert.AreEqual(1, multiStack.pop(0));
            Assert.AreEqual(3, multiStack.pop(2));
        }

        [TestMethod]
        public void Test4()
        {
            MultiStack multiStack = new MultiStack(6, 3);

            multiStack.push(0, 1);
            multiStack.push(0, 2);
            multiStack.push(0, 3);
            multiStack.push(0, 4);
            multiStack.push(1, 5);
            multiStack.push(2, 6);

            Assert.AreEqual(4, multiStack.pop(0));
            Assert.AreEqual(3, multiStack.pop(0));
            Assert.AreEqual(2, multiStack.pop(0));
            Assert.AreEqual(1, multiStack.pop(0));
            Assert.AreEqual(5, multiStack.pop(1));
            Assert.AreEqual(6, multiStack.pop(2));

            multiStack.push(2, 10);
            multiStack.push(2, 11);
            multiStack.push(2, 12);
            multiStack.push(1, 20);
            multiStack.push(1, 21);
            multiStack.push(0, 1);

            Assert.AreEqual(12, multiStack.pop(2));
            Assert.AreEqual(11, multiStack.pop(2));
            Assert.AreEqual(10, multiStack.pop(2));
            Assert.AreEqual(21, multiStack.pop(1));
            Assert.AreEqual(20, multiStack.pop(1));
            Assert.AreEqual(1, multiStack.pop(0));
        }

        [TestMethod]
        public void RandomTest()
        {
            Random r = new Random();
            int stackSize = r.Next(100, 201);
            int stackCount = 3;

            MultiStack multiStack = new MultiStack(stackSize, stackCount);

            Stack<int>[] correctStacks = new Stack<int>[stackCount];
            for (int i = 0; i < stackCount; i++)
            {
                correctStacks[i] = new Stack<int>();
            }

            for (int i = 0; i < 100000; i++)
            {
                int pickStack = r.Next(0, stackCount);
                bool action = correctStacks[pickStack].Count < 1 ? true : r.NextDouble() >= 0.5; // true = push, false = pop
                int num =  r.Next(Int32.MinValue, Int32.MinValue);

                if (action)
                {
                    try
                    {
                        multiStack.push(pickStack, num);
                    }
                    catch (StackFullException)
                    {
                        continue;
                    }

                    correctStacks[pickStack].Push(num);
                }
                else
                {
                    Assert.AreEqual(correctStacks[pickStack].Pop(), multiStack.pop(pickStack));
                }
            }
        }
    }
}
