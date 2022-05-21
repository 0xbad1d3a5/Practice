using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Given an array of integers stones where stones[i] is the weight of the ith stone;
   find the value of the last stone if on each turn the 2 biggest stones are smashed.
   When stones are smashed, the following applies:
   - if x == y, both are destroyed
   - if x != y, the smaller stone is destoryed, and the larger stone has the smaller's weight subtracted

   If no stones are left, return 0
 */
namespace Cracking.Misc
{
    public class MaxComparer : IComparer<int> {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    class LC1046
    {
        /*
            Use a PriorityQueue - this is because even if you sort, you need to always subtract the 2 BIGGEST stones
            
            Order matters - i.e., 
            if you have [1, 1, 8] - if you smash [1, 1] you are left with the incorrect answer 8 instead of 6
        */
        public static int LastStoneWeight(int[] stones) {
            
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(new MaxComparer());
            
            for (int i = 0; i < stones.Length; i++)
            {
                pq.Enqueue(stones[i], stones[i]);
            }

            while (pq.Count > 1)
            {
                int x = pq.Dequeue();
                int y = pq.Dequeue();
                int z = Math.Abs(x - y);
                if (z != 0)
                {
                    pq.Enqueue(z, z);
                }
            }

            if (pq.Count == 1)
            {
                return pq.Dequeue();
            }

            return 0;
        }
    }

    [TestClass]
    public class Tests_LC1046
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(1, LC1046.LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1}));
        }
    }
}
