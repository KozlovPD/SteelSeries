using NUnit.Framework;
using SteelSeries.Pages;
using System;

namespace SteelSeries.Tests
{
    [TestFixture]
    class SortingTest : BaseTest
    {
        [Retry(1)]
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
            productPage.VerifyProductIsNotDisplayed(product);
            int initProductAmount = productPage.getProductsAmount();
            productPage.SortButtonClick();
            productPage.LowToHighSortButtonClick();
            productPage.VerifyProductsAreSortedLowToHigh();
            productPage.WirelessFilterCrossButtonClick();
            productPage.VerifyProductsAmountIsIncreaced(initProductAmount);
            productPage.VerifyProductsAreSortedLowToHigh();
            productPage.VerifyLabelIsLowToHigh();
        }
    }
}
