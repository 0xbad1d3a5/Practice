using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Write code to remove duplicates from an unsorted linked list.
 * FOLLOW UP
 * How would you solve this problem if a temporary buffer is not allowed?
 */
namespace Cracking.Chapter02
{
    class _01
    {
        public static void RemoveDuplicates(Node head)
        {
            Node ptr = head.next;

            while (ptr != null)
            {
                Node search = head;
                while (search != ptr)
                {
                    // found something, remove value from list
                    if (search.value == ptr.value)
                    {
                        while (search.next != ptr)
                        {
                            search = search.next;
                        }
                        search.next = ptr.next;
                        break;
                    }
                    search = search.next;
                }
                ptr = ptr.next;
            }
        }
   }

    [TestClass]
    public class Tests_02_01
    {
        [TestMethod]
        public void Test()
        {
            Random rand = new Random();

            Node head = new Node(rand.Next(0, 10));
            Node ptr = head;

            for (int i = 0; i < 10; i++)
            {
                ptr.next = new Node(rand.Next(0, 10));
                ptr = ptr.next;
            }

            head.PrintTail();
            _01.RemoveDuplicates(head);
            head.PrintTail();
        }

        [TestMethod]
        public void Test1()
        {
            Node head = new Node(2);
            Node ptr = head;
            foreach (int num in new int[] {8, 9, 2, 1, 9, 9, 5, 5, 7, 0}){
                ptr.next = new Node(num);
                ptr = ptr.next;
            }

            head.PrintTail();
            _01.RemoveDuplicates(head);
            head.PrintTail();
        }

        [TestMethod]
        public void Test2()
        {
            Node head = new Node(1);
            Node ptr = head;
            foreach (int num in new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })
            {
                ptr.next = new Node(num);
                ptr = ptr.next;
            }

            head.PrintTail();
            _01.RemoveDuplicates(head);
            head.PrintTail();
        }
    }
}
