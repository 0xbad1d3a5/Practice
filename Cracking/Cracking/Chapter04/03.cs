using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a sorted (increasing order) array with unique integer elements, write an
 * algorithm to create a binary search tree with minimal height.
 */
namespace Cracking.Chapter04
{
    class _03
    {
        public TreeNode arrayToBst(int[] arr, int begin, int end)
        {
            if (end < begin)
            {
                return null;
            }

            int mid = (end - begin) / 2 + begin;
            TreeNode parent = new TreeNode(arr[mid]);

            parent.Left = arrayToBst(arr, begin, mid - 1);
            parent.Right = arrayToBst(arr, mid + 1, end);

            return parent;
        }
    }

    [TestClass]
    public class Tests_04_03
    {
        [TestMethod]
        public void Test()
        {
            // https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        }
    }
}
