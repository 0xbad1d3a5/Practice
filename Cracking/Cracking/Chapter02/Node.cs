using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Chapter02
{
    public class ElementOutOfBoundsException : Exception
    {

    }

    public class Node
    {
        public int value { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node()
        {

        }

        public Node(int value)
        {
            this.value = value;
        }

        public Node(int[] values)
        {
            if (values.Length == 0)
            {
                return;
            }

            bool first = true;
            Node ptr = null;
            foreach (int num in values)
            {
                if (first)
                {
                    value = num;
                    ptr = this;
                    first = false;
                    continue;
                }

                Node newNode = new Node(num);
                ptr.next = newNode;
                ptr = ptr.next;
            }
        }

        public void PrintTail()
        {
            Node ptr = this;
            while (ptr != null)
            {
                System.Diagnostics.Debug.Write(String.Format(" {0} ", ptr.value));
                ptr = ptr.next;
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
