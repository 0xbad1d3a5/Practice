using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given a 2D grid of size m x n and an integer k. You need to shift the grid k times.

    In one shift operation:

    Element at grid[i][j] moves to grid[i][j + 1].
    Element at grid[i][n - 1] moves to grid[i + 1][0].
    Element at grid[m - 1][n - 1] moves to grid[0][0].
    Return the 2D grid after applying shift operation k times.
 */
namespace Cracking.Misc
{
    class LC1260
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
            
            int timesToShift = grid.Length * grid[0].Length;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int rowsToShift = k / grid.Length;
                    int colsToShift = k % grid[i].Length;

                    int tempVal = grid[i + rowsToShift % grid.Length][colsToShift];


                }
            }

            return null;
        }

        public static IList<IList<int>> ShiftGridNaive(int[][] grid, int k) {
            
            int gridSize = grid.Length * grid[0].Length;
            int shiftTimes = k % gridSize;

            if (shiftTimes == 0)
            {
                return grid;
            }

            int[] flat = new int[gridSize];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int origFlatPos = i * grid[0].Length + j;
                    int newFlatPos = (origFlatPos + k) % gridSize;
                    flat[newFlatPos] = grid[i][j];
                }
            }

            int[][] resultGrid = new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                resultGrid[i] = new int[grid[0].Length];

                for (int j = 0; j < grid[0].Length; j++)
                {
                    resultGrid[i][j] = flat[i * grid[0].Length + j];
                }
            }

            return resultGrid;
        }
    }

    [TestClass]
    public class Tests_LC1260
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 2, 3};
            arr[1] = new int[] {4, 5, 6};
            arr[2] = new int[] {7, 8, 9};

            LC1260.ShiftGridNaive(arr, 1);
        }

        [TestMethod]
        public void Test1()
        {
            int[][] arr = new int[7][];
            arr[0] = new int[] {1};
            arr[1] = new int[] {2};
            arr[2] = new int[] {3};
            arr[3] = new int[] {4};
            arr[4] = new int[] {7};
            arr[5] = new int[] {6};
            arr[6] = new int[] {5};

            LC1260.ShiftGridNaive(arr, 23);
        }
    }
}
