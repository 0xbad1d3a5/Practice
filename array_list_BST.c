#include <stdio.h>
#include <stdlib.h>

typedef struct treenode
{
  int value;
  struct treenode * left;
  struct treenode * right;
} treenode;

typedef struct node
{
  int value;
  struct node * next;
} node;

//// Tests

void printList(node * ptr)
{
  node * curr = ptr;
  while (curr != NULL) {
    printf("%d ", curr->value);
    curr = curr->next;
  }
  printf("\n");
}

void printTree(treenode * ptr)
{
  if (ptr != NULL) {
    printf("( ");
    printf("%d ", ptr->value);
    printTree(ptr->left);
    printTree(ptr->right);
    printf(" )");
  }
}

//// Functions

node * createLinkedListFromArray(int * a, int size)
{
  if (size == 0){
    return NULL;
  }

  node * head = (node *) malloc(sizeof(node));
  head->value = a[0];
  node * curr = head;
  
  int i;
  for (i = 1; i < size; i++){
    curr->next = (node *) malloc(sizeof(node));
    curr->next->value = a[i];
    curr = curr->next;
  }
  
  // memory leak, oh well.
  return head;
}

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

void inOrder(treenode * ptr, int * a, int * pos)
{
  if (ptr != NULL){
    inOrder(ptr->left, a, pos);
    a[*pos] = ptr->value;
    *pos += 1;
    inOrder(ptr->right, a, pos);
  }
}

int * createArrayFromBST(treenode * ptr, int size)
{
  
  int * a = (int *) malloc(sizeof(int));

  int pos;
  inOrder(ptr, a, &pos);

  // more memory leaks, horray!
  return a;
}

int main()
{

  int a[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
  printf("%lu\n", sizeof(a));
  int size = sizeof(a) / sizeof(a[0]);

  node * ptr = createLinkedListFromArray(a, size);
  printf("List: ");
  printList(ptr);

  printf("Tree: ");
  treenode * treeptr = createBSTFromArray(a, size);
  printTree(treeptr);
  printf("\n");

  int * b = createArrayFromBST(treeptr, size);
  
  printf("Array: ");
  int i;
  for (i = 0; i < size; i++){
    printf("%d ", b[i]);
  }
  printf("\n");

  return 0;
}
