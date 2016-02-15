#include <stdio.h>
#include <stdlib.h>

typedef struct Node {
  int val;
  struct Node * left;
  struct Node * right;
} Node;

// Is basically INORDER traversal
void bstToList(Node *curr, Node **prev, Node **head){

  if (!curr) {
    return;
  }

  // inorder left
  bstToList(curr->left, prev, head);

  //////// inorder center ////////
  curr->left = *prev; // set curr->left to the prev pointer we saved below
  if (*prev) {
    (*prev)->right = curr; // set prev->right to our curr
  }
  // find the head of the list
  else {
    *head = curr;
  }
  // *prev is the last node we've visited
  *prev = curr;
  ////////////////////////////////
  
  // inorder right
  bstToList(curr->right, prev, head);
}

void printTree(Node * ptr)
{
  if (ptr != NULL) {
    printf("( ");
    printf("%d ", ptr->val);
    printTree(ptr->left);
    printTree(ptr->right);
    printf(" )");
  }
}

int main(){

  Node n0;
  Node n1;
  Node n2;
  Node n3;
  Node n4;
  Node n5;
  Node n6;

  n0.val = 0; n0.left = &n1; n0.right = &n2;
  n1.val = 1; n1.left = &n3; n1.right = &n4;
  n2.val = 2; n2.left = &n5; n2.right = &n6;
  n3.val = 3; n3.left = NULL; n3.right = NULL;
  n4.val = 4; n4.left = NULL; n4.right = NULL;
  n5.val = 5; n5.left = NULL; n5.right = NULL;
  n6.val = 6; n6.left = NULL; n6.right = NULL;

  printTree(&n0);
  printf("\n");

  Node *head = NULL;
  Node *prev = NULL;
  bstToList(&n0, &prev, &head);

  while (head != NULL) { 
    printf("%d ", head->val);
    head = head->right;
  }
  printf("\n");
  
  return 0;
}
