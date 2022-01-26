using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Misc
{
    // Write a function that takes two dates as input and tell you if they are more than a month apart, less than a month apart or exactly a month apart
    public class Date
    {

        // if it's the last day of the month for both days, then they are a month apart if in the same year*
        // if month1 - month2 > 1, not really possible to be a month apart
        // if month1 - month2 == 1, case 1: exactly | case 2: less than (both of these would be based on the number of days)
        // years would need to come into play due to feburary being 28 / 29 based on the year

        // Jan 31, Feb 29 -> would not
        // Jan 30, Feb 28 / 29 --> is not a month apart

        // Feb 8 -> March 8

        public int Month { private set; get; }
        public int Day { private set; get; }
        public int Year { private set; get; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date Copy()
        {
            return new Date(Day, Month, Year);
        }

        public MonthSeparation howFarApart(Date otherDate)
        {
            Date dateCopy = Copy();

            if (Date.IsOneMonthApart(dateCopy, otherDate))
            {
                if (Date.IsLastDateOfMonth(dateCopy.Day, dateCopy.Month, dateCopy.Year) &&
                    Date.IsLastDateOfMonth(otherDate.Day, otherDate.Month, otherDate.Year))
                {
                    return MonthSeparation.IsEqual;
                }
            }

            dateCopy.addDays(Date.NumDaysInMonth(dateCopy.Month, dateCopy.Year));

            if (dateCopy.Equals(otherDate))
            {
                return MonthSeparation.IsEqual;
            }
            else if (dateCopy.isBefore(otherDate))
            {
                return MonthSeparation.IslessThan;
            }
            else
            {
                return MonthSeparation.IsMoreThan;
            }
        }

        private void addDays(int numOfDaysToAdd)
        {
            if (numOfDaysToAdd + Day <= Date.NumDaysInMonth(Month, Year))
            {
                Day = numOfDaysToAdd + Day;
            }
            else
            {
                numOfDaysToAdd = numOfDaysToAdd - (Date.NumDaysInMonth(Month, Year) - Day);

                Day = 0;
                if (Month == 12)
                {
                    Year += 1;
                }
                Month = Month == 12 ? 1 : Month + 1;
                
                addDays(numOfDaysToAdd);
            }
        }

        private bool isBefore(Date date)
        {
            if (Year < date.Year)
            {
                return true;
            }
            else if (Year == date.Year)
            {
                if (Month < date.Month)
                {
                    return true;
                }
                else if (Month == date.Month)
                {
                    return Day < date.Day;
                }
            }
            return false;
        }

        public static bool IsOneMonthApart(Date date1, Date date2)
        {
            if (Math.Abs(date1.Year - date2.Year) == 1)
            {
                return date1.Month == 1 && date2.Month == 12 || date2.Month == 12 & date1.Month == 1;
            }
            else if (Math.Abs(date1.Year - date2.Year) == 0)
            {
                return Math.Abs(date1.Month - date2.Month) == 1;
            }
            return false;
        }

        public static bool IsLastDateOfMonth(int day, int month, int year)
        {
            if (Date.NumDaysInMonth(month, year) == day)
            {
                return true;
            }
            return false;
        }

        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0;
        }

        public static int NumDaysInMonth(int month, int year){

            if (month == 1)
            {
                return 31;
            }
            else if (month == 2)
            {
                return Date.IsLeapYear(year) ? 29 : 28;
            }
            else if (month == 3)
            {
                return 31;
            }
            else if (month == 4)
            {
                return 30;
            }
            else if (month == 5)
            {
                return 31;
            }
            else if (month == 6)
            {
                return 30;
            }
            else if (month == 7)
            {
                return 31;
            }
            else if (month == 8)
            {
                return 31;
            }
            else if (month == 9)
            {
                return 30;
            }
            else if (month == 10)
            {
                return 31;
            }
            else if (month == 11)
            {
                return 30;
            }
            else if (month == 12)
            {
                return 31;
            }

            throw new Exception("Unexpected month number");
        }

        public bool Equals(Date date)
        {
            if (Year == date.Year && Month == date.Month && Day == date.Day){
                return true;
            }
            return false;
        }
    }

    public enum MonthSeparation
    {
        IslessThan,
        IsEqual,
        IsMoreThan
    }

    [TestClass]
    public class Tests_Misc_Calendar
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(MonthSeparation.IsEqual, (new Date(1, 1, 1970)).howFarApart(new Date(1, 2, 1970)));
            Assert.AreEqual(MonthSeparation.IsEqual, (new Date(1, 12, 1969)).howFarApart(new Date(1, 1, 1970)));

            Assert.AreEqual(MonthSeparation.IsEqual, (new Date(31, 1, 1999)).howFarApart(new Date(28, 2, 1999)));
            Assert.AreEqual(MonthSeparation.IsEqual, (new Date(31, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(MonthSeparation.IslessThan, (new Date(1, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
            Assert.AreEqual(MonthSeparation.IslessThan, (new Date(15, 1, 2000)).howFarApart(new Date(16, 2, 2000)));
            Assert.AreEqual(MonthSeparation.IsEqual, (new Date(29, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
            Assert.AreEqual(MonthSeparation.IslessThan, (new Date(28, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
            Assert.AreEqual(MonthSeparation.IslessThan, (new Date(1, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Assert.AreEqual(MonthSeparation.IsMoreThan, (new Date(1, 1, 2000)).howFarApart(new Date(29, 2, 2000)));
        }
    }
}
