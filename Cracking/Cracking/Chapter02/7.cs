using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Implement a function to check if a linked list is a palindrome.
 */
namespace Cracking.Chapter02
{
    class _7
    {
        public static bool CheckLinkedListPalindromeUsingStack(Node head)
        {
            Stack<int> stack = new Stack<int>();
            Node ptr = head;

            while (ptr != null)
            {
                stack.Push(ptr.value);
                ptr = ptr.next;
            }

            ptr = head;
            int numToCompare = stack.Count / 2;
            for (int i = 0; i < numToCompare; i++)
            {
                if (stack.Pop() != ptr.value)
                {
                    return false;
                }
                ptr = ptr.next;
            }

            return true;
        }

        /* 
         * For recursive implementation, first we should consider the base cases:
         * 0: obvious
         * 1: ( A ( B ) A ) - B does not need to be compared, so A goes with B.next
         * 2: ( A ( B1 B2 ) A ) - Though this doesn't seem like a base case (why not use 0)? It is.
         * The reason is that if we use 0, instead of comparing B1 B2 we will compare:
         * n = A, length = 4
         * n = B1, length = 2
         * n = B2, length = 0 -> return value is B2.next which is A
         * -> n = B1 will end up getting compared to return value B2.next A
         * 
         * The next key thing is that the input is the first half of the list, and the return value is the second half.
         * Now you can compare (due to recursive calls) the 0 with n, 1 with n-1, 2 with n-2, etc...
         * 
         * Since we use the return value to get the second half of the list, we need to wrap the return node in a class
         * with a boolean result so that we can give an answer at the end.
         */ 
        public static CheckLinkedListPalindromeRecursiveHelper CheckLinkedListPalindromeRecursive(Node n, int length)
        {
            if (length == 0 || n == null)
            {
                return new CheckLinkedListPalindromeRecursiveHelper(null, true);
            }
            if (length == 1)
            {
                return new CheckLinkedListPalindromeRecursiveHelper(n.next, true);
            }
            if (length == 2)
            {
                return new CheckLinkedListPalindromeRecursiveHelper(n.next.next, n.value == n.next.value);
            }

            CheckLinkedListPalindromeRecursiveHelper res = CheckLinkedListPalindromeRecursive(n.next, length - 2);

            if (!res.isPalindrome)
            {
                return res;
            }
            else if (n.value != res.node.value)
            {
                res.isPalindrome = false;
                return res;
            }

            res.node = res.node.next;
            return res;
        }
    }

    class CheckLinkedListPalindromeRecursiveHelper
    {
        public Node node { get; set; }
        public bool isPalindrome { get; set; }

        public CheckLinkedListPalindromeRecursiveHelper(Node node, bool isPalindrome)
        {
            this.node = node;
            this.isPalindrome = isPalindrome;
        }
    }

    [TestClass]
    public class Tests_2_7
    {
        [TestMethod]
        public void Test()
        {
            Node A = new Node(1);
            Node B = new Node(2);
            Node C = new Node(3);
            Node D = new Node(3);
            Node E = new Node(2);
            Node F = new Node(1);

            A.next = B;
            B.next = C;
            C.next = D;
            D.next = E;
            E.next = F;

            Assert.AreEqual(true, _7.CheckLinkedListPalindromeUsingStack(A));
            Assert.AreEqual(true, _7.CheckLinkedListPalindromeRecursive(A, 6).isPalindrome);
        }

        [TestMethod]
        public void Test1()
        {
            Node A = new Node(1);

            Assert.AreEqual(true, _7.CheckLinkedListPalindromeUsingStack(A));
            Assert.AreEqual(true, _7.CheckLinkedListPalindromeRecursive(A, 1).isPalindrome);
        }

        [TestMethod]
        public void Test2()
        {
            Node A = new Node(1);
            Node B = new Node(2);
            Node C = new Node(1);

            A.next = B;
            B.next = C;

            Assert.AreEqual(true, _7.CheckLinkedListPalindromeUsingStack(A));
            Assert.AreEqual(true, _7.CheckLinkedListPalindromeRecursive(A, 3).isPalindrome);
        }
    }
}
