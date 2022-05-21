using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus the sum of all keys greater than the original key in BST.

    As a reminder, a binary search tree is a tree that satisfies these constraints:

    The left subtree of a node contains only nodes with keys less than the node's key.
    The right subtree of a node contains only nodes with keys greater than the node's key.
    Both the left and right subtrees must also be binary search trees.
 */
namespace Cracking.Misc
{
    class LC538
    {
        public static TreeNode ConvertBST(TreeNode root) {
            CalculateGreaterTree(root, 0);
            return root;
        }

        public static int CalculateGreaterTree(TreeNode node, int toAdd)
        {
            if (node == null)
            {
                return 0;
            }

            int right = CalculateGreaterTree(node.right, toAdd);
            int left = CalculateGreaterTree(node.left, right + node.val + toAdd);
            int temp = node.val;
            node.val = node.val + right + toAdd;

            return temp + left + right;
        }
    }

    [TestClass]
    public class Tests_LC538
    {
        [TestMethod]
        public void Test()
        {
            var tree = new TreeNode(4);
            var node0 = new TreeNode(0);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(8);

            tree.left = node1;
            tree.right = node6;
            node1.left = node0;
            node1.right = node2;
            node2.right = node3;
            node6.left = node5;
            node6.right = node7;
            node7.right = node8;

            LC538.ConvertBST(tree);
            return;
        }
    }
}
