using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Implement a function to check if a binary tree is balanced. For the purposes of
 * this question, a balanced tree is defined to be a tree such that the heights of the
 * two subtrees of any node never differ by more than one.
 */
namespace Cracking.Chapter04
{
    class _01
    {
        /*
         * Returns -1 if not balanced, otherwise >= 0
         * 
         * Calculate height recursively on the tree and its subtrees and make sure they do not differ by more than 1.
         */
        public static int isBalanced(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = 1 + isBalanced(root.Left);
            int right = 1 + isBalanced(root.Right);

            /* Because we return -1 in the case that |left - right| > 1, the only case left or right can be 0 is if
             * we already failed in a prior recursive call - therefore continue returning -1 to indicate failure.
             */
            if (left == 0 || right == 0)
            {
                return -1;
            }

            // Ensure that |left - right| do not differ by more than 1
            if (!(Math.Abs(left - right) <= 1))
            {
                return -1;
            }

            // Return the larger side, or just left if they're the same (as it doesn't matter)
            return left > right ? left : right;
        }
    }

    [TestClass]
    public class Tests_04_01
    {
        [TestMethod]
        public void Test()
        {
            // https://leetcode.com/problems/balanced-binary-tree/
        }

        [TestMethod]
        public void Test1()
        {
            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(2);
            TreeNode t3 = new TreeNode(3);
            TreeNode t4 = new TreeNode(4);
            TreeNode t5 = new TreeNode(5);
            TreeNode t6 = new TreeNode(6);
            TreeNode t7 = new TreeNode(7);

            t1.Left = t2;
            t1.Right = t3;

            t2.Left = t4;
            t2.Right = t5;

            t3.Left = t6;
            t3.Right = t7;

            Assert.AreEqual(3, _01.isBalanced(t1));
        }

        [TestMethod]
        public void Test2()
        {
            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(2);
            TreeNode t3 = new TreeNode(3);
            TreeNode t4 = new TreeNode(4);
            TreeNode t5 = new TreeNode(5);
            TreeNode t6 = new TreeNode(6);
            TreeNode t7 = new TreeNode(7);

            t1.Left = t2;

            t2.Left = t4;
            t2.Right = t5;

            Assert.AreEqual(-1, _01.isBalanced(t1));
        }
    }
}
