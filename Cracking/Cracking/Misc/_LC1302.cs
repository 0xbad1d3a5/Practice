using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary tree, return the sum of values of its deepest leaves.
 */
namespace Cracking.Misc
{
    class LC1302
    {
        public int DeepestLeavesSum(TreeNode node)
        {
            List<TreeNode> currLevel = new List<TreeNode> { node };
            List<TreeNode> prevLevel = currLevel;

            while (currLevel.Count > 0)
            {
                prevLevel = currLevel;
                currLevel = GetNextLevel(currLevel);
            }

            return prevLevel.Select(x => x.val).Sum();
        }

        public List<TreeNode> GetNextLevel(List<TreeNode> currLevel)
        {
            List<TreeNode> newLevel = new List<TreeNode>();

            foreach(TreeNode node in currLevel)
            {
                if (node.left != null)
                {
                    newLevel.Add(node.left);
                }

                if (node.right != null)
                {
                    newLevel.Add(node.right);
                }
            }

            return newLevel;
        }
    }

    [TestClass]
    public class Tests_LC1302
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

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.right = node6;
            node4.left = node7;
            node6.right = node8;

            LC1302 test = new LC1302();
            test.DeepestLeavesSum(node1);
        }
    }
}
