using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an m x n integers matrix, return the length of the longest increasing path in matrix.

    From each cell, you can either move in four directions: left, right, up, or down. You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).
 */
namespace Cracking.Misc
{
    class LC329
    {
        int[][] dirs = new int[][] {
                new int[] {0, 1},
                new int[] {0, -1},
                new int[] {1, 0},
                new int[] {-1, 0},
        };

        public int LongestIncreasingPath(int[][] matrix)
        {
            Dictionary<int[], int> dp = new Dictionary<int[], int>(new IntArrComparer());

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    dfs(matrix, dp, x, y, matrix[y][x]);
                }
            }

            return dp.Values.Max();
        }

        public int dfs(int[][] matrix, Dictionary<int[], int> dp, int x, int y, int currNumXY)
        {
            int cachedVal;
            if (dp.TryGetValue(new int[] {x, y}, out cachedVal))
            {
                return cachedVal;
            }

            List<int[]> canMoveCoord = new List<int[]>();

            foreach (int[] d in dirs)
            {
                int newX = x + d[0];
                int newY = y + d[1];

                if (newY < matrix.Length && newY >= 0 &&
                    newX < matrix[0].Length && newX >= 0 &&
                    matrix[newY][newX] > currNumXY)
                    {
                        canMoveCoord.Add(new int[] {newX, newY});
                    }
            }
            
            if (canMoveCoord.Count == 0)
            {
                dp[new int[] {x, y}] = 1;
                return 1;
            }

            int longestPath = 0;

            foreach (int[] c in canMoveCoord)
            {
                int currPath = dfs(matrix, dp, c[0], c[1], matrix[c[1]][c[0]]) + 1;
                longestPath = currPath > longestPath ? currPath : longestPath;
            }

            dp[new int[] {x, y}] = longestPath;

            return longestPath;
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
    public class Tests_LC329
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] {9, 9, 4};
            arr[1] = new int[] {6, 6, 8};
            arr[2] = new int[] {2, 1, 1};

            LC329 test = new LC329();
            var a = test.LongestIncreasingPath(arr);
        }
    }
}
