using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Implement a MyQueue class which implements a queue using two stacks.
 */
namespace Cracking.Chapter03
{
    public class MyQueue<T>
    {
        Stack<T> stack1 = new Stack<T>();
        Stack<T> stack2 = new Stack<T>();

        public void enqueue(T val)
        {
            int count = stack2.Count;
            for (int i = 0; i < count; i++)
            {
                stack1.Push(stack2.Pop());
            }

            stack1.Push(val);
        }

        public T dequeue()
        {
            int count = stack1.Count;
            for (int i = 0; i < count; i++)
            {
                stack2.Push(stack1.Pop());
            }

            return stack2.Pop();
        }
    }

    [TestClass]
    public class Tests_03_04_old
    {
        [TestMethod]
        public void Test()
        {
            MyQueue<int> myQueue = new MyQueue<int>();
            
            myQueue.enqueue(1);
            myQueue.enqueue(2);
            myQueue.enqueue(3);
            myQueue.enqueue(4);
            myQueue.enqueue(5);

            Assert.AreEqual(1, myQueue.dequeue());
            Assert.AreEqual(2, myQueue.dequeue());
            Assert.AreEqual(3, myQueue.dequeue());
            Assert.AreEqual(4, myQueue.dequeue());
            Assert.AreEqual(5, myQueue.dequeue());
        }
    }
}
