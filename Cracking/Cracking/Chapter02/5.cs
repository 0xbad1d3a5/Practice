using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You have two numbers represented by a linked list, where each node contains a
 * single digit. The digits are stored in reverse order, such that the Ts digit is at the
 * head of the list. Write a function that adds the two numbers and returns the sum
 * as a linked list.
 * EXAMPLE
 * Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is, 617 + 295.
 * Output: 2 -> 1 -> 9.That is, 912.
 * FOLLOW UP
 * Suppose the digits are stored in forward order. Repeat the above problem.
 * EXAMPLE
 * Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).That is, 617 + 295.
 * Output: 9 -> 1 -> 2. That is, 912.
 */
namespace Cracking.Chapter02
{
    class _5
    {
        public static Node AddLinkedListReverse(Node l1, Node l2)
        {
            Node headNode = new Node(0);
            Node prevNode = headNode;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                Node newNode = new Node();

                // 3 cases
                if (l1 == null) // l1 is null, add l2 with any possible carry and go to next node
                {
                    newNode.value = l2.value + carry;
                    l2 = l2.next;
                }
                else if (l2 == null) // l2 is null, add l1 with any possible carry and go to next node
                {
                    newNode.value = l1.value + carry;
                    l1 = l1.next;
                }
                else // add both numbers and go to next node
                {
                    newNode.value = l1.value + l2.value + carry;
                    l1 = l1.next;
                    l2 = l2.next;
                }

                // if the number has carry can be calculated by dividing the value by 10 since division is rounding towards 0
                carry = newNode.value / 10;
                // value can be calculated from the modulus
                newNode.value = newNode.value % 10;

                // set the next node
                prevNode.next = newNode;
                prevNode = prevNode.next;
            }

            // perform the last carry
            if (carry == 1)
            {
                Node newNode = new Node();
                newNode.value = carry;
                prevNode.next = newNode;
            }

            return headNode.next;
        }

        // Stack can be used to reverse a linked list
        public static Node AddLinkedListForward(Node l1, Node l2)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            while (l1 != null)
            {
                stack1.Push(l1.value);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                stack2.Push(l2.value);
                l2 = l2.next;
            }

            // after reversing the list with a stack it's essentially the same concept as before
            int carry = 0;
            int sum;
            Node head = null;
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                if (stack1.Count > 0 && stack2.Count > 0)
                {
                    sum = stack1.Pop() + stack2.Pop() + carry;
                }
                else if (stack1.Count > 0)
                {
                    sum = stack1.Pop() + carry;
                }
                else
                {
                    sum = stack2.Pop() + carry;
                }

                Node newNode = new Node(sum % 10);
                carry = sum / 10;
                newNode.next = head;
                head = newNode;
            }

            if (carry == 1)
            {
                Node newNode = new Node(1);
                newNode.next = head;
                head = newNode;
            }

            return head;
        }

        public static Node RecursiveReverse(Node l1, Node l2, int carry){

            int sum = 0;

            if (l1 == null && l2 == null)
            {
                sum += carry;
                if (sum == 0)
                {
                    return null;
                }
            }
            else if (l1 == null)
            {
                sum = l2.value + carry;
            }
            else if (l2 == null)
            {
                sum = l1.value + carry;
            }
            else
            {
                sum = l1.value + l2.value + carry;
            }

            Node rest = RecursiveReverse(l1 == null ? null : l1.next, l2 == null ? null : l2.next, sum / 10);
            Node newNode = new Node(sum % 10);
            newNode.next = rest;

            return newNode;
        }
    }

    [TestClass]
    public class Tests_2_5
    {
        [TestMethod]
        public void TestReverse()
        {
            Node n1 = new Node(9);
            n1.next = new Node(9);
            n1.next.next = new Node(9);

            Node n2 = new Node(9);
            n2.next = new Node(9);
            n2.next.next = new Node(9);

            Node result = _5.AddLinkedListReverse(n1, n2);
        }

        [TestMethod]
        public void TestForward()
        {
            Node n1 = new Node(9);
            n1.next = new Node(9);
            n1.next.next = new Node(9);

            Node n2 = new Node(9);
            n2.next = new Node(9);
            n2.next.next = new Node(9);
            n2.next.next.next = new Node(9);

            Node result = _5.AddLinkedListForward(n1, n2);
        }

        [TestMethod]
        public void TestRecursive()
        {
            Node n1 = new Node(9);
            n1.next = new Node(9);
            n1.next.next = new Node(9);

            Node n2 = new Node(9);
            n2.next = new Node(9);
            n2.next.next = new Node(9);
            n2.next.next.next = new Node(9);

            Node result = _5.RecursiveReverse(n1, n2, 0);
        }
    }
}
