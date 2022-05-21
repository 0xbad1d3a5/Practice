using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are a hiker preparing for an upcoming hike. You are given heights, a 2D array of size rows x columns, where heights[row][col] represents the height of cell (row, col). You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.

    A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.

    Return the minimum effort required to travel from the top-left cell to the bottom-right cell.
 */
namespace Cracking.Misc
{
    class LC1631
    {
        // Got the answer, think I just implemented Dijkstra's Algorithm unknowingly...
        public int MinimumEffortPath(int[][] heights)
        {
            int[][] dirs = new int[][] {
                new int[] {0, 1},
                new int[] {0, -1},
                new int[] {1, 0},
                new int[] {-1, 0},
            };

            HashSet<int[]> visited = new HashSet<int[]>(new IntArrComparer());
            PriorityQueue<int[], int> queue = new PriorityQueue<int[], int>();
            queue.Enqueue(new int[] {0, 0}, 0);

            int[] curr;
            int effort = 0;
            while (queue.Count > 0)
            {
                queue.TryPeek(out curr, out effort);
                queue.Dequeue();

                if (curr[0] == heights[0].Length - 1 && curr[1] == heights.Length - 1)
                {
                    break;
                }

                visited.Add(curr);

                for (int i = 0; i < dirs.Length; i++)
                {
                    int x = dirs[i][0] + curr[0];
                    int y = dirs[i][1] + curr[1];
                    if (x >= 0 && x < heights[0].Length && y >= 0 && y < heights.Length)
                    {
                        if (!visited.Contains(new int[] {x, y}))
                        {
                            int newEffort = Math.Abs(heights[y][x] - heights[curr[1]][curr[0]]);
                            queue.Enqueue(new int[] {x, y}, newEffort > effort ? newEffort : effort);
                        }
                    }
                }
            }

            return effort;
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
    public class Tests_LC1631
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 2, 2};
            arr[1] = new int[] {3, 8, 2};
            arr[2] = new int[] {5, 3, 5};

            LC1631 test = new LC1631();
            test.MinimumEffortPath(arr);
        }

        [TestMethod]
        public void Test1()
        {
            int[][] arr = new int[1][];
            arr[0] = new int[] {1,10,6,7,9,10,4,9};

            LC1631 test = new LC1631();
            test.MinimumEffortPath(arr);
        }
    }
}
