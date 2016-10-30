using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Chapter04
{
    public class GraphNode
    {
        public List<GraphNode> Neighbors { get; private set; }

        public int Value { get; private set; }

        public GraphNode(int value)
        {
            Value = value;
            Neighbors = new List<GraphNode>();
        }
    }
}
