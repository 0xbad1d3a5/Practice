using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You have two very large binary trees: T1, with millions of nodes, and T2, with
 * hundreds of nodes. Create an algorithm to decide if T2 is a subtree of T1.
 */
namespace Cracking.Chapter04
{
    /*
     * A tree T2 is a subtree of T1 if there exists a node n in T1 such that the subtree of
     * n is identical to T2. That is, if you cut off the tree at node n, the two trees would
     * be identical.
     */
    class _08
    {
        // https://leetcode.com/problems/same-tree/
        private static bool AreEqualTrees(TreeNode x, TreeNode y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (x.Value != y.Value)
            {
                return false;
            }
            return AreEqualTrees(x.Left, y.Left) && AreEqualTrees(x.Right, y.Right);
        }

        private static bool SubTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return false;
            }

            // null tree is always a subtree
            if (t2 == null)
            {
                return true;
            }

            // Only bother to check if the two "root" nodes match
            if (t1.Value == t2.Value)
            {
                if (AreEqualTrees(t1, t2))
                {
                    return true;
                }
            }

            return SubTree(t1.Left, t2) || SubTree(t1.Right, t2);
        }
    }

    [TestClass]
    public class Tests_04_08
    {
        [TestMethod]
        public void Test()
        {

        }
    }
}
