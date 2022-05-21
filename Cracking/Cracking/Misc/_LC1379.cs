using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given two binary trees original and cloned and given a reference to a node target in the original tree.

    The cloned tree is a copy of the original tree.

    Return a reference to the same node in the cloned tree.

    Note that you are not allowed to change any of the two trees or the target node and the answer must be a reference to a node in the cloned tree.
 */
namespace Cracking.Misc
{
    class LC1379
    {
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) 
        {
            if (original == null)
            {
                return null;
            }

            if (original == target)
            {
                return cloned;
            }

            TreeNode t1 = GetTargetCopy(original.left, cloned.left, target);
            TreeNode t2 = GetTargetCopy(original.right, cloned.right, target);

            return t1 == null ? t2 : t1;
        }
    }

    [TestClass]
    public class Tests_LC1379
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
