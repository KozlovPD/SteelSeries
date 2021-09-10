using NUnit.Framework;
using SteelSeries.Pages;
using System;

namespace SteelSeries.Tests
{
    [TestFixture]
    class SortingTest : BaseTest
    {
        [TestCase("Rival 650 Wireless")]
        public void sortingTest(String product)
        {
            var mainPage = new MainPage(Browser);
            var productPage = new ProductPage(Browser);

            mainPage.OpenMainPage();
            mainPage.miceBtnClick();
            mainPage.closeDiscountPopUp();
            mainPage.miceBtnClick();
            mainPage.wirelessMiceBtnClick();
            productPage.FingertipCheckBoxClick();
            Assert.IsFalse(productPage.VerifyProductIsNotDisplayed(product));
            int initProductAmount = productPage.getProductsAmount();
            productPage.SortButtonClick();
            productPage.LowToHighSortButtonClick();
            Assert.AreEqual(productPage.getCurrentAndSortedPrices().Item1, productPage.getCurrentAndSortedPrices().Item2);
            productPage.WirelessFilterCrossButtonClick();
            Assert.IsTrue(initProductAmount < productPage.getProductsAmount());
            Assert.AreEqual(productPage.getCurrentAndSortedPrices().Item1, productPage.getCurrentAndSortedPrices().Item2);
            Assert.IsTrue(productPage.getLowToHighSortButton().Selected);
        }
    }
}
