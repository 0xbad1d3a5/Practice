using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree, and every node has no left child and only one right child.
 */
namespace Cracking.Misc
{
    class LC785
    {
        public bool IsBipartite(int[][] graph) 
        {
            if (graph == null || graph.Length == 0)
            {
                return false;
            }

            int[] colors = new int[graph.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == 1 || colors[i] == -1)
                {
                    continue;
                }

                if (!bfs(graph, colors, i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool bfs(int[][] graph, int[] colors, int startIdx)
        {
            Queue<Tuple<int, int, int[]>> queue = new Queue<Tuple<int, int, int[]>>();
            queue.Enqueue(Tuple.Create(startIdx, 1, graph[startIdx]));

            while (queue.Count > 0)
            {
                Tuple<int, int, int[]> currNode = queue.Dequeue();

                foreach (int n in currNode.Item3)
                {
                    if (colors[n] == 0)
                    {
                        colors[n] = currNode.Item2 * -1;
                        queue.Enqueue(Tuple.Create(n, currNode.Item2 * -1, graph[n]));
                    }
                    else
                    {
                        if (colors[currNode.Item1] == colors[n])
                        {
                            return false;
                        }
                    }                    
                }
            }

            return true;
        }
    }

    [TestClass]
    public class Tests_LC785
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[4][];
            arr[0] = new int[] {1, 2, 3};
            arr[1] = new int[] {0, 2};
            arr[2] = new int[] {0, 1, 3};
            arr[3] = new int[] {0, 2};

            LC785 test = new LC785();
            test.IsBipartite(arr);
        }

        [TestMethod]
        public void Test1()
        {
            int[][] arr = new int[4][];
            arr[0] = new int[] {1, 3};
            arr[1] = new int[] {0, 2};
            arr[2] = new int[] {1, 3};
            arr[3] = new int[] {0, 2};

            LC785 test = new LC785();
            test.IsBipartite(arr);
        }

        [TestMethod]
        public void Test2()
        {
            int[][] arr = new int[4][];
            arr[0] = new int[] {1};
            arr[1] = new int[] {0, 3};
            arr[2] = new int[] {3};
            arr[3] = new int[] {1, 2};

            LC785 test = new LC785();
            test.IsBipartite(arr);
        }

        [TestMethod]
        public void Test3()
        {
            int[][] arr = new int[10][];
            arr[0] = new int[] {};
            arr[1] = new int[] {2,4,6};
            arr[2] = new int[] {1,4,8,9};
            arr[3] = new int[] {7,8};
            arr[4] = new int[] {1,2,8,9};
            arr[5] = new int[] {6,9};
            arr[6] = new int[] {1,5,7,8,9};
            arr[7] = new int[] {3,6,9};
            arr[8] = new int[] {2,3,4,6,9};
            arr[9] = new int[] {2,4,5,6,7,8};

            LC785 test = new LC785();
            test.IsBipartite(arr);
        }
    }
}