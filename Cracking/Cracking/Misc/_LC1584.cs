using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].

    The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.

    Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.
 */
namespace Cracking.Misc
{
    class LC1584
    {
        // Optimized Prim's algorithm uses a priority queue to keep track of the lowest weight
        public static int MinCostConnectPoints(int[][] points)
        {
            if (points.Length == 0)
            {
                return 0;
            }

            PriorityQueue<int[], int> toVisit = new PriorityQueue<int[], int>();
            HashSet<int[]> mstTree = new HashSet<int[]>();
            HashSet<int[]> unvisited = new HashSet<int[]>();
            int minCost = 0;

            mstTree.Add(points[0]);

            for (int i = 1; i < points.Length; i++)
            {
                unvisited.Add(points[i]);
                toVisit.Enqueue(points[i], Math.Abs(points[i][0] - points[0][0]) + Math.Abs(points[i][1] - points[0][1]));
            }
            
            while (mstTree.Count != points.Length)
            {
                int[] minP;
                int cost;
                toVisit.TryPeek(out minP, out cost);
                toVisit.Dequeue();

                if (mstTree.Contains(minP))
                {
                    continue;
                }

                minCost += cost;
                mstTree.Add(minP);
                unvisited.Remove(minP);

                foreach (int[] p in unvisited)
                {
                    toVisit.Enqueue(p, Math.Abs(p[0] - minP[0]) + Math.Abs(p[1] - minP[1]));
                }
            }

            return minCost;
        }

        // Solution works, but times out
        // Prim's Algorithm naive
        public static int MinCostConnectPointsTimeout(int[][] points)
        {   
            if (points.Length == 0)
            {
                return 0;
            }

            HashSet<int[]> partOfMinTree = new HashSet<int[]>();
            HashSet<int[]> unprocessedPoints = new HashSet<int[]>();
            int minCost = 0;

            partOfMinTree.Add(points[0]);
            for (int i = 1; i < points.Length; i++)
            {
                unprocessedPoints.Add(points[i]);
            }

            while (unprocessedPoints.Count > 0)
            {
                int[] pointToAdd = unprocessedPoints.ElementAt(0);
                int cost = Math.Abs(partOfMinTree.ElementAt(0)[0] - pointToAdd[0]) + Math.Abs(partOfMinTree.ElementAt(0)[1] - pointToAdd[1]);

                foreach (int[] minP in partOfMinTree)
                {
                    foreach (int[] unP in unprocessedPoints)
                    {
                        int costNew = Math.Abs(minP[0] - unP[0]) + Math.Abs(minP[1] - unP[1]);

                        if (costNew <= cost)
                            {
                                pointToAdd = unP;
                                cost = costNew;
                            }
                    }
                }

                unprocessedPoints.Remove(pointToAdd);
                partOfMinTree.Add(pointToAdd);
                minCost += cost;
            }

            return minCost;
        }
    }

    [TestClass]
    public class Tests_LC1584
    {
        [TestMethod]
        public void Test()
        {
            int[][] dots = new int[][] {
                new int[] {0, 0},
                new int[] {2, 2},
                new int[] {3, 10},
                new int[] {5, 2},
                new int[] {7, 0},
            };

            LC1584.MinCostConnectPoints(dots);
        }
    }
}
