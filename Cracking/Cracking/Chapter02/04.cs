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
        public static Node PartitionList(Node node, int x)
        {
            Node leftHead = null;
            Node left = null;
            Node rightHead = null;
            Node right = null;

            while (node != null)
            {
                if (node.value <= x)
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
        public void Test()
        {

        }
    }
}
