using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * How would you design a stack which, in addition to push and pop, also has a
 * function min which returns the minimum element? Push, pop and min should
 * all operate in O(1) time.
 */
namespace Cracking.Chapter03
{
    class MyStack
    {
        private Node top;
        public int count { get; private set; }

        public MyStack()
        {
            this.count = 0;
        }

        public void push(Node node){
            node.next = top;
            top = node;
            count++;
        }

        public Node pop()
        {
            if (top == null)
            {
                throw new ElementOutOfBoundsException();
            }

            else
            {
                Node temp = top;
                top = top.next;
                count--;
                return temp;
            }
        }

        public Node peak()
        {
            return top;
        }
    }

    /*
     * Essentially use two stacks, one to keep track of the elements and one to keep track of the min element.
     * To save space, the min element stack can also keep track of how many times the min element has been pushed
     * onto the main stack so you don't have push the same element to the min stack.
     */
    public class StackWithMin
    {
        public int count { get { return stack.count; } }

        MyStack minElementStack = new MyStack();
        MyStack stack = new MyStack();

        public void push(int value)
        {
            Node minElement = minElementStack.peak();

            if (minElement == null || minElement.value > value)
            {
                minElementStack.push(new Node(value));
            }
            else if (minElement.value == value)
            {
                minElement.times++;
            }

            stack.push(new Node(value));
        }

        public int pop()
        {
            Node node = stack.pop();
            Node minElementNode = minElementStack.peak();

            if (node.value == minElementNode.value)
            {
                if (minElementNode.times <= 1)
                {
                    minElementStack.pop();
                }
                else
                {
                    minElementNode.times--;
                }
            }

            return node.value;
        }

        public int getMin()
        {
            if (minElementStack.count == 0)
            {
                throw new ElementOutOfBoundsException();
            }

            return minElementStack.peak().value;
        }

        public int peak()
        {
            if (minElementStack.count == 0)
            {
                throw new ElementOutOfBoundsException();
            }

            return stack.peak().value;
        }
    }

    [TestClass]
    public class Tests_03_02
    {
        [TestMethod]
        public void Test()
        {
            StackWithMin stack = new StackWithMin();
            stack.push(2);
            stack.push(2);
            stack.push(3);
            stack.push(4);

            Assert.AreEqual(2, stack.getMin());
            stack.push(1);
            Assert.AreEqual(1, stack.getMin());
            stack.push(1);
            Assert.AreEqual(1, stack.getMin());
            stack.pop();
            Assert.AreEqual(1, stack.getMin());
            stack.pop();
            Assert.AreEqual(2, stack.getMin());
            stack.pop();
            Assert.AreEqual(2, stack.getMin());
            stack.pop();
            Assert.AreEqual(2, stack.getMin());
            stack.pop();
            Assert.AreEqual(2, stack.getMin());
            Assert.AreEqual(2, stack.pop());
            Assert.AreEqual(0, stack.count);
        }
    }
}
