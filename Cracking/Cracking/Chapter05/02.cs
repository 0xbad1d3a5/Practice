using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a real number between 0 and 1 (e.g., 0.72) that is passed in as a double,
 * print the binary representation. If the number cannot be represented accurately
 * in binary with at most 32 characters, print "ERROR."
 */
namespace Cracking.Chapter05
{
    class _02
    {
        public static String toBinaryRep(StringBuilder rep, double value)
        {
            if (value == 0)
            {
                return rep.ToString();
            }
            if (rep.Length > 34)
            {
                return "Error";
            }

            bool valGreaterEqualOne = value * 2 >= 1;
            if (valGreaterEqualOne)
            {
                rep.Append("1");
            }
            else
            {
                rep.Append("0");
            }

            return toBinaryRep(rep, valGreaterEqualOne ? value * 2 - 1 : value * 2);
        }
    }

    [TestClass]
    public class Tests_05_02
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("0.11", _02.toBinaryRep(new StringBuilder("0."), 0.75));
            Assert.AreEqual("0.", _02.toBinaryRep(new StringBuilder("0."), 0));
            Assert.AreEqual("0.011011", _02.toBinaryRep(new StringBuilder("0."), 0.421875));
            Assert.AreEqual("Error", _02.toBinaryRep(new StringBuilder("0."), 0.1));
        }
    }
}
