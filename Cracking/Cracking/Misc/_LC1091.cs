using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.

    A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:

    All the visited cells of the path are 0.
    All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
    The length of a clear path is the number of visited cells of this path.
 */
namespace Cracking.Misc
{
    class LC1091
    {
        static int[][] Directions = new int[][] {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0},
                new int[] {1, 1},
                new int[] {1, -1},
                new int[] {-1, 1},
                new int[] {-1, -1},

        };

        public int ShortestPathBinaryMatrix(int[][] grid) 
        {
            HashSet<int[]> visited = new HashSet<int[]>(new IntArrComparer());
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] {0, 0, 1});

            while (queue.Count > 0)
            {
                int[] node = queue.Dequeue();

                if (grid[node[0]][node[1]] == 1)
                {
                    continue;
                }

                if (visited.Contains(new int[] {node[0], node[1]}))
                {
                    continue;
                }

                if (node[1] == grid.Length - 1 && node[0] == grid[0].Length - 1)
                {
                    return node[2];
                }

                visited.Add(new int[] {node[0], node[1]});

                foreach (int[] d in Directions)
                {
                    int newX = node[0] + d[0];
                    int newY = node[1] + d[1];
                    if (newX < grid[0].Length && newX >= 0 && newY < grid.Length && newY >= 0)
                    {
                        queue.Enqueue(new int[] {node[0] + d[0], node[1] + d[1], node[2] + 1});
                    }
                }
            }

            return -1;
        }

        class IntArrComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return x[0] == y[0] && x[1] == y[1];
            }

            public int GetHashCode(int[] obj)
            {
                string code = obj[0].ToString() + obj[1].ToString();
                return code.GetHashCode();
            }
        }
    }

    [TestClass]
    public class Tests_LC1091
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[2][];
            arr[0] = new int[] {0, 1};
            arr[1] = new int[] {1, 0};

            LC1091 test = new LC1091();
            var a = test.ShortestPathBinaryMatrix(arr);
        }

        [TestMethod]
        public void Test1()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 0, 0};
            arr[1] = new int[] {1, 1, 0};
            arr[2] = new int[] {1, 1, 0};

            LC1091 test = new LC1091();
            var a = test.ShortestPathBinaryMatrix(arr);
        }

        [TestMethod]
        public void Test2()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] {0, 0, 0};
            arr[1] = new int[] {1, 0, 0};
            arr[2] = new int[] {1, 1, 0};

            LC1091 test = new LC1091();
            var a = test.ShortestPathBinaryMatrix(arr);
        }
    }
}
