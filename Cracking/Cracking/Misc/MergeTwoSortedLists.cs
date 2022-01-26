using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Misc
{
    public class Node
    {
        public Node next;
        public int val;

        public Node(int value)
        {
            val = value;
        }
    }

    public class MergeTwoLists
    {
        public static Node MergeSortedLists(Node left, Node right)
        {
            if (left == null && right == null)
            {
                return null;
            }

            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            Node result = left.val < right.val ? left : right;
            Node tail = result;

            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    Node temp = left;
                    left = left.next;
                    tail.next = temp;
                }
                else {
                    Node temp = right;
                    right = right.next;
                    tail.next = temp;
                }

                tail = tail.next == null ? tail : tail.next;
            }

            if (left != null)
            {
                tail.next = left;
            }

            if (right != null)
            {
                tail.next = right;
            }

            return result;
        }

        public static Node GetRandAscendingList(int size)
        {
            Random rand = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(rand.Next(1, 100));
            }
                
            list.Sort();

            Node result = new Node(list[0]);
            Node tail = result;

            for (int i = 1; i < size; i++)
            {
                tail.next = new Node(list[i]);
                tail = tail.next;
            }

            return result;
        }

        public static void PrintLinkedList(Node node)
        {
            while (node != null)
            {
                System.Diagnostics.Debug.Write(node.val + " ");
                node = node.next;
            }

            System.Diagnostics.Debug.WriteLine("");
        }

        public static List<int> LinkedListToList(Node node)
        {
            List<int> list = new List<int>();
            
            while (node != null)
            {
                list.Add(node.val);
                node = node.next;
            }

            return list;
        }
    }

    [TestClass]
    public class Tests_Misc_MergeTwoSortedLists{

        [TestMethod]
        public void Test()
        {
            Node left = MergeTwoLists.GetRandAscendingList(10);
            Node right = MergeTwoLists.GetRandAscendingList(14);

            MergeTwoLists.PrintLinkedList(left);
            MergeTwoLists.PrintLinkedList(right);

            Node merged = MergeTwoLists.MergeSortedLists(left, right);
            
            List<int> list = MergeTwoLists.LinkedListToList(merged);
            List<int> sortedList = list.OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void Test1()
        {
            Node left = MergeTwoLists.GetRandAscendingList(1);
            Node right = MergeTwoLists.GetRandAscendingList(1);

            MergeTwoLists.PrintLinkedList(left);
            MergeTwoLists.PrintLinkedList(right);

            Node merged = MergeTwoLists.MergeSortedLists(left, right);

            List<int> list = MergeTwoLists.LinkedListToList(merged);
            List<int> sortedList = list.OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void Test2()
        {
            Node left = MergeTwoLists.GetRandAscendingList(4);
            Node right = MergeTwoLists.GetRandAscendingList(4);

            MergeTwoLists.PrintLinkedList(left);
            MergeTwoLists.PrintLinkedList(right);

            Node merged = MergeTwoLists.MergeSortedLists(left, right);

            List<int> list = MergeTwoLists.LinkedListToList(merged);
            List<int> sortedList = list.OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }
    }
}
