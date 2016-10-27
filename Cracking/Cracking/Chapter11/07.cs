using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * A circus is designing a tower routine consisting of people standing atop one
 * another's shoulders. For practical and aesthetic reasons, each person must be
 * both shorter and lighter than the person below him or her. Given the heights
 * and weights of each person in the circus, write a method to compute the largest
 * possible number of people in such a tower.
 * 
 * EXAMPLE:
 * 
 * Input (ht, wt): (65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110)
 * 
 * Output: The longest tower is length 6 and includes from top to bottom:
 *         (56, 90) (60, 95) (65, 100) (68, 110) (70, 150) (75, 190)
 */
namespace Cracking.Chapter11
{
    class Person
    {
        public int Height { get; private set; }
        public int Weight { get; private set; }

        public Person(int height, int weight)
        {
            Height = height;
            Weight = weight;
        }
    }

    class _07
    {
        /*
         * Sort the list, then find the longest increasing subsequence based on the weight.
         */
        public static List<Person> tallestTower(List<Person> list)
        {
            list = list.OrderBy(x => x.Height).ToList();
            return longestIncreasingSubsequenceWeight(list);
        }

        /*
         * Finding the longest increasing subsequence is significant because we don't *know* who is the *best* person to be on top.
         * We can't assume the shortest person who weighs the least will be the best person to be on top of the tower. Because a
         * better answer may come later:
         * 
         * For example: (1, 20) (2, 30) (3, 40) (4, 20) (5, 30) (6, 40) (7, 50) (8, 60)
         * In this case, we get 2 equal answers being:
         * (1, 20) (2, 30) (3, 40) (7, 50) (8, 60)
         * (4, 20) (5, 30) (6, 40) (7, 50) (8, 60)
         * But see how easily it could have just been (4, 10) (5, 20) (6, 30) (7, 40) (8, 50) if we use those numbers instead.
         * 
         * We find the longest increasing subsequence by recursively asking what's the longest subsequence possible that ends at the
         * current index's value. It is possible to use dynamic programming to speed this up.
         */
        public static List<Person> longestIncreasingSubsequenceWeight(List<Person> list)
        {
            List<Person>[] solutions = new List<Person>[list.Count];
            longestIncreasingSubsequenceWeight(list, solutions, 0);

            List<Person> longestSolution = new List<Person>();
            for (int i = 0; i < solutions.Length; i++)
            {
                if (solutions[i].Count > longestSolution.Count)
                {
                    longestSolution = solutions[i];
                }
            }

            return longestSolution;
        }

        public static void longestIncreasingSubsequenceWeight(List<Person> list, List<Person>[] solutions, int index)
        {
            if (index >= list.Count)
            {
                return;
            }

            List<Person> longestValidSubsequence = new List<Person>();
            for (int i = 0; i < index; i++)
            {
                if (solutions[i].LastOrDefault().Weight < list[index].Weight)
                {
                    longestValidSubsequence = solutions[i].GetRange(0, solutions[i].Count);
                }
            }

            longestValidSubsequence.Add(list[index]);
            solutions[index] = longestValidSubsequence;

            longestIncreasingSubsequenceWeight(list, solutions, index + 1);
        }
    }

    [TestClass]
    public class Tests_11_07
    {
        [TestMethod]
        public void Test()
        {
            Person person1 = new Person(65, 100);
            Person person2 = new Person(70, 150);
            Person person3 = new Person(56, 90);
            Person person4 = new Person(75, 190);
            Person person5 = new Person(60, 95);
            Person person6 = new Person(68, 110);
            List<Person> list = new List<Person> {person1, person2, person3, person4, person5, person6};

            var result = _07.tallestTower(list);
            Assert.IsTrue(result.SequenceEqual(new List<Person> { person3, person5, person1, person6, person2, person4 }));
        }

        [TestMethod]
        public void Test1()
        {
            Person person1 = new Person(65, 200);
            Person person2 = new Person(70, 150);
            Person person3 = new Person(56, 90);
            Person person4 = new Person(75, 190);
            Person person5 = new Person(60, 95);
            Person person6 = new Person(68, 110);
            List<Person> list = new List<Person> { person1, person2, person3, person4, person5, person6 };

            var result = _07.tallestTower(list);
            Assert.IsTrue(result.SequenceEqual(new List<Person> { person3, person5, person6, person2, person4 }));
        }

        [TestMethod]
        public void TestLongestSubsequence()
        {
            Person person1 = new Person(1, 20);
            Person person2 = new Person(2, 30);
            Person person3 = new Person(3, 40);
            Person person4 = new Person(4, 10);
            Person person5 = new Person(5, 20);
            Person person6 = new Person(6, 30);
            Person person7 = new Person(7, 40);
            Person person8 = new Person(8, 50);

            List<Person> list = new List<Person> { person1, person2, person3, person4, person5, person6, person7, person8 };
            List<Person> result = _07.longestIncreasingSubsequenceWeight(list);
            Assert.IsTrue(result.SequenceEqual(new List<Person> { person4, person5, person6, person7, person8 }));
        }
    }
}
