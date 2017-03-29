using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Write an algorithm such that if an element in an MxN matrix is 0, its entire row
 * and column are set to 0.
 */
namespace Cracking.Chapter01
{
    class _07
    {
        /*
         * Note that you need at least two passes for this problem. If you attempt to do it in only one pass,
         * it will not work as future visits to a position that was previously set to zero will unintentially
         * set cells that should not be 0 to 0.
         * 
         * Solution is thus:
         * 1) Loop through the matrix, keep track of what columns and rows should be zero-ized in two separate arrays
         * 2) Loop through the matrix again, this time setting matrix[x, y] to be 0 if rows[x] == 0 || column[y] == 0
         */
        public static void SetMatrixRowColZero(int[,] matrix)
        {
            int[] rows = new int[matrix.GetLength(0)];
            int[] cols = new int[matrix.GetLength(1)];

            // Loop through the matrix and find which columns and rows have zeros
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows[i] = 1;
                        cols[j] = 1;
                    }
                }
            }

            // Go through the array again to set the correct elements
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rows[i] == 1 || cols[j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Diagnostics.Debug.Write(matrix[i,j]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }

    [TestClass]
    public class Tests_01_07
    {
        [TestMethod]
        public void Test(){

            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 0, 5 }, { 3, 4, 5, 6 }, { 4, 5, 6, 7 } };
            int[,] matrix1 = new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 6 }, { 3, 4, 5, 6, 7 }, { 4, 5, 6, 7, 8 }, { 5, 6, 7, 8, 9 }, {6, 7, 8, 9, 0} };

            _07.PrintMatrix(matrix);
            _07.SetMatrixRowColZero(matrix);
            _07.PrintMatrix(matrix);

            _07.PrintMatrix(matrix1);
            _07.SetMatrixRowColZero(matrix1);
            _07.PrintMatrix(matrix1);
        }
    }
}
