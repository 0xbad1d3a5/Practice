using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
 */
namespace Cracking.Misc
{
    class LC59
    {
        /*
            This solution takes the matrix in layers, progressively going inside in a spiral
        */
        public static int[][] GenerateMatrix(int n) {
            
            int count = 1;
            int maxLayer = n / 2;
            int currLayer = 0;
            int[][] spiralMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                spiralMatrix[i] = new int[n];
            }

            for (int i = 0; i < maxLayer; i++)
            {
                // Top Horizontal 
                for (int k = 0 + currLayer; k < n - currLayer; k++)
                {
                    spiralMatrix[currLayer][k] = count;
                    count++;
                }
                // Right Vertical
                for (int k = 0 + currLayer + 1; k < n - currLayer - 1; k++)
                {
                    spiralMatrix[k][n - currLayer - 1] = count;
                    count++;
                }
                // Bottom Horizontal
                for (int k = n - currLayer - 1; k >= currLayer; k--)
                {
                    spiralMatrix[n - currLayer - 1][k] = count;
                    count++;
                }
                // Left Vertical
                for (int k = n - currLayer - 2; k >= 0 + currLayer + 1; k--)
                {
                    spiralMatrix[k][currLayer] = count;
                    count++;
                }

                currLayer++;
            }

            if (n % 2 == 1)
            {
                int m = n/2;
                spiralMatrix[m][m] = count;
            }

            PrintMatrix(spiralMatrix);

            return spiralMatrix;
        }

        /*
            This solution takes advantage of the fact that we don't need to know where we are going:
            if we hit a out of bounds or a cell that was already filled, we can just change direction
            If we can't change direction (or pre-compute the last cell value), then we are done.
        */
        public static int[][] GenerateMatrixBlindWalk(int n)
        {
            int[][] spiralMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                spiralMatrix[i] = new int[n];
            }

            int lastX;
            int lastY;
            if (n % 2 == 1)
            {
                lastX = n / 2;
                lastY = n / 2;
            }
            else
            {
                lastX = n / 2;
                lastY = n / 2 - 1;
            }

            int currDirection = 0;

            int x = 0;
            int y = 0;
            int count = 1;
            while (true)
            {
                spiralMatrix[x][y] = count;

                if (x == lastX && y == lastY)
                {
                    break;
                }

                switch (currDirection)
                {
                    case 0:
                        y += 1;
                        if (y > n - 1 || spiralMatrix[x][y] != 0)
                        {
                            currDirection++;
                            y -= 1;
                            x += 1;
                        }
                        break;
                    case 1:
                        x += 1;
                        if (x > n - 1 || spiralMatrix[x][y] != 0)
                        {
                            currDirection++;
                            x -= 1;
                            y -= 1;
                        }
                        break;
                    case 2:
                        y -= 1;
                        if (y < 0 || spiralMatrix[x][y] != 0)
                        {
                            currDirection++;
                            y += 1;
                            x -= 1;
                        }
                        break;
                    case 3:
                        x -= 1;
                        if (x < 0 || spiralMatrix[x][y] != 0)
                        {
                            currDirection++;
                            x += 1;
                            y += 1;
                        }
                        break;
                }

                count++;
                currDirection %= 4;
            }

            PrintMatrix(spiralMatrix);

            return spiralMatrix;
        }
    
        public static void PrintMatrix(int[][] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    Console.Write(matrix[i][k].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }

    }

    [TestClass]
    public class Tests_LC59
    {
        [TestMethod]
        public void Test()
        {
            LC59.GenerateMatrix(5);
        }

        [TestMethod]
        public void Test1()
        {
            LC59.GenerateMatrixBlindWalk(6);
        }
    }
}
