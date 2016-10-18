﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Given an image represented by an NxN matrix, where each pixel in the image is
 * 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in
 * place?
 */
namespace Cracking.Chapter01
{
    class _6
    {
        // https://leetcode.com/problems/rotate-image/
        // Optimization only works if matrix is NxN
        public static void RotateMatrix(int[,] matrix, int start, int end)
        {
            if (start > end)
            {
                return;
            }

            end = end - 1;
            int offset = 0; // Careful here, we need this variable (and can't do "end - i") because the end also has to one-by-one meet start
            for (int i = start; i < end; i++)
            {
                int temp = matrix[start, i];
                matrix[start, i] = matrix[end - offset, start];
                matrix[end - offset, start] = matrix[end, end - offset];
                matrix[end, end - offset] = matrix[i, end];
                matrix[i, end] = temp;
                offset++;
            }

            RotateMatrix(matrix, start + 1, end);
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
    public class Tests_01_6
    {
        [TestMethod]
        public void Test()
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 5 }, { 3, 4, 5, 6 }, { 4, 5, 6, 7 } };
            int[,] matrix1 = new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 6 }, { 3, 4, 5, 6, 7 }, { 4, 5, 6, 7, 8 }, { 5, 6, 7, 8, 9 } };

            _6.PrintMatrix(matrix);
            _6.RotateMatrix(matrix, 0, matrix.GetLength(0));
            _6.PrintMatrix(matrix);

            _6.PrintMatrix(matrix1);
            _6.RotateMatrix(matrix1, 0, matrix1.GetLength(0));
            _6.PrintMatrix(matrix1);
        }
    }
}
