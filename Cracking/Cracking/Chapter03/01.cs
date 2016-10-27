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
    class _01
    {
        static int stackCount = 3;
        static int stackSize = 2;
        static int[] buffer = new int[stackSize * stackCount];
        static int[] stackPointer = Enumerable.Repeat(-1, stackCount).ToArray();

        public static void push(int stack, int value)
        {
            if (stackPointer[stack] >= stackSize - 1)
            {
                throw new IndexOutOfRangeException();
            }
            stackPointer[stack]++;
            buffer[stackPointer[stack]] = value;
        }

        public static int pop(int stack)
        {
            if (stackPointer[stack] < 0)
            {
                throw new IndexOutOfRangeException();
            }
            stackPointer[stack]--;
            return buffer[stackPointer[stack] + 1];
        }
    }

    [TestClass]
    public class Tests_03_01
    {
        [TestMethod]
        public void Test(){
            _01.push(0, 1);
            _01.push(0, 1);
        }
    }
}
