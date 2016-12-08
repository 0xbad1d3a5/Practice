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
    /*
     * This is not the IEEE float representation, but rather binary decimals, i.e. 0.75 = 0.11 (0.1 = 0.5, 0.01 = 0.25)
     * 
     * Since converted to binary, 0.75 = 0.11
     * 
     * 0.75            = 0.110
     * 0.75 x 2 = 1.50 = 1.100
     * 1.50 x 2 = 3.00 = 11.00
     * 3.00 x 2 = 6.00 = 110.0
     * 
     * Therefore, the act of multiplying a number by 2 has the effect of shifting the decimal place to the right by 1
     * in base 2, much like how multiplying a number by 10 has the effect of shifting the decimal place right by 1 in
     * base 10.
     * 
     * Therefore, we can get the binary representation by:
     * 
     * 1) Multiply by 2, if result >= 1 (1 is 1 regardless if you're in base 2 or base 10) then the next digit is a 1,
     *    otherwise 0. If the result is >= 1 subtract by 1.
     * 2) Repeat step 1 until result is 0 or can't be represented (>32 characters).
     */
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
