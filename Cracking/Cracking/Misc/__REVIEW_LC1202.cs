using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given a string s, and an array of pairs of indices in the string pairs where pairs[i] = [a, b] indicates 2 indices(0-indexed) of the string.

    You can swap the characters at any pair of indices in the given pairs any number of times.

    Return the lexicographically smallest string that s can be changed to after using the swaps.
 */
namespace Cracking.Misc
{
    class LC1202
    {
        public string SmallestStringWithSwapsTimeout(string s, IList<IList<int>> pairs)
        {
            HashSet<HashSet<int>> unions = new HashSet<HashSet<int>>();

            for (int i = 0; i < pairs.Count; i++)
            {
                HashSet<int> setToUnion = null;

                foreach (HashSet<int> union in unions)
                {
                    if (union.Contains(pairs[i][0]) || union.Contains(pairs[i][1]))
                    {
                        if (setToUnion == null)
                        {
                            setToUnion = union;
                        }
                        else 
                        {
                            setToUnion.UnionWith(union);
                            unions.Remove(union);
                        }
                    }
                }

                if (setToUnion == null)
                {
                    setToUnion = new HashSet<int>();
                    unions.Add(setToUnion);
                }

                setToUnion.Add(pairs[i][0]);
                setToUnion.Add(pairs[i][1]);
            }

            char[] result = s.ToCharArray();

            foreach (HashSet<int> set in unions)
            {
                List<int> pos = new List<int>();
                List<char> chars = new List<char>();

                foreach (int i in set)
                {
                    pos.Add(i);
                    chars.Add(s[i]);
                }
                
                chars = chars.OrderBy(x => (int)x).ToList();
                pos.Sort();

                for (int i = 0; i < pos.Count; i++)
                {
                    result[pos[i]] = chars[i];
                }
            }

            return new string(result);
        }

        public String SmallestStringWithSwaps(String s, IList<IList<int>> pairs) {
                
            UnionFind uf = new UnionFind(s.Length);

            // Iterate over the edges
            foreach (List<int> edge in pairs) {
                int source = edge[0];
                int destination = edge[1];
                
                // Perform the union of end points
                uf.union(source, destination);
            }
            
            Dictionary<int, List<int>> rootToComponent = new Dictionary<int, List<int>>();
            // Group the vertices that are in the same component
            for (int vertex = 0; vertex < s.Length; vertex++) 
            {
                int root = uf.find(vertex);
                
                // Add the vertices corresponding to the component root
                if (!rootToComponent.ContainsKey(root))
                {
                    rootToComponent[root] = new List<int>();
                }
                
                rootToComponent[root].Add(vertex);
            }
            
            // String to store the answer
            char[] smallestString = new char[s.Length];

            // Iterate over each component
            foreach (List<int> indices in rootToComponent.Values) 
            {
                // Sort the characters in the group
                List<char> characters = new List<char>();
                foreach (int index in indices) {
                    characters.Add(s[index]);
                }
                characters.Sort();
                
                // Store the sorted characters
                for (int index = 0; index < indices.Count; index++) {
                    smallestString[indices[index]] = characters[index];
                }
            }
            
            return new String(smallestString);
        }

        class UnionFind {
            private int[] root;
            private int[] rank;

            // Initialize the array root and rank
            // Each vertex is representative of itself with rank 1
            public UnionFind(int size) {
                root = new int[size];
                rank = new int[size];
                for (int i = 0; i < size; i++) {
                    root[i] = i;
                    rank[i] = 1;
                }
            }

            // Get the root of a vertex
            public int find(int x) {
                if (x == root[x]) {
                    return x;
                }
                return root[x] = find(root[x]);
            }

            // Perform the union of two components
            public void union(int x, int y) {
                int rootX = find(x);
                int rootY = find(y);
                if (rootX != rootY) {
                    if (rank[rootX] >= rank[rootY]) {
                        root[rootY] = rootX;
                        rank[rootX] += rank[rootY];
                    } else {
                        root[rootX] = rootY;
                        rank[rootY] += rank[rootX];
                    }
                }
            }
        }
    }

    [TestClass]
    public class Tests_LC1202
    {
        [TestMethod]
        public void Test()
        {
            LC1202 test = new LC1202();
            
            IList<IList<int>> testList = new List<IList<int>>();
            testList.Add(new List<int> { 0, 3 });
            testList.Add(new List<int> { 1, 2 });
            testList.Add(new List<int> { 0, 2 });

            test.SmallestStringWithSwaps("dcab", testList);
        }
    }
}
