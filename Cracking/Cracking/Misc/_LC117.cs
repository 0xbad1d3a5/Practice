using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given a binary tree

    struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
    }

    Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

    Initially, all next pointers are set to NULL.
 */
namespace Cracking.Misc
{
    class LC117
    {
        public class Node
        {
            public Node next;
            public Node left;
            public Node right;
            public int val;

            public Node(int value)
            {
                val = value;
            }
        }

        public Node Connect(Node root) 
        {
            if (root == null)
            {
                return null;
            }

            List<Node> list = new List<Node> { root };

            while (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int nextIdx = i + 1;
                    if (nextIdx <= list.Count - 1)
                    {
                        list[i].next = list[i + 1];
                    }
                }

                list = GetNextLevel(list);
            }

            return root;
        }

        public List<Node> GetNextLevel(List<Node> currLevel)
        {
            List<Node> list = new List<Node>();

            foreach (Node n in currLevel)
            {
                if (n.left != null)
                {
                    list.Add(n.left);
                }

                if (n.right != null)
                {
                    list.Add(n.right);
                }
            }

            return list;
        }
    }

    [TestClass]
    public class Tests_LC117
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
