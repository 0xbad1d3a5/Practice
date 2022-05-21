using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m-1][n-1]). The robot can only move either down or right at any point in time.

    An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square that is an obstacle.

    Return the number of possible unique paths that the robot can take to reach the bottom-right corner.

    The testcases are generated so that the answer will be less than or equal to 2 * 109.
 */
namespace Cracking.Misc
{
    class LC63
    {
        int[][] dirs = new int[][] {
                new int[] {0, -1},
                new int[] {-1, 0},
        };

        // DYNAMIC PROGRAMMING
        public int UniquePathsWithObstacles(int[][] obstacleGrid) 
        {
            if (obstacleGrid[0][0] == 1)
            {
                return 0;
            }
            else 
            {
                obstacleGrid[0][0] = 1;
            }

            for (int y = 0; y < obstacleGrid.Length; y++)
            {
                for (int x = 0; x < obstacleGrid[0].Length; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    if (obstacleGrid[y][x] == 1)
                    {
                        obstacleGrid[y][x] = 0;
                    }
                    else 
                    {
                        List<int[]> prevCoords = GetPossiblePrevCoord(obstacleGrid, x, y);
                        int sumCurrPath = prevCoords.Select(p => obstacleGrid[p[1]][p[0]]).Sum();
                        obstacleGrid[y][x] = sumCurrPath;
                    }
                }
            }

            return obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[0].Length - 1];
        }

        public List<int[]> GetPossiblePrevCoord(int[][] obstacleGrid, int x, int y)
        {
            List<int[]> prevCoords = new List<int[]>();

            foreach (int[] d in dirs)
            {
                int newX = x + d[0];
                int newY = y + d[1];

                if (newX < obstacleGrid[0].Length && newX >= 0 &&
                    newY < obstacleGrid.Length && newY >= 0)
                    {
                        prevCoords.Add(new int[] {newX, newY});
                    }
            }

            return prevCoords;
        }
    }

    [TestClass]
    public class Tests_LC63
    {
        [TestMethod]
        public void Test()
        {
            LC63 test = new LC63();
            int[][] arr = new int[3][];
            arr[0] = new int[] {0, 0, 0};
            arr[1] = new int[] {0, 1, 0};
            arr[2] = new int[] {0, 0, 0};
            var a = test.UniquePathsWithObstacles(arr);
        }
    }
}
