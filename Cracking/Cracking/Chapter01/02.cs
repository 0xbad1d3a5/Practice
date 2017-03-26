using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Implement a function void reverse(char* str) in C or C++ which reverses a null-
 * terminated string.
 */
namespace Cracking.Chapter01
{
    /* https://leetcode.com/problems/reverse-string/
     * 
     * Fairly simple reverse implementation. We implement a swap() function that swaps two
     * character pointers. Then we have a reverseString() function where we first move the
     * pointer to the very end, and then as long as the two pointers have no intersected yet
     * as they move towards the center, swapping characters, we continuously swap the
     * characters while incrementing / decrementing the pointers.
     * 
     * If this was in a language were one does not have direct pointer access, it would simply
     * be a character array and the swap function would take 3 parameters: array, pos1, pos2.
     */
    class _02
    {
        // static void swap(char* l, char* r);
        //
        // char * reverseString(char* s) {
        //     char* opos = s;
        //     char* left = s;
        //     char* right = s;
        //
        //     while (*right != '\0'){
        //         right++;
        //     }
        //     right--;
        //
        //     while (right > left){
        //         swap(left, right);
        //         left++; right--;
        //     }
        //
        //     return opos;
        // }
        //
        // void swap(char* l, char* r){
        //     char temp = *l;
        //     *l = *r;
        //     *r = temp;
        // }
    }
}
