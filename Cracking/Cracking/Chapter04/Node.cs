using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Chapter04
{
    class Node
    {   
        public Node Next { get; set; }
        public int Value { get; private set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
