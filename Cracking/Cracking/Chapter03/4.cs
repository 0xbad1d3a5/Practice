using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of
 * different sizes which can slide onto any tower. The puzzle starts with disks sorted
 * in ascending order of size from top to bottom (i.e., each disk sits on top of an
 * even larger one). You have the following constraints:
 * (1) Only one disk can be moved at a time.
 * (2) A disk is slid off the top of one tower onto the next tower.
 * (3) A disk can only be placed on top of a larger disk.
 * Write a program to move the disks from the first tower to the last using stacks.
 */
namespace Cracking.Chapter03
{
    public static class _4
    {
        public static void hanoi(char[] discs, int origin, int spare, int dest)
        {
            if (discs.Length == 0)
            {
                return;
            }

            hanoi(discs.Take(discs.Length - 1).ToArray(), origin, dest, spare);

            System.Console.WriteLine(string.Format("Moving {0} from {1} to {2}", discs[discs.Length - 1], origin, dest));

            hanoi(discs.Take(discs.Length - 1).ToArray(), spare, origin, dest);
        }
    }

    public class Tower
    {
        private Stack<int> stack = new Stack<int>();

        public Tower()
        {
        }

        public Tower(Stack<int> stack)
        {
            this.stack = stack;
        }

        public void addDisc(int disc)
        {
            stack.Push(disc);
        }

        public void moveDisc(Tower dest)
        {
            dest.addDisc(stack.Pop());
        }

        public void moveDiscs(int count, Tower spare, Tower dest)
        {
            if (count == 0)
            {
                return;
            }

            moveDiscs(count - 1, dest, spare);
            moveDisc(dest);
            spare.moveDiscs(count - 1, this, dest);
        }
    }

    [TestClass]
    public class Tests_3_4
    {
        [TestMethod]
        public void Test()
        {
            _4.hanoi(new char[] { 'A', 'B', 'C' }, 1, 2, 3);
        }

        [TestMethod]
        public void Test1()
        {
            Tower t1 = new Tower(new Stack<int>(new[] {6, 5, 4, 3, 2, 1} ));
            Tower t2 = new Tower();
            Tower t3 = new Tower();

            t1.moveDiscs(4, t2, t3);
        }
    }
}
