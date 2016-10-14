using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Implement an algorithm to find the kth to last element of a singly linked list.
 */
namespace Cracking.Chapter02
{
    // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    class _2
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
    }

    [TestClass]
    public class Tests_2_2
    { 
        [TestMethod]
        public void Test()
        {

        }
    }
}
