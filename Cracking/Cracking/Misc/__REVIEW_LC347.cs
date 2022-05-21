using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
 */
namespace Cracking.Misc
{
    class LC347
    {
        public class MaxComparer : IComparer<int> {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        public void partition(int[] nums, int start, int end, int k)
        {
            
        }

        public int[] TopKFrequentQuicksort(int[] nums, int k)
        {
            Dictionary<int, int> numAndCount = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++){
                if (numAndCount.ContainsKey(nums[i]))
                {
                    numAndCount[nums[i]] = numAndCount[nums[i]] + 1;
                }
                else {
                    numAndCount[nums[i]] = 1;
                }
            }

            int[] result = new int[k];

            return result;
        }

        /*
            - Create a map of ints to its count
            - Sort by count or use a heap to find the k largest occurances
            - Sorting and heap in both are O(NlogN) complexity
        */
        public int[] TopKFrequentSort(int[] nums, int k) {
            
            Dictionary<int, int> numAndCount = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++){
                if (numAndCount.ContainsKey(nums[i]))
                {
                    numAndCount[nums[i]] = numAndCount[nums[i]] + 1;
                }
                else {
                    numAndCount[nums[i]] = 1;
                }
            }
            
            List<KeyValuePair<int, int>> numAndCountList = numAndCount.ToList();
            numAndCountList.Sort((p1, p2) => p2.Value - p1.Value);
            
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = numAndCountList[i].Key;
            }
            
            return result;
        }

        public int[] TopKFrequentHeap(int[] nums, int k) {
            
            Dictionary<int, int> numAndCount = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++){
                if (numAndCount.ContainsKey(nums[i]))
                {
                    numAndCount[nums[i]] = numAndCount[nums[i]] + 1;
                }
                else {
                    numAndCount[nums[i]] = 1;
                }
            }
            
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(new MaxComparer());
            
            foreach (int key in numAndCount.Keys)
            {
                pq.Enqueue(key, numAndCount[key]);
            }
            
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = pq.Dequeue();
            }
            
            return result;
        }
    }

    [TestClass]
    public class Tests_LC347
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
