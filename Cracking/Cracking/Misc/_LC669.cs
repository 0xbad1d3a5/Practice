using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary search tree and the lowest and highest boundaries as low and high, trim the tree so that all its elements lies in [low, high]. Trimming the tree should not change the relative structure of the elements that will remain in the tree (i.e., any node's descendant should remain a descendant). It can be proven that there is a unique answer.

    Return the root of the trimmed binary search tree. Note that the root may change depending on the given bounds.
 */
namespace Cracking.Misc
{
    class LC669
    {
        public static TreeNode TrimBST(TreeNode root, int low, int high) {
            
            if (root == null)
            {
                return null;
            }

            if (root.val >= low && root.val <= high)
            {
                root.left = TrimBST(root.left, low, high);
                root.right = TrimBST(root.right, low, high);
            }
            else if (root.val < low)
            {
                root = TrimBST(root.right, low, high);
            }
            else if (root.val > high)
            {
                root = TrimBST(root.left, low, high);
            }

            return root;
        }
    }

    [TestClass]
    public class Tests_LC669
    {
        [TestMethod]
        public void Test()
        {
            var tree = new TreeNode(3);
            var node1 = new TreeNode(0);
            var node2 = new TreeNode(4);
            var node3 = new TreeNode(2);
            var node4 = new TreeNode(1);

            tree.left = node1;
            tree.right = node2;
            node1.right = node3;
            node3.left = node4;
            LC669.TrimBST(tree, 1, 3);
            return;
        }

        [TestMethod]
        public void Test1()
        {
            var tree = new TreeNode(3);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(4);
            var node3 = new TreeNode(2);

            tree.left = node1;
            tree.right = node2;
            node1.right = node3;
            LC669.TrimBST(tree, 1, 2);
            return;
        }
    }
}
