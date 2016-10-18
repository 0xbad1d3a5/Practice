﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Implement an algorithm to delete a node in the middle of a singly linked list,
 * given only access to that node.
 * EXAMPLE
 * Input: the node c from the linked list a->b->c->d->e
 * Result: nothing is returned, but the new linked list looks like a- >b- >d->e
 */
namespace Cracking.Chapter02
{
    static class _3
    {
        public static void DeleteNodeGivenNode(Node node)
        {
            if (node == null || node.next == null)
            {
                throw new ElementOutOfBoundsException();
            }

            node.value = node.next.value;
            node.next = node.next.next;
        }
    }

    [TestClass]
    public class Tests_02_3
    {
        [TestMethod]
        public void Test()
        {

        }
    }
}
