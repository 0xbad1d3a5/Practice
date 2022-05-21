using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

    BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor. The pointer should be initialized to a non-existent number smaller than any element in the BST.
    boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
    int next() Moves the pointer to the right, then returns the number at the pointer.
    Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

    You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.
 */
namespace Cracking.Misc
{
    class LC173
    {
        public class BSTIterator {

            Stack<TreeNode> stack = new Stack<TreeNode>();
            
            public BSTIterator(TreeNode root)
            {
                UpdateStack(root);
            }
    
            public int Next()
            {
                TreeNode node = stack.Pop();
                UpdateStack(node.right);
                return node.val;
            }
    
            public bool HasNext()
            {
                return stack.Count > 0;
            }

            private void UpdateStack(TreeNode node)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
            }
        }
    }

    [TestClass]
    public class Tests_LC173
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
