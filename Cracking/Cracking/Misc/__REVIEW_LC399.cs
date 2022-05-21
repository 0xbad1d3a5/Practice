using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

    You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.

    Return the answers to all queries. If a single answer cannot be determined, return -1.0.

    Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.
 */
namespace Cracking.Misc
{
    class LC399
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) 
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < equations.Count; i++)
            {
                Dictionary<string, double> dict;
                if (!graph.TryGetValue(equations[i][0], out dict))
                {
                    dict = new Dictionary<string, double>();
                    graph[equations[i][0]] = dict;
                }

                dict[equations[i][1]] = values[i];

                Dictionary<string, double> rDict;
                if (!graph.TryGetValue(equations[i][1], out rDict))
                {
                    rDict = new Dictionary<string, double>();
                    graph[equations[i][1]] = rDict;
                }

                rDict[equations[i][0]] = 1.0 / values[i];
            }

            double[] results = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                results[i] = dfs(graph, queries[i][0], queries[i][1], new HashSet<string>());
            }

            return results;
        }

        private double dfs(Dictionary<string, Dictionary<string, double>> graph, string curr, string end, HashSet<string> visited)
        {
            if (!graph.ContainsKey(curr) || !graph.ContainsKey(end))
            {
                return -1.0;
            }

            if (graph.ContainsKey(curr) && graph[curr].ContainsKey(end))
            {
                return graph[curr][end];
            }

            foreach (string s in graph[curr].Keys)
            {
                if (!visited.Contains(s))
                {
                    visited.Add(s);

                    double temp = dfs(graph, s, end, visited);

                    if (temp == -1.0)
                    {
                        continue;
                    }
                    else 
                    {
                        return graph[curr][s] * temp;
                    }
                }
            }

            return -1.0;
        }
    }

    [TestClass]
    public class Tests_LC399
    {
        [TestMethod]
        public void Test()
        {            
            IList<IList<string>> equations = new List<IList<string>>();
            equations.Add(new List<string> { "a", "b" });
            equations.Add(new List<string> { "b", "c" });

            double[] values = new double[] { 2.0, 3.0 };

            IList<IList<string>> queries = new List<IList<string>>();
            queries.Add(new List<string> { "a", "c" });
            queries.Add(new List<string> { "b", "a" });
            queries.Add(new List<string> { "a", "e" });
            queries.Add(new List<string> { "a", "a" });
            queries.Add(new List<string> { "x", "x" });

            LC399 test = new LC399();

            test.CalcEquation(equations, values, queries);
        }
    }
}
