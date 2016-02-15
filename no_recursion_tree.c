#include <stdio.h>
#include <stdlib.h>

typedef struct treenode {
  int value;
  struct treenode * left;
  struct treenode * right;
} treenode;

typedef 

treenode * createBSTFromArray(int * a, int size)
{
  treenode * root = (treenode *) malloc(sizeof(treenode));

  if (size != 0) {
    if (size % 2 == 0) {
      root->value = a[size / 2];
      root->left = createBSTFromArray(a, size / 2);
      root->right = createBSTFromArray(a + (size / 2 + 1), size / 2 - 1);
    }
    else {
      root->value = a[size / 2];
      root->left = createBSTFromArray(a, size / 2);
      root->right = createBSTFromArray(a + (size / 2 + 1), size / 2);
    }
    return root;
  }
  else {
    return NULL;
  }
}

void printInOrderWithoutRecursion(treenode * tree)
{
  
}

int main()
{
  int a[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

  treenode * tree_ptr = createBSTFromArray(a, 12);

  
}
