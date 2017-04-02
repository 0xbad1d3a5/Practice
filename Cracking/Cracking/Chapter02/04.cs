using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write code to partition a linked list around a value x, such that all nodes less than
 * x come before all nodes greater than or equal to x.
 */
namespace Cracking.Chapter02
{
    class _04
    {
        /*
         * Easiest way to do this is to simply separate the nodes into two linked lists by repointing
         * the nodes as you go through the original, one with (Nodes < x) and one with (Nodes > x).
         * At the end, you would just join the lists.
         * 
         * !!!! Note that this solution DOES NOT do: [smaller list] < x < [larger list]
         * IT DOES DO: [smaller list] < [larger list - and x is somewhere in here]
         * 
         * THIS IS TECHNICALLY WHAT WAS ASKED BY THE QUESTION (although probably not as useful)
         * 
         * Simply add another list to add to for equal values, and then append at the end.
         */
        public static Node PartitionList(Node node, int x)
        {
            Node leftHead = null;
            Node left = null;
            Node rightHead = null;
            Node right = null;

            while (node != null)
            {
                if (node.value < x)
                {
                    if (leftHead == null)
                    {
                        leftHead = node;
                        left = node;
                    }
                    else
                    {
                        left.next = node;
                        left = left.next;
                    }
                }
                else
                {
                    if (rightHead == null)
                    {
                        rightHead = node;
                        right = node;
                    }
                    else
                    {
                        right.next = node;
                        right = right.next;
                    }
                }
                node = node.next;
            }

            if (left != null)
            {
                left.next = rightHead;
                return leftHead;
            }
            return rightHead;
        }
    }

    [TestClass]
    public class Tests_02_04
    {
        [TestMethod]
        public void Test1()
        {
            Node n = new Node(new int[] { 4, 9, 2, 8, 3, 5, 7 });
            n = _04.PartitionList(n, 4);
            n.PrintTail();
            Assert.IsTrue((new Node(new int[] { 2, 3, 4, 9, 8, 5, 7 })).Equal(n));
        }
    }
}
