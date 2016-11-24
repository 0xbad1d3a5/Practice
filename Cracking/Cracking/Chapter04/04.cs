using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a binary tree, design an algorithm which creates a linked list of all the
 * nodes at each depth (e.g., if you have a tree with depth D, you'll have D linked
 * lists).
 */
namespace Cracking.Chapter04
{
    /*
     * This is basically BFS modified
     * 
     * Question: Should empty spaces [aka "null children" between two nodes that don't share the same parent on the same level] be printed out?
     */
    class _04
    {
        public static IList<IList<int>> treeToLevelOrder(TreeNode root)
        {
            IList<IList<int>> resultLists = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root == null)
            {
                return resultLists;
            }

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                List<int> newLevel = new List<int>();
                Queue<TreeNode> newQueue = new Queue<TreeNode>();

                int queueCount = queue.Count;
                for (int i = 0; i < queueCount; i++)
                {
                    TreeNode n = queue.Dequeue();
                    newLevel.Add(n.Value);
                    if (n.Left != null)
                    {
                        newQueue.Enqueue(n.Left);
                    }
                    if (n.Right != null)
                    {
                        newQueue.Enqueue(n.Right);
                    }
                }

                resultLists.Add(newLevel);
                queue = newQueue;
            }

            return resultLists;
        }
    }

    [TestClass]
    public class Tests_04_04
    {
        [TestMethod]
        public void Test()
        {
            // https://leetcode.com/problems/binary-tree-level-order-traversal/
        }
    }
}
