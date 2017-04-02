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
        public static TreeNode arrayToBst(int[] arr)
        {
            return arrayToBstHelper(arr, 0, arr.Length - 1, null);
        }

        /*
         * The idea of this algorithm is simple. Divide the array into 3 parts:
         * 
         * 1) Left part of the array, recursively build out the subtree
         * 2) Middle single element, which becomes the node
         * 3) Right part of the array, recursively build out the subtree
         */
        private static TreeNode arrayToBstHelper(int[] arr, int begin, int end, TreeNode parent)
        {
            if (end < begin)
            {
                return null;
            }

            int mid = (end - begin) / 2 + begin;
            TreeNode newNode = new TreeNode(arr[mid]);

            newNode.Parent = parent;
            newNode.Left = arrayToBstHelper(arr, begin, mid - 1, newNode);
            newNode.Right = arrayToBstHelper(arr, mid + 1, end, newNode);

            return newNode;
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
