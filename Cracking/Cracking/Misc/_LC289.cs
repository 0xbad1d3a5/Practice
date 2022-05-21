using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    According to Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

    The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

    Any live cell with fewer than two live neighbors dies as if caused by under-population.
    Any live cell with two or three live neighbors lives on to the next generation.
    Any live cell with more than three live neighbors dies, as if by over-population.
    Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
    The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously. Given the current state of the m x n grid board, return the next state.
 */
namespace Cracking.Misc
{
    class LC289
    {
        // All 8 directions a neighbor can be on the 2D array
        public static int[,] Directions = {
            {1, 0}, 
            {1, 1},
            {0, 1},
            {1, -1},
            {0, -1},
            {-1, -1},
            {-1, 1},
            {-1, 0},
            };

        // Play the game of life once
        // Reduce memory and do in-place by using other bits in int to represent next state and shift
        public static void GameOfLife(int[][] board) {
            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board[i].Length; k++)
                {
                    if (CheckCellAlive(board, i, k)){
                        board[i][k] = board[i][k] | 1 << 1;
                    }
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board[i].Length; k++)
                {
                    board[i][k] = board[i][k] >> 1;
                }
            }
        }

        public static bool CheckCellAlive(int[][] board, int x, int y)
        {
            bool isCellAlive = (board[x][y] & 1) == 1;

            int aliveNeighborsCount = 0;
            for (int i = 0; i < Directions.GetLength(0) && aliveNeighborsCount < 4; i++)
            {
                int nx = x + Directions[i, 0];
                int ny = y + Directions[i, 1];

                if (nx < 0 || nx >= board.Length || ny < 0 || ny >= board[0].Length)
                {
                    continue;
                }

                if ((board[nx][ny] & 1) == 1)
                {
                    aliveNeighborsCount++;
                }
            }

            if (isCellAlive)
            {
                if (aliveNeighborsCount == 2 || aliveNeighborsCount == 3)
                {
                    return true;
                }

                return false;
            }
            else {
                if (aliveNeighborsCount == 3)
                {
                    return true;
                }

                return false;
            }
        }
    }

    [TestClass]
    public class Tests_LC289
    {
        [TestMethod]
        public void Test()
        {
            int[][] arr = new int[4][];
            arr[0] = new int[] {0,1,0};
            arr[1] = new int[] {0,0,1};
            arr[2] = new int[] {1,1,1};
            arr[3] = new int[] {0,0,0};

            LC289.GameOfLife(arr);
        }
    }
}
