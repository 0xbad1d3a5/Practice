#include <stdio.h>

void somefunction(int * a){
  printf("%d\n", *a);
}

int main(){ 
  int a = 4;
  somefunction(&(a++));
  printf("%d\n", a);

  return 0;
}
