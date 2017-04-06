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
     * This solution is the simplier one, where we just split the array into 3 even pieces
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
    }
}
