using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Implement an algorithm to find the kth last element of a singly linked list.
 */
namespace Cracking.Chapter02
{
    // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    class _02
    {
        public static Node DeleteNthLastElement(Node head, int posFromLast)
        {
            Node p1 = head;
            Node p2 = head;

            while (p1.next != null)
            {
                if (posFromLast <= 0)
                {
                    p2 = p2.next;
                }
                p1 = p1.next;
                posFromLast--;
            }

            if (posFromLast > 0)
            {
                return head.next;
            }
            else
            {
                p2.next = p2.next.next;
                return head;
            }
        }

        /*
         * Recursive, only valid if interviewer allows it since we technically don't return any values
         */
        public static int nthToLastElementRecursive(Node node, int nthToLast)
        {
            if (node == null)
            {
                return 0;
            }

            int pos = nthToLastElementRecursive(node.next, nthToLast) + 1;
            if (nthToLast == pos)
            {
                Console.WriteLine(String.Format("{0}", node.value));
            }

            return pos;
        }

        /*
         * To return a value, just wrap our int in a reference (or use out params if the language has them)
         * so that it is editable in the stack.
         */
        public static Node nthToLastElementRecursive(Node node, int nthToLast, out int retVal)
        {
            if (node == null)
            {
                retVal = 0;
                return null;
            }

            Node n = nthToLastElementRecursive(node.next, nthToLast, out retVal); retVal++;

            if (retVal == nthToLast)
            {
                return node;
            }

            return n;
        }

        /*
         * The iterative solution is to simply move one pointer ahead of the other by n steps so that
         * when the leading pointer reaches the end, the lagging pointer will be pointing to the correct
         * node.
         */
        public static Node nthToLastElementIterative(Node head, int nthToLast)
        {
            Node p1 = head;
            Node p2 = head;

            while (p1 != null)
            {
                if (nthToLast <= 0)
                {
                    p2 = p2.next;
                }

                p1 = p1.next;
                nthToLast--;
            }

            return p2;
        }
    }

    [TestClass]
    public class Tests_02_02
    { 
        [TestMethod]
        public void Test1()
        {
            Node head = new Node(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            _02.nthToLastElementRecursive(head, 1);
            _02.nthToLastElementRecursive(head, 4);
        }

        [TestMethod]
        public void Test2()
        {
            Node head = new Node(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            int x;
            Assert.AreEqual(9, _02.nthToLastElementRecursive(head, 1, out x).value);
            Assert.AreEqual(6, _02.nthToLastElementRecursive(head, 4, out x).value);
        }

        [TestMethod]
        public void Test3()
        {
            Node head = new Node(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Assert.AreEqual(9, _02.nthToLastElementIterative(head, 1).value);
            Assert.AreEqual(6, _02.nthToLastElementIterative(head, 4).value);
        }
    }
}
