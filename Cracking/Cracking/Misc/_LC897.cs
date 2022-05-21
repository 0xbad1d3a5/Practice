using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree, and every node has no left child and only one right child.
 */
namespace Cracking.Misc
{
    class LC897
    {
        static TreeNode lastVisitedNode = null;        

        public static TreeNode IncreasingBST(TreeNode root) {
            
            TreeNode result = new TreeNode(0);
            lastVisitedNode = result;

            Inorder(root);

            return result.right;
        }

        public static void Inorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Inorder(node.left);

            node.left = null;
            lastVisitedNode.right = node;
            lastVisitedNode = node;

            Inorder(node.right);
        }

        static List<TreeNode> list = new List<TreeNode>();
        public static TreeNode IncreasingBSTNaive(TreeNode root) {
            
            Naive(root);

            for (int i = 0; i + 1 < list.Count; i++)
            {
                list[i].right = list[i + 1];
            }

            if (list.Count > 0)
            {
                return list[0];
            }
            
            return null;
        }

        public static void Naive(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Naive(node.left);
            list.Add(node);
            Naive(node.right);
        }
    }

    [TestClass]
    public class Tests_LC597
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
            node6.right = node8;
            node8.left = node7;
            node8.right = node9;

            LC897.IncreasingBSTNaive(node5);
        }
    }
}
