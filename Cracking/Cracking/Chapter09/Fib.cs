using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Compute the nth fib number
 * 
 * 0, 1, 1, 2, 3, 5, 8, 13
 */
namespace Cracking.Chapter09
{
    class Fib
    {
        public static int fib(int i)
        {
            if (i == 1)
            {
                return 0;
            }
            if (i == 2)
            {
                return 1;
            }
            return fib(i - 1) + fib(i - 2);
        }

        public static int fibWithDp(int i, Dictionary<int, int> cache)
        {
            return 0;
        }
    }

    [TestClass]
    public class Tests_11_Fib
    {
        [TestMethod]
        public void Test1(){
            Assert.AreEqual(1, Fib.fib(3));
            Assert.AreEqual(2, Fib.fib(4));
            Assert.AreEqual(3, Fib.fib(5));
            Assert.AreEqual(5, Fib.fib(6));
        }
    }
}
