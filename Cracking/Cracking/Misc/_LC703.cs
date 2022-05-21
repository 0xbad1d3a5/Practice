using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

    Implement KthLargest class:

    KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
    int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.
 */
namespace Cracking.Misc
{
    class LC703
    {
        /*
            - Use a min-heap, allowing for the checking of the smallest number
            - If the heap size grows to be bigger than K, remove the smallest number,
              ensuring that the smallest number will always be the Kth largest
        */
        public class KthLargest {

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int kLargest;

            public KthLargest(int k, int[] nums) {
                kLargest = k;

                foreach (int i in nums)
                {
                    addToPriorityQueue(i);
                }
            }
            
            public int Add(int val) {

                addToPriorityQueue(val);

                return pq.Peek();
            }

            private void addToPriorityQueue(int i)
            {
                pq.Enqueue(i, i);

                if (pq.Count > kLargest)
                {
                    pq.Dequeue();
                }
            }
        }
    }

    [TestClass]
    public class Tests_LC703
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
