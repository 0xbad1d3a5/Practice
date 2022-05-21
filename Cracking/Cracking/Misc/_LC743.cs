using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, and wi is the time it takes for a signal to travel from source to target.

    We will send a signal from a given node k. Return the time it takes for all the n nodes to receive the signal. If it is impossible for all the n nodes to receive the signal, return -1.
 */
namespace Cracking.Misc
{
    class LC743
    {
        public int NetworkDelayTime(int[][] times, int n, int k) 
        {
            Dictionary<int, List<Tuple<int, int>>> adjList = new Dictionary<int, List<Tuple<int, int>>>();

            foreach (int[] t in times)
            {
                List<Tuple<int, int>> arr;
                adjList.TryGetValue(t[0], out arr);

                if (arr == null)
                {
                    adjList[t[0]] = new List<Tuple<int, int>>();
                    adjList[t[0]].Add(Tuple.Create(t[1], t[2]));
                }
                else 
                {
                    arr.Add(Tuple.Create(t[1], t[2]));
                }
            }

            return bfs(adjList, k, n);
        }

        public int bfs(Dictionary<int, List<Tuple<int, int>>> adjList, int k, int n)
        {
            if (adjList.Count == 0)
            {
                return 0;
            }

            // dict of node, time to node
            Dictionary<int, int> visitedNodes = new Dictionary<int, int>();
            
            // queue of node, time to node
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(Tuple.Create(k, 0));

            while (queue.Count > 0)
            {               
                Tuple<int, int> dq = queue.Dequeue();

                if (visitedNodes.ContainsKey(dq.Item1))
                {
                    if (visitedNodes[dq.Item1] > dq.Item2)
                    {
                        visitedNodes[dq.Item1] = dq.Item2;
                    }
                    else
                    {
                        continue;
                    }
                }
                else {
                    visitedNodes[dq.Item1] = dq.Item2;
                }

                if (!adjList.ContainsKey(dq.Item1))
                {
                    continue;
                }

                List<Tuple<int, int>> node = adjList[dq.Item1];
                node.OrderBy(x => x.Item2);

                foreach (Tuple<int, int> neighbor in node)
                {
                    queue.Enqueue(Tuple.Create(neighbor.Item1, dq.Item2 + neighbor.Item2));
                }
            }

            return visitedNodes.Count == n ? visitedNodes.Values.Max() : -1;
        }
    }

    [TestClass]
    public class Tests_LC743
    {
        [TestMethod]
        public void Test()
        {
            LC743 test = new LC743();
            int[][] arr = new int[3][];
            arr[0] = new int[] {2, 1, 1};
            arr[1] = new int[] {2, 3, 1};
            arr[2] = new int[] {3, 4, 1};
            var a = test.NetworkDelayTime(arr, 4, 2);
        }

        [TestMethod]
        public void Test1()
        {
            LC743 test = new LC743();
            int[][] arr = new int[2][];
            arr[0] = new int[] {1, 2, 1};
            arr[1] = new int[] {2, 1, 3};
            var a = test.NetworkDelayTime(arr, 2, 2);
        }

        [TestMethod]
        public void Test2()
        {
            LC743 test = new LC743();
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 2, 1};
            arr[1] = new int[] {2, 3, 2};
            arr[2] = new int[] {1, 3, 2};
            var a = test.NetworkDelayTime(arr, 3, 1);
        }

        [TestMethod]
        public void Test3()
        {
            LC743 test = new LC743();
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 2, 1};
            arr[1] = new int[] {2, 3, 2};
            arr[2] = new int[] {1, 3, 4};
            var a = test.NetworkDelayTime(arr, 3, 1);
        }

        [TestMethod]
        public void Test4()
        {
            LC743 test = new LC743();
            int[][] arr = new int[1][];
            arr[0] = new int[] {1, 2, 1};
            var a = test.NetworkDelayTime(arr, 3, 1);
        }
    }
}
