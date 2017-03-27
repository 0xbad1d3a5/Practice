using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Explain what the following code does: ((n & (n-1)) == 0).
 */
namespace Cracking.Chapter05
{
    class _04
    {
        /*
         * Let's consider in what case we will get a 0, or the true case:
         *
         * 0010 & 0001
         * 0100 & 0011
         * 1000 & 0111
         * 
         * In other words, anything with the binary form "10*" will satisfy this equality.
         * We can't get a zero with any other form, so this checks if the number is a power
         * of two.
         */ 
        public static bool whatDo(int n)
        {
            return ((n & (n - 1)) == 0);
        }
    }

    [TestClass]
    public class Tests_05_04
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(_04.whatDo(2));
            Assert.IsTrue(_04.whatDo(4));
            Assert.IsTrue(_04.whatDo(8));
            Assert.IsTrue(_04.whatDo(16));
            Assert.IsTrue(_04.whatDo(32));
            Assert.IsTrue(_04.whatDo(64));

            Assert.IsFalse(_04.whatDo(3));
            Assert.IsFalse(_04.whatDo(7));
            Assert.IsFalse(_04.whatDo(458));
        }
    }
}
