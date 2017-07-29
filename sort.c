#include <stdio.h>
#include <stdlib.h>

void swap(int * a, int * b)
{
  int temp = * b;
  * b = * a;
  * a = temp;
}

void quicksort(int * array, int l, int r)
{
  if (l >= r) {
    return;
  }

  int left = l;
  int right = r;
  int pivot = right;
  right--;
  
  // Partition
  while (1) {
    // Keep going until we find array[left] that's greater than pivot
    // No need to check for termination because array[left] will eventually hit the pivot
    while (array[pivot] > array[left]) {
      left++;
    }
    // Keep going until we find array[right] that's smaller than pivot
    while (array[pivot] < array[right]) {
      if (right == l) {
        break; // Need to check termination because we might hit the end of the array
      }
      right--;
    }
    // Stop when it's already sorted
    if (left >= right) {
      break;
    }    
    // swap the elements
    swap(&array[left], &array[right]);
  }
  swap(&array[left], &array[pivot]);

  quicksort(array, l, left-1);
  quicksort(array, left+1, r);
}

void printArray(int * a, int size)
{
  int i;
  for (i = 0; i < size; i++) {
    printf("%d ", a[i]);
  }
  printf("\n");
}

int main()
{
  int a[] = { 9, 6, 3, 8, 5, 2, 7, 4, 1 };
  int size = sizeof(a) / sizeof(a[0]);

  printArray(a, size);
  quicksort(a, 0, size - 1);
  printArray(a, size);
}
