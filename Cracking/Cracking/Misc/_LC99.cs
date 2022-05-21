using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given the root of a binary search tree (BST), where the values of exactly two nodes of the tree were swapped by mistake. Recover the tree without changing its structure.
 */
namespace Cracking.Misc
{
    class LC99
    {
        TreeNode prevNode;
        TreeNode first;
        TreeNode second;

        public void RecoverTree(TreeNode root)
        {
            Solve(root);

            int temp = first.val;
            first.val = second.val;
            second.val = temp;
        }

        public void Solve(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Solve(node.left);

            if (prevNode != null && prevNode.val > node.val)
            {
                if (first == null)
                {
                    first = prevNode;
                }

                second = node;
            }

            prevNode = node;

            Solve(node.right);
        }
    }

    [TestClass]
    public class Tests_LC99
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
