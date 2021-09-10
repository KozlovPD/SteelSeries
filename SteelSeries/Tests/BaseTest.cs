using NUnit.Framework;
using WD;

namespace SteelSeries.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {

        protected Browser Browser { get; private set; }

        [SetUp]
        public void setUp()
        {
            Browser = Browser.GetBrowserInstance();
        }

        [TearDown]
        public void tearDown()
        {
            Browser.Quit();
        }
    }
}
