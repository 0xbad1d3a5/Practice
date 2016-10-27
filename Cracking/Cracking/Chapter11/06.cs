using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given an M x N matrix in which each row and each column is sorted in ascending
 * order, write a method to find an element.
 */
namespace Cracking.Chapter11
{
    class NumberNotFound : Exception {

    }
    
    /*
     * The key to solving this problem is realizing that:
     * 
     * (This algorithm starts from the top-right of the matrix) 
     * 1) If the first element of a column is greater than the search value, then the value cannot possibly be in that column.
     *    This is because the first element of a column would be the column's smallest number, due to being sorted. Move one column to the left and continue searching.
     * 2) If the last element of a row is smaller than the search value, then the value cannot possibly be in that row.
     *    This is because the last element of of a row would be the row's biggest number, due to being sorted. Move one row down and continue searching.
     */
    class _06
    {
        public static int[] findValueInSortedMatrix(int[,] matrix, int rowPos, int colPos, int value)
        {
            if (rowPos > matrix.GetLength(0) || colPos < 0)
            {
                throw new NumberNotFound();
            }

            if (matrix[rowPos, colPos] == value)
            {
                return new int[] { rowPos, colPos };
            }
            else if (matrix[rowPos, colPos] > value)
            {
                return findValueInSortedMatrix(matrix, rowPos, colPos - 1, value);
            }
            else
            {
                return findValueInSortedMatrix(matrix, rowPos + 1, colPos, value);
            }
        }
    }

    [TestClass]
    public class Tests_11_06
    {
        [TestMethod]
        public void Test()
        {
            int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            int[] result = _06.findValueInSortedMatrix(matrix, 0, matrix.GetLength(1) - 1, 6);
            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 1 }));

            result = _06.findValueInSortedMatrix(matrix, 0, matrix.GetLength(1) - 1, 10);
            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 1 }));
        }

        [TestMethod]
        public void Test1()
        {
            int[,] matrix = new int[4, 4] { { 15, 20, 40, 85 }, { 20, 35, 80, 95 }, { 30, 55, 95, 105 }, { 40, 80, 100, 120 } };

            int[] result = _06.findValueInSortedMatrix(matrix, 0, matrix.GetLength(1) - 1, 55);
            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 1 }));
        }

        [TestMethod]
        [ExpectedException(typeof(NumberNotFound))]
        public void Test2()
        {
            int[,] matrix = new int[4, 4] { { 15, 20, 40, 85 }, { 20, 35, 80, 95 }, { 30, 55, 95, 105 }, { 40, 80, 100, 120 } };

            int[] result = _06.findValueInSortedMatrix(matrix, 0, matrix.GetLength(1) - 1, 0);
        }
    }
}
