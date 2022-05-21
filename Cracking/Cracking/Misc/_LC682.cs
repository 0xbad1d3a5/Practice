using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    You are keeping score for a baseball game with strange rules. The game consists of several rounds, where the scores of past rounds may affect future rounds' scores.

    At the beginning of the game, you start with an empty record. You are given a list of strings ops, where ops[i] is the ith operation you must apply to the record and is one of the following:

    An integer x - Record a new score of x.
    "+" - Record a new score that is the sum of the previous two scores. It is guaranteed there will always be two previous scores.
    "D" - Record a new score that is double the previous score. It is guaranteed there will always be a previous score.
    "C" - Invalidate the previous score, removing it from the record. It is guaranteed there will always be a previous score.

    Return the sum of all the scores on the record.
 */
namespace Cracking.Misc
{
    class LC682
    {
        public static int CalPoints(string[] ops) {
            
            Stack<int> records = new Stack<int>();

            for (int i = 0; i < ops.Length; i++)
            {
                if (String.Equals("D", ops[i]))
                {
                    records.Push(records.Peek() * 2);
                }
                else if (string.Equals("C", ops[i]))
                {
                    records.Pop();
                }
                else if (String.Equals("+", ops[i]))
                {
                    int temp = records.Pop();
                    int addVal = temp + records.Peek();
                    records.Push(temp);
                    records.Push(addVal);
                }
                else
                {
                    records.Push(Int32.Parse(ops[i]));
                }
            }

            return records.Sum(x => x);
        }
    }

    [TestClass]
    public class Tests_LC682
    {
        [TestMethod]
        public void Test()
        {
            LC682.CalPoints(new string[] { "5","2","C","D","+" });
        }
    }
}
