using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace BitFlip
{
    public class FlipResult : IEquatable<FlipResult>
    {

        public int flips { private set; get; }
        public String result { private set; get; }

        public FlipResult(int flips, String result)
        {
            this.flips = flips;
            this.result = result;
        }

        public bool Equals(FlipResult other)
        {
            if (other == null)
            {
                return false;
            }
            return flips == other.flips &&
                   result == other.result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals(obj as FlipResult);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class BitFlip
    {
        private static Random rand = new Random();

        public static FlipResult Solve(String pattern)
        {
            int numZeroFlips = GetNumZeros(pattern);

            // Already done
            if (numZeroFlips == pattern.Length || numZeroFlips == 0)
            {
                return new FlipResult(0, pattern);
            }

            FlipResult smallestFlip = new FlipResult(pattern.Length, null);
            int len = pattern.Length;
            for (int i = 1; i <= len; i++)
            {
                if (pattern[i - 1] == '0')
                {
                    numZeroFlips--;
                    if (numZeroFlips < smallestFlip.flips)
                    {
                        smallestFlip = new FlipResult(numZeroFlips, GeneratePossibleSolution(len, i));
                    }
                }
                else
                {
                    numZeroFlips++;
                }
            }

            return smallestFlip;
        }

        private static int GetNumZeros(String pattern)
        {
            return pattern.Where(c => c.Equals('0')).Count();
        }

        public static IList<FlipResult> SolveNaive(String pattern)
        {
            List<String> possibleSolutions = GeneratePossibleSolutions(pattern.Length);
            IEnumerable<FlipResult> numFlipsForSolution = possibleSolutions.Select(x => new FlipResult(GetNumFlips(pattern, x), x));
            IList<FlipResult> flipResults = new List<FlipResult>();
            int smallestFlip = numFlipsForSolution.Min(x => x.flips);
            foreach (var flipRes in numFlipsForSolution)
            {
                if (flipRes.flips == smallestFlip)
                {
                    flipResults.Add(flipRes);
                }
            }
            return flipResults;
        }

        public static int GetNumFlips(String pattern, String possibleSolution)
        {
            if (pattern.Length != possibleSolution.Length)
            {
                throw new ArgumentException();
            }

            int numFlips = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != possibleSolution[i])
                {
                    numFlips++;
                }
            }
            return numFlips;
        }

        public static String GetRandomPattern(int numBits)
        {
            var maxInt = (int)Math.Pow(2, numBits) - 1;
            return Convert.ToString(rand.Next(0, maxInt), 2).PadLeft(numBits, '0');
        }

        public static String GeneratePossibleSolution(int numBits, int zeroOffset)
        {
            return new String('0', zeroOffset) + new String('1', numBits - zeroOffset);
        }

        public static List<String> GeneratePossibleSolutions(int numBits)
        {
            if (numBits < 1)
            {
                return new List<string>();
            }

            List<String> possibleSolutions = new List<string>();
            for (int i = 0; i <= numBits; i++)
            {
                int res = 0;
                for (int j = 0; j < i; j++)
                {
                    res = res << 1;
                    res |= 1;
                }
                possibleSolutions.Add(Convert.ToString(res, 2).PadLeft(numBits, '0'));
            }
            return possibleSolutions;
        }
    }

    [TestClass]
    public class Tests_Misc_Bitflip
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pattern = BitFlip.GetRandomPattern(2);
            var answer = BitFlip.SolveNaive(pattern);
            var better = BitFlip.Solve(pattern);
            CollectionAssert.Contains(new Collection<FlipResult>(answer), better,
                                        String.Format("{0}\n{1}\nMismatch", String.Join("|", answer.Select(x => x.result)), better));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //for (int i = 0; i < int.MaxValue; i++)
            for (int i = 0; i < 10000; i++)
            {
                var pattern = Convert.ToString(i, 2).PadLeft(32, '0');
                var answer = BitFlip.SolveNaive(pattern);
                var better = BitFlip.Solve(pattern);
                CollectionAssert.Contains(new Collection<FlipResult>(answer), better,
                                          String.Format("{0}\n{1}\nMismatch", String.Join("|", answer.Select(x => x.result)), better));
            }
        }
    }
}