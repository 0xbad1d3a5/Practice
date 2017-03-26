using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Chapter11
{
    class Sorting
    {
        /*
         * Bubble Sort: Two nested for loops, only the inner loop does comparisons
         */
        public static void bubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swap(array, j, j + 1);
                    }
                }
            }
        }

        /*
         * Selection Sort: Select the next number from the unsorted subarray
         */
        public static void selectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int smallestNumPos = i;
                
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[smallestNumPos])
                    {
                        smallestNumPos = j;
                    }
                }

                swap(array, i, smallestNumPos);
            }
        }

        /*
         * Insertion Sort: Expand the sorted subarray by one, then insert the expanded number into the correct position in the sorted subarray
         * The inner for loop is very much like bubble sort's inner for loop, except backwards
         */
        public static void insertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        swap(array, j, j - 1);
                    }
                }
            }
        }

        /*
         * Merge Sort: Remember the base cases in the main function. Generally merge sort needs O(n) extra space.
         */
        public static int[] mergeSort(int[] array, int left, int right)
        {
            if (array.Length == 0)
            {
                return array;
            }
            if (right - left == 0)
            {
                return new int[] { array[left] };
            }

            int[] leftSide = mergeSort(array, left, (right - left) / 2 + left);
            int[] rightSide = mergeSort(array, (right - left) / 2 + left + 1, right);
            return merge(leftSide, rightSide);
        }

        /*
         * Meat of the merge sort algorithm: the merge. Again, need O(n) extra space.
         */
        private static int[] merge(int[] leftArray, int[] rightArray)
        {
            // Keep in mind you can break out early
            if (leftArray.Length == 0){
                return rightArray;
            }
            if (rightArray.Length == 0){
                return leftArray;
            }

            // Allocate memory to put result
            int[] result = new int[leftArray.Length + rightArray.Length];

            int leftPos = 0;
            int rightPos = 0;
            int resultPos = 0;

            /*
             * There are 4 possible conditions:
             * 1) Left array has no more items, fill result with right array
             * 2) Right array has no more items, fill result with left array
             * 3) Current left side is smaller than right side, put left side in result, increment left side
             * 4) Current right side is smaller than left side, put right side in result, increment right side
             */
            while (leftPos < leftArray.Length || rightPos < rightArray.Length)
            {
                if (leftPos == leftArray.Length){
                    result[resultPos] = rightArray[rightPos];
                    rightPos++;
                }
                else if (rightPos == rightArray.Length){
                    result[resultPos] = leftArray[leftPos];
                    leftPos++;
                }
                else if (leftArray[leftPos] < rightArray[rightPos])
                {
                    result[resultPos] = leftArray[leftPos];
                    leftPos++;
                }
                else
                {
                    result[resultPos] = rightArray[rightPos];
                    rightPos++;
                }
                resultPos++;
            }

            return result;
        }

        /*
         * Quicksort: Key point of the quicksort algorithm is the paritioning - partition the array around a pivot, one side greater and one side smaller
         */
        public static void quickSort(int[] array, int leftPos, int rightPos)
        {
            if (rightPos - leftPos <= 0){
                return;
            }
            if (rightPos - leftPos == 1)
            {
                if (array[leftPos] > array[rightPos])
                {
                    swap(array, leftPos, rightPos);
                }
                return;
            }

            int pivot = array[leftPos];
            int left = leftPos + 1;
            int right = rightPos;

            /*
             * 3 cases:
             * 1) Move the left pointer forward
             * 2) Move the right pointer backwards
             * 3) If the left side is greater than or equal to the right, then swap them to partition the array
             */
            while (left < right)
            {
                // Careful, this must be before the other two cases - otherwise we can end up with i.e., left == 4 && right == 2
                // Which is bad, because left & right should never be more than 1 apart for the stopping condition
                if (array[left] >= pivot && array[right] < pivot)
                {
                    swap(array, left, right);
                    left++;
                    right--;
                }
                if (array[left] < pivot)
                {
                    left++;
                }
                if (array[right] >= pivot)
                {
                    right--;
                }
            }

            if (array[leftPos] > array[right])
            {
                swap(array, leftPos, right);
            }

            quickSort(array, leftPos, right - 1);
            quickSort(array, right, rightPos);
        }

        private static void swap(int[] array, int x, int y)
        {
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }
    }

    [TestClass]
    public class Tests_11_Sorting
    {
        [TestMethod]
        public void TestBubble()
        {
            int[] array = new int[] { 5, 4, 2, 6, 1, 2 };
            Sorting.bubbleSort(array);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void TestSelection()
        {
            int[] array = new int[] { 5, 4, 2, 6, 1, 2 };
            Sorting.selectionSort(array);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void TestInsert()
        {
            int[] array = new int[] { 5, 4, 2, 6, 1, 2 };
            Sorting.insertionSort(array);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void TestMerge1()
        {
            int[] array = new int[] { 5, 4, 2, 6, 1, 2 };
            int[] result = Sorting.mergeSort(array, 0, array.Length - 1);
            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void TestMerge2()
        {
            int[] array = new int[] { 1 };
            int[] result = Sorting.mergeSort(array, 0, array.Length - 1);
            Assert.IsTrue(result.SequenceEqual(new int[] { 1 }));
        }

        [TestMethod]
        public void TestMerge3()
        {
            int[] array = new int[] { 2, 1 };
            int[] result = Sorting.mergeSort(array, 0, array.Length - 1);
            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void TestMerge4()
        {
            int[] array = new int[] { };
            int[] result = Sorting.mergeSort(array, 0, array.Length - 1);
            Assert.IsTrue(result.SequenceEqual(new int[] { }));
        }

        [TestMethod]
        public void TestMergeRandom()
        {
            Random r = new Random();
            for (int k = 0; k < 10000; k++)
            {
                int arraySize = r.Next(0, 1000);
                int[] array1 = new int[arraySize];
                int[] array2 = new int[arraySize];

                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = r.Next(Int32.MinValue, Int32.MaxValue);
                    array2[i] = array1[i];
                }

                int[] result = Sorting.mergeSort(array1, 0, array1.Length - 1);
                Sorting.selectionSort(array2);
                Assert.IsTrue(result.SequenceEqual(array2));
            }
        }

        [TestMethod]
        public void TestQuick1()
        {
            int[] array = new int[] { 5, 4, 2, 6, 1, 2 };
            Sorting.quickSort(array, 0, array.Length - 1);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2, 2, 4, 5, 6 }));
        }

        [TestMethod]
        public void TestQuick2()
        {
            int[] array = new int[] { 5, 8, 1, 3, 7, 9, 2 };
            Sorting.quickSort(array, 0, array.Length - 1);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2, 3, 5, 7, 8, 9 }));
        }

        [TestMethod]
        public void TestQuick3()
        {
            int[] array = new int[] { 1 };
            Sorting.quickSort(array, 0, array.Length - 1);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1 }));
        }

        [TestMethod]
        public void TestQuick4()
        {
            int[] array = new int[] { 2, 1 };
            Sorting.quickSort(array, 0, array.Length - 1);
            Assert.IsTrue(array.SequenceEqual(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void TestQuick5()
        {
            int[] array = new int[] { 7, 5, 6, 5, 6, 5, 6, 5, 4, 3, 6 };
            Sorting.quickSort(array, 0, array.Length - 1);
            Assert.IsTrue(array.SequenceEqual(new int[] { 3, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7 }));
        }

        [TestMethod]
        public void TestQuickRandom()
        {
            Random r = new Random();
            for (int k = 0; k < 10000; k++)
            {
                int arraySize = r.Next(0, 1000);
                int[] array1 = new int[arraySize];
                int[] array2 = new int[arraySize];

                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = r.Next(Int32.MinValue, Int32.MaxValue);
                    array2[i] = array1[i];
                }

                Sorting.quickSort(array1, 0, array1.Length - 1);
                Sorting.selectionSort(array2);
                Assert.IsTrue(array1.SequenceEqual(array2));
            }
        }
    }
}
