using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Design an algorithm and write code to find the first common ancestor of two
 * nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE:
 * This is not necessarily a binary search tree.
 */
namespace Cracking.Chapter04
{
    /*
     * Because the tree may not be a balanced binary search tree, it's possible to run into the situation where the tree
     * is just a linked list: A -> B -> C -> D, where A would be the first common ancestor of A and D
     * 
     * To solve this problem then, we have to recursively search down the left and right subtrees until we find a node that's
     * either 1) has the two nodes we're trying to find on different subtrees, or 2) the current node is one of the nodes we
     * are trying to find.
     * 
     * Therefore, there are 4 cases:
     * 
     * 1. Found a node in left subtree, with none right, recurse down left (provided current node is not a searched for node)
     * 2. Found a node in right subtree, with none left, recurse down right (provided current node is not a searched for node)
     * 3. Found in both subtrees, then the current node is the first common ancestor
     * 4. Current node is a node we are searching for, then search children of the current node to make sure we have a second node
     *    - Search for other again to verify we actually have a valid problem
     *    - This step should be before step 1 & 2
     */
    class _07
    {
        public static bool IsInSubtree(TreeNode root, TreeNode x, TreeNode y)
        {
            if (root == null)
            {
                return false;
            }
            if (root == x || root == y)
            {
                return true;
            }
            return IsInSubtree(root.Left, x, y) || IsInSubtree(root.Right, x, y);
        }

        public static TreeNode FindCommonAncestor(TreeNode root, TreeNode x, TreeNode y)
        {
            bool inLeft = IsInSubtree(root.Left, x, y);
            bool inRight = IsInSubtree(root.Right, x, y);

            if (inLeft && inRight)
            {
                return root;
            }
            // We must first check if the current node is a node we're looking for or else it will get missed
            if (root == x || root == y)
            {
                if (IsInSubtree(root.Left, x, y) || IsInSubtree(root.Right, x, y))
                {
                    return root;
                }
            }
            if (inLeft && !inRight){
                return FindCommonAncestor(root.Left, x, y);
            }
            if (inRight && !inLeft)
            {
                return FindCommonAncestor(root.Right, x, y);
            }
            return null;
        }
    }

    [TestClass]
    public class Tests_04_07
    {
        [TestMethod]
        public void Test()
        {
            // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
        }
    }
}
