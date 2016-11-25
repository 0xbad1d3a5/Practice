using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Implement a function to check if a binary tree is a binary search tree.
 */
namespace Cracking.Chapter04
{
    /*
     * public static bool isTreeBst(TreeNode root)
     * {
     *     bool left = root.Left == null ? true : root.Left.Value <= root.Value;
     *     bool right = root.Right == null ? true : root.Right.Value > root.Value;
     *
     *     if (!(left && right))
     *     {
     *         return false;
     *     }
     *
     *     bool subTreeLeft = root.Left == null ? true : isTreeBst(root.Left);
     *     bool subTreeRight = root.Right == null ? true : isTreeBst(root.Right);
     *
     *     return left && right && subTreeLeft && subTreeRight;
     * }
     * 
     * INCORRECT: It is not sufficient to just check that left <= root < right, will fail the following:
     *            
     *                         20
     *                        /  \
     *                       10  30
     *                        \
     *                         25
     */
    class _05
    {

        /*
         * Correct way to approach the problem is you have to check EVERY node under the left and right subtree to see whether they satisfy
         * the condition. This is obvious very expensive, so to solve this problem you recursively pass in the min and max values a node
         * under the subtrees may be, updating them with the value of the next node as you continue to recurse.
         */
        public static bool isTreeBst(TreeNode root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Value <= min || root.Value > max)
            {
                return false;
            }

            return isTreeBst(root.Left, min, root.Value) && isTreeBst(root.Right, root.Value, max);
        }

        /*
         * Above is even incorrect in a strict definition of a BST: left < root < right
         * Such a interpretation will run into problems with [1, 1] / [1, null, 1] and int.MaxValue and int.MinValue
         * 
         * To solve such a problem you need to be able to hold 1 more value than what's possible with an int. A easy way around
         * this then is to simply use a nullable value which is simply not initialized when you start the search.
         */
        public static bool IsValidBst(TreeNode root)
        {
            return IsValidBstHelper(root, null, null);
        }

        public static bool IsValidBstHelper(TreeNode root, int? min, int? max)
        {
            if (root == null)
            {
                return true;
            }

            if (min != null && root.Value <= min)
            {
                return false;
            }
            if (max != null && root.Value >= max)
            {
                return false;
            }

            return IsValidBstHelper(root.Left, min, root.Value) && IsValidBstHelper(root.Right, root.Value, max);
        }
    }

    [TestClass]
    public class Tests_04_05
    {
        [TestMethod]
        public void Test()
        {
            // https://leetcode.com/problems/validate-binary-search-tree/
        }
    }
}
