using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a directed graph, design an algorithm to find out whether there is a route
 * between two nodes.
 */
namespace Cracking.Chapter04
{
    class _02
    {
        public static bool hasPathDfs(GraphNode n, GraphNode search, HashSet<GraphNode> visited)
        {
            if (n == search)
            {
                return true;
            }

            visited.Add(n);
            foreach (GraphNode node in n.Neighbors)
            {
                if (!visited.Contains(node))
                {
                    bool result = hasPathDfs(node, search, visited);
                    if (result)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool hasPathBfs(GraphNode n, GraphNode search)
        {
            Queue<GraphNode> nodeQueue = new Queue<GraphNode>();
            HashSet<GraphNode> visited = new HashSet<GraphNode>();

            nodeQueue.Enqueue(n);
            visited.Add(n);

            while (nodeQueue.Count != 0)
            {
                GraphNode currNode = nodeQueue.Dequeue();
                if (currNode == search)
                {
                    return true;
                }
                foreach (GraphNode node in currNode.Neighbors)
                {
                    if (!visited.Contains(node))
                    {
                        nodeQueue.Enqueue(node);
                        visited.Add(node);
                    }
                }
            }

            return false;
        }
    }

    [TestClass]
    public class Tests_04_02
    {           
        GraphNode A = new GraphNode(1);
        GraphNode B = new GraphNode(2);
        GraphNode C = new GraphNode(3);
        GraphNode D = new GraphNode(4);
        GraphNode E = new GraphNode(5);
        GraphNode F = new GraphNode(6);
        GraphNode Z = new GraphNode(0);
   
       [TestInitialize]
        public void SetupGraph(){
            A.Neighbors.AddRange(new List<GraphNode> { B, C });
            B.Neighbors.AddRange(new List<GraphNode> { A, F, D, C });
            C.Neighbors.AddRange(new List<GraphNode> { A, B, D });
            D.Neighbors.AddRange(new List<GraphNode> { B, C, E });
            E.Neighbors.AddRange(new List<GraphNode> { D });
            F.Neighbors.AddRange(new List<GraphNode> { B });
        }

        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(_02.hasPathDfs(A, E, new HashSet<GraphNode>()));
            Assert.IsTrue(_02.hasPathBfs(A, E));

            Assert.IsTrue(_02.hasPathDfs(F, E, new HashSet<GraphNode>()));
            Assert.IsTrue(_02.hasPathBfs(F, E));

            Assert.IsFalse(_02.hasPathDfs(A, Z, new HashSet<GraphNode>()));
            Assert.IsFalse(_02.hasPathBfs(A, Z));
        }
    }
}
