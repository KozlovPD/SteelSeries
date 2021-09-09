using NUnit.Framework;
using SteelSeries.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelSeries.Tests
{
    class TooltipTest : BaseTest
    {

        [TestCase("QcK Prism Cloth", "xl")]
        public void tooltipTest(string product, string extraInfo) {
            var mainPage = new MainPage(Browser);
            var productPage = new ProductPage(Browser);

            mainPage.OpenMainPage();
            mainPage.closeDiscountPopUp();
            mainPage.MousepadsBtnClick();
            productPage.HoverProduct(product, extraInfo);
            productPage.FindXLPreviewIcon(product, extraInfo);
        }
    }
}
