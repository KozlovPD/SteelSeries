using NUnit.Framework;
using System.Collections.Generic;

namespace DataHelpers
{
    public class DataProvider
    {
        //TODO reimplement to extract data from JSON or any other file 
        public static IEnumerable<TestCaseData> SortingTest
        {
            get
            {
                yield return new TestCaseData("Rival 650 Wireless");
            }
        }

        public static IEnumerable<TestCaseData> FilmTest
        {
            get
            {
                yield return new TestCaseData("Arctis Pro Wireless", "white");
            }
        }

        public static IEnumerable<TestCaseData> TooltipTest
        {
            get
            {
                yield return new TestCaseData("QcK Prism Cloth", "xl");
            }
        }
    }
}
