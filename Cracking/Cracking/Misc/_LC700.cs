using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given the root of a binary search tree (BST) and an integer val.

    Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.
 */
namespace Cracking.Misc
{
    class LC700
    {
        public TreeNode SearchBST(TreeNode root, int val) {
            
            if (root == null)
            {
                return null;
            }

            if (root.val == val)
            {
                return root;
            }

            if (val < root.val)
            {
                return SearchBST(root.left, val);
            }

            return SearchBST(root.right, val);
        }

    }

    [TestClass]
    public class Tests_LC700
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
