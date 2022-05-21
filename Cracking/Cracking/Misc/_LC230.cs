using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.
 */
namespace Cracking.Misc
{
    class LC230
    {
        public static int KthSmallestStack(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (true)
            {
                // Push all the left side of the tree to the stack
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                // Process one node
                root = stack.Pop();
                if (--k == 0)
                {
                    return root.val;
                }

                // set the root to push the right sub-tree of the node
                root = root.right;
            }
        }

        public static int curr;
        public static TreeNode result;
        public static int KthSmallestNaive(TreeNode root, int k) {
            curr = 0;
            return InOrder(root, k).val;
        }
        public static TreeNode InOrder(TreeNode node, int k)
        {
            if (node == null)
            {
                return null;
            }

            if (result != null)
            {
                return result;
            }

            InOrder(node.left, k);

            curr++;            
            if (curr == k)
            {
                result = node;
                return node;
            }

            InOrder(node.right, k);

            return result;
        }
    }

    [TestClass]
    public class Tests_LC230
    {
        [TestMethod]
        public void Test()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(8);
            var node9 = new TreeNode(9);

            node5.left = node3;
            node5.right = node6;
            node3.left = node2;
            node3.right = node4;
            node2.left = node1;

            LC230.KthSmallestStack(node5, 3);
        }
    }
}
