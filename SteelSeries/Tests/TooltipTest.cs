using DataHelpers;
using NUnit.Framework;
using SteelSeries.Pages;

namespace SteelSeries.Tests
{
    class TooltipTest : BaseTest
    {

        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.QckPrismCloth))]
        public void tooltipTest(string product, string extraInfo)
        {
            var mainPage = new MainPage(Browser);
            var productPage = new ProductPage(Browser);

            mainPage.OpenMainPage();
            mainPage.closeDiscountPopUp();
            mainPage.MousepadsBtnClick();
            productPage.HoverProduct(product, extraInfo);
            productPage.FindXLPreviewIcon(product, extraInfo);
            Assert.IsTrue(productPage.GetXLPreviewIcon().Displayed);
        }
    }
}
