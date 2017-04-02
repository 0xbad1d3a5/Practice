using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are given a binary tree in which each node contains a value. Design an algo-
 * rithm to print all paths which sum to a given value. The path does not need to
 * start or end at the root or a leaf.
 */
namespace Cracking.Chapter04
{
    class _09
    {
        /*
         * The concept is to recursively build all the possible node paths as you traverse the tree.
         * Everytime you encounter a new node, you add it to the path and then evaluate the current
         * list of paths for a matching sum.
         * 
         * Note that one key point to this algorithm is that you don't want to always search from the
         * root node! You WILL miss the paths in the middle of the tree as you will always be evaluating
         * the same sub-paths rather than evaluating new sub-paths.
         */
        public static IList<IList<int>> FindPathsWithSum(TreeNode root, List<int> path, int search)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            // Add current node to path and then evaluate the current path for a matching sum
            path.Add(root.Value);
            List<IList<int>> results = new List<IList<int>>();
            for (int i = path.Count - 1; i >= 0; i--)
            {
                // Some clever LINQ that just adds up the current path evaluation 
                IList<int> currPath = path.GetRange(i, path.Count - i); // Note how we are starting from the end of the path
                int sum = currPath.Aggregate((total, next) => { return total + next; });
                if (sum == search)
                {
                    results.Add(currPath);
                }
            }

            results.AddRange(FindPathsWithSum(root.Left, new List<int>(path), search));
            results.AddRange(FindPathsWithSum(root.Right, new List<int>(path), search));

            return results;
        }
    }

    [TestClass]
    public class Tests_04_09
    {
        [TestMethod]
        public void Test()
        {
            TreeNode t = _03.arrayToBst(new int[] { 1, 1, -1, 1, 1, -1, 1 });

            var result = _09.FindPathsWithSum(t, new List<int>(), 1);
            Assert.AreEqual(8, result.Count);

            result = _09.FindPathsWithSum(t, new List<int>(), 0);
            Assert.AreEqual(4, result.Count);
        }
    }
}
