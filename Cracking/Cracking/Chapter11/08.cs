using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Imagine you are reading in a stream of integers. Periodically, you wish to be able
 * to look up the rank of a number x (the number of values less than or equal tox).
 * Implement the data structures and algorithms to support these operations. That
 * is, implement the method track(int x), which is called when each number
 * is generated, and the method getRankOfNumber(int x), which returns the
 * number of values less than or equal to x (not including x itself).
 * 
 * EXAMPLE
 * Stream (in order of appearance): 5, 1, 4, 4, 5, 9, 7, 13, 3
 * getRankOfNumber(l) = 0
 * getRankOfNumber(3) = 1
 * getRankOfNumber(4) = 3
 */
namespace Cracking.Chapter11
{
    /*
     * This implementation has the advantage of speedy lookups. Insert suffers from being O(N) in the worst case however
     * (technically O(M), where M is number of distinct N).
     */
    class DictionaryTracker
    {
        private Dictionary<int, int> intTracker = new Dictionary<int, int>();

        public void track(int num)
        {
            if (intTracker.ContainsKey(num))
            {
                var keyList = intTracker.Keys.ToList(); // needed because cannot modify dictionary in foreach
                foreach (int key in keyList)
                {
                    if (key >= num)
                    {
                        intTracker[key]++;
                    }
                }
            }
            else
            {
                var smallerValuesThanNum = intTracker.Keys.Where(x => x < num).OrderBy(x => num - x);
                
                if (smallerValuesThanNum.Count() > 0)
                {
                    intTracker[num] = intTracker[smallerValuesThanNum.First()] + 1;
                }
                else
                {
                    intTracker[num] = 0;
                }

                var keyList = intTracker.Keys.ToList(); // needed because cannot modify dictionary in foreach
                foreach (int key in keyList)
                {
                    if (key > num)
                    {
                        intTracker[key]++;
                    }
                }
            }
        }

        public int getRankOfNumber(int x)
        {
            return intTracker[x];
        }
    }

    /*
     * Use a binary search tree to track and then in-order traversal to find rank.
     * Provided the tree is balanced (would depend on the stream), we can achieve O(log(N)) for both insert and rank.
     * Balance of the tree in this case would depend on the input from the stream itself. Could potentially be O(N)
     * worst-case for insertions.
     */
    class TreeTracker
    {
        Node node;

        public void track(int i)
        {
            Node newNode = new Node(i);
            if (node == null)
            {
                node = newNode;
            }
            else
            {
                node.insert(newNode);
            }
        }

        public int getRankOfNumber(int i)
        {
            return node.getRank(i, 0);
        }
    }

    class Node
    {
        private Node left;
        private Node right;
        private int value;

        /*
         * Rank is just the in-order traversal of the tree, so we can save time by storing the size of the left subtree
         * to compute the in-order position of a node.
         */
        private int leftTreeSize;

        public Node(int n)
        {
            value = n;
            leftTreeSize = 0;
        }

        public void insert(Node node)
        {
            if (node.value <= value)
            {
                if (left == null)
                {
                    left = node;
                }
                else
                {
                    left.insert(node);
                }
                leftTreeSize++;
            }
            else
            {
                if (right == null)
                {
                    right = node;
                }
                else
                {
                    right.insert(node);
                }
            }
        }

        public int getRank(int i, int leftSize)
        {
            if (i == value)
            {
                return leftTreeSize + leftSize;
            }
            else if (i < value)
            {
                return left.getRank(i, leftSize);
            }
            else
            {
                return right.getRank(i, leftSize + leftTreeSize + 1);
            }
        }
    }

    [TestClass]
    public class Tests_11_08
    {
        [TestMethod]
        public void TestDictionary()
        {
            DictionaryTracker dt = new DictionaryTracker();
            
            dt.track(5);
            Assert.AreEqual(0, dt.getRankOfNumber(5));

            dt.track(1);
            dt.track(4);
            dt.track(4);
            Assert.AreEqual(2, dt.getRankOfNumber(4));

            dt.track(5);
            dt.track(9);
            dt.track(7);
            dt.track(13);
            dt.track(3);

            Assert.AreEqual(0, dt.getRankOfNumber(1));
            Assert.AreEqual(1, dt.getRankOfNumber(3));
            Assert.AreEqual(3, dt.getRankOfNumber(4));
        }

        [TestMethod]
        public void TestTree()
        {
            TreeTracker tt = new TreeTracker();

            tt.track(5);
            Assert.AreEqual(0, tt.getRankOfNumber(5));

            tt.track(1);
            tt.track(4);
            tt.track(4);
            Assert.AreEqual(2, tt.getRankOfNumber(4));

            tt.track(5);
            tt.track(9);
            tt.track(7);
            tt.track(13);
            tt.track(3);

            Assert.AreEqual(0, tt.getRankOfNumber(1));
            Assert.AreEqual(1, tt.getRankOfNumber(3));
            Assert.AreEqual(3, tt.getRankOfNumber(4));
        }
    }
}
