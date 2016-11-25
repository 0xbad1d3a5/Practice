using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write an algorithm to find the 'next' node (i.e., in-order successor) of a given node
 * in a binary search tree. You may assume that each node has a link to its parent.
 */
namespace Cracking.Chapter04
{
    /*
     * The in-order successor can be found by:
     * 
     * 1. If you have a right child node, then the in-order successor is the leftmost child of that subtree.
     * 2. Otherwise, the in-order successor is the first ancestor whose left subtree contains the node.
     */
    class _06
    {
        public static TreeNode InOrderSuccessor(TreeNode n)
        {
            if (n.Right != null)
            {
                return findLeftMostNode(n.Right);
            }
            else if (n.Parent != null)
            {
                return findInOrderSuccessor(n.Parent, n);
            }
            else
            {
                return null;
            }
        }

        private static TreeNode findLeftMostNode(TreeNode n)
        {
            if (n.Left == null)
            {
                return n;
            }
            return findLeftMostNode(n.Left);
        }

        private static TreeNode findInOrderSuccessor(TreeNode parent, TreeNode prev)
        {
            if (parent.Left == prev)
            {
                return parent;
            }
            return findInOrderSuccessor(parent.Parent, parent);
        }
    }

    [TestClass]
    public class Tests_04_06
    {
        [TestMethod]
        public void Test()
        {
            TreeNode t = _03.arrayToBst(new int[] {1, 2, 3, 4, 5, 6});
            var result = _06.InOrderSuccessor(t);
            Assert.AreEqual(4, result.Value);

            result = _06.InOrderSuccessor(t.Left.Right);
            Assert.AreEqual(3, result.Value);
        }
    }
}
