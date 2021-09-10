using NUnit.Framework;
using System.Collections.Generic;

namespace DataHelpers
{
    public class DataProvider
    {
        //TODO reimplement to extract data from JSON or any other file 
        public static IEnumerable<TestCaseData> Rival650Wireless
        {
            get
            {
                yield return new TestCaseData("Rival 650 Wireless");
            }
        }

        public static IEnumerable<TestCaseData> ArcticProWireless
        {
            get
            {
                yield return new TestCaseData("Arctis Pro Wireless", "white");
            }
        }

        public static IEnumerable<TestCaseData> QckPrismCloth
        {
            get
            {
                yield return new TestCaseData("QcK Prism Cloth", "xl");
            }
        }
    }
}
