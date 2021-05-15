using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RangeOfDates
{
    class Program
    {

        public static string DisplayDateRange(string date1, string date2)
        {
            string response;
            try
            {

                //validation of date with culture info
                DateTime dt1 = DateTime.ParseExact(date1, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime dt2 = DateTime.ParseExact(date2, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if (dt2 < dt1) //corectness of the order of dates
                {
                    response = "Wrong order of dates";
                }
                else
                {
                    if (dt1.Year == dt2.Year && dt1.Month == dt2.Month)
                    {
                        response = dt1.Day.ToString("00") + "-" + dt2.Day.ToString("00") + "." + dt1.Month.ToString("00") + "." + dt1.Year.ToString("00");
                    }
                    else if (dt1.Year == dt2.Year)
                    {
                        response = dt1.Day.ToString("00") + "." + dt1.Month.ToString("00") + "-" + dt2.Day.ToString("00") + "." + dt2.Month.ToString("00") + "." + dt2.Year.ToString("00");
                    }
                    else
                    {
                        response = dt1.Date.ToString("dd.MM.yyyy") + "-" + dt2.Date.ToString("dd.MM.yyyy");
                    }
                }

            }
            catch (FormatException)
            {
                response = "Wrong input format";
            }
            return response;
        }
        static void Main(string[] args)
        {
            try
            {
                string date1 = args[0];
                string date2 = args[1];
                Console.WriteLine(DisplayDateRange(date1, date2));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error! Enter dates");
            }
        }
    }

    [TestClass]
    public class UnitTestsClass
    {


        [TestMethod]
        public void TestMethod1()
        {
            string result = Program.DisplayDateRange("01.01.2017", "05.01.2017");

            StringAssert.Contains("01-05.01.2017", result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string result = Program.DisplayDateRange("01.01.2017", "05.02.2017");

            StringAssert.Contains("01.01-05.02.2017", result);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string result = Program.DisplayDateRange("01.01.2016", "05.01.2017");

            StringAssert.Contains("01.01.2016-05.01.2017", result);

        }

        [TestMethod]
        public void TestMethod4()
        {
            string result = Program.DisplayDateRange("01.01.2018", "05.01.2017");

            StringAssert.Contains("Wrong order of dates", result);

        }

        [TestMethod]
        public void TestMethod5()
        {
            string result = Program.DisplayDateRange("01/01/2017", "05.01.2017");

            StringAssert.Contains("Wrong input format", result);

        }

        [TestMethod]
        public void TestMethod6()
        {
            string result = Program.DisplayDateRange("01.01.2017", "05/01/2017");

            StringAssert.Contains("Wrong input format", result);

        }


    }
}
