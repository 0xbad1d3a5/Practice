using System;
using System.Collections.Generic;
using System.Linq;

namespace Cracking.Misc
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static class CreateTreeFromList
    {
        public static TreeNode LevelOrder(int?[] list)
        {
            if (list.Length == 0)
            {
                return null;
            }

            Queue<TreeNode> levelOrder = new Queue<TreeNode>();
            TreeNode root = null;
            
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].HasValue)
                {
                    TreeNode node = new TreeNode(list[i].Value);
                    if (root == null)  root = node;
                }
                else {

                }
            }

            return root;
        }
    }
}