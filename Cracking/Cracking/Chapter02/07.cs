using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting node.
 * Note that the intersection is defined based on reference, not value. That is, if the kth node of the first linked list
 * is the exact same node (by reference) as the jth node of the second linked list, then they are intersecting.
 */
namespace Cracking.Chapter02
{
    class _07
    {
       /*
        * - Can determine is there's an intersection because last node will be the same
        * - To find the intersecting node:
        *   - If linked lists are the same length, then can just traverse them at the same time
        *   - If the linked lists aren't the same length, we can simply use the previous step
        *     (determining if there's a intersection) to get the length of the nodes, and
        *     chop off from there
        */
        public static ListNode IsIntersectingLinear(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            ListNode endHeadA, endHeadB;
            int lengthA, lengthB;
            GetLastNodeAndLength(headA, out endHeadA, out lengthA);
            GetLastNodeAndLength(headB, out endHeadB, out lengthB);
            
            if (endHeadA != endHeadB)
            {
                return null;
            }

            ListNode shorter = lengthA < lengthB ? headA : headB;
            ListNode longer = lengthA < lengthB ? headB : headA;

            int numToSkipInLonger = Math.Abs(lengthA - lengthB);
            while (numToSkipInLonger > 0 && longer != null)
            {
                longer = longer.next;
                numToSkipInLonger--;
            }

            while (shorter != longer)
            {
                shorter = shorter.next;
                longer = longer.next;
            }

            return longer;
        }

        public static void GetLastNodeAndLength(ListNode node, out ListNode resultNode, out int length)
        {
            resultNode = node;
            length = 1;

            while (resultNode.next != null)
            {
                resultNode = resultNode.next;
                length++;
            }            
        }

       /*
        * NOTES:
        * - We can point the tail of one of the linked lists to its head. Then all we need to do is detect whether
        *   we have a cycle, then if we have a cycle find its beginning.
        *   Beginning finding algorithm: https://stackoverflow.com/questions/2936213/how-does-finding-a-cycle-start-node-in-a-cycle-linked-list-work
        * - Otherwise, if we cannot mutalate the list, we need to check every single node in one list with
        *   every other node in the other list.
        * - Or, use a dictionary
        */
        public static ListNode IsIntersectingCircular(ListNode headA, ListNode headB)
        {
            ListNode end = null;
            ListNode ptr = headB;
            while (ptr != null)
            {
                end = ptr;
                ptr = ptr.next;
            }

            end.next = headB;
            
            ListNode ptr1 = headA;
            ListNode ptr2 = headA;
            bool hasCycle = false;

            while (ptr1 != null && ptr2 != null)
            {
                if (ptr2.next == null)
                { 
                    break;
                }

                ptr1 = ptr1.next;
                ptr2 = ptr2.next.next;

                if (ptr1 == ptr2)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (!hasCycle)
            {
                end.next = null;
                return null;
            }

            ptr1 = headA;
            
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            end.next = null;

            return ptr1;
        }
    }

    [TestClass]
    public class Tests_02_07
    {
        [TestMethod]
        public void Test()
        {
            ListNode listA = CreateLinkedList(new List<int> { 4, 1, 8, 4, 5 });
            ListNode listB = CreateLinkedList(new List<int> { 5, 6, 1, 8, 4, 5 });

            ListNode tempA = listA;
            for (int i = 0; i < 2; i++)
            {
                tempA = tempA.next;
            }

            ListNode tempB = listB;
            for (int i = 0; i < 2; i++)
            {
                tempB = tempB.next;
            }
            tempB.next = tempA;

            _07.IsIntersectingCircular(listA, listB);
            _07.IsIntersectingLinear(listA, listB);
        }

        [TestMethod]
        public void Test1()
        {
            ListNode listA = CreateLinkedList(new List<int> { 2, 6, 4 });
            ListNode listB = CreateLinkedList(new List<int> { 1, 5 });

            _07.IsIntersectingCircular(listA, listB);
            _07.IsIntersectingLinear(listA, listB);
        }

        public ListNode CreateLinkedList(List<int> nums)
        {
            ListNode start = null;
            ListNode curr = null;

            foreach (int i in nums)
            {
                if (start == null)
                {
                    start = new ListNode(i);
                    curr = start;
                }
                else {
                    ListNode temp = new ListNode(i);
                    curr.next = temp;
                    curr = curr.next;
                }
            }

            return start;
        }
    }
}
