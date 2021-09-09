using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
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
