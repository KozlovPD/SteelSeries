using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Utils;
using WD;

namespace SteelSeries.Pages
{
    class ProductPage : BasePage
    {

        public ProductPage(Browser browser) : base(browser)
        {
        }



        private IWebElement SortButton => Browser.GetElement(By.XPath("//select[@name = 'sort']"));
        private IWebElement LowToHighSortButton => Browser.GetElement(By.XPath("//select[@name = 'sort']/option[@value='price-low-to-high']"));
        private List<IWebElement> ProductsPricesList => Browser.GetElements(By.XPath("//span[contains(@class, 'current-price')]"));


        private List<IWebElement> ProductsList => Browser.GetElements(By.XPath("//div[contains(@class, 'product__name') and not(contains(@class,'smurf'))]"));
        private IWebElement FingertipCheckbox => Browser.GetElement(By.XPath("//span[text() = 'Fingertip']"));
        private IWebElement WirelessFilterCrossButton => Browser.GetElement(By.XPath("//a[contains(text(), 'Wireless')]/span"));
        private IWebElement XLPreviewIcon => Browser.GetElement(By.XPath("//div[@class = 'tooltip__inner' and text() ='XL']/ancestor::div[@aria-hidden='false']"));
        private IWebElement ExactProduct (string productName, string extraInfo) => Browser.GetElement(By.XPath($"//div[contains(@class, 'product__name') and contains (text(), '{productName}')]/ancestor::a[contains(@href, '={extraInfo}')]"));
        private List<IWebElement> ExactProductRelatedImages(string productName, string extraInfo) => Browser.GetElements(By.XPath($"//div[contains(@class, 'product__name') and contains (text(), '{productName}')]/ancestor::a[contains(@href, 'size={extraInfo}')]/following-sibling::div[1]//li"));
        private IWebElement ArrowButton => Browser.GetElement(By.XPath("//button[@class='glide__arrow glide__arrow--right']"));

        internal void OpenProduct(string productName, string extraInfo)
        {
            Browser.Click(ExactProduct(productName, extraInfo));
        }
        public void FindXLPreviewIcon(string productName, string extraInfo)
        {
                while (!Browser.CheckIfElementExists(By.XPath("//div[@class = 'tooltip__inner' and text() ='XL']/ancestor::div[@aria-hidden='false']")))
                {
                    foreach (IWebElement element in ExactProductRelatedImages(productName, extraInfo))
                    {
                    WaitHelper.WaitFor(() => element.Displayed, 3);
                        Browser.MoveToElement(element);
                    }
                }
            Assert.IsTrue(XLPreviewIcon.Displayed);
        }

        public void HoverProduct(string productName, string extraInfo)
        {
            Browser.MoveToElement(ExactProduct(productName, extraInfo));
        }

        public void VerifyLabelIsLowToHigh()
        {
            Assert.IsTrue(LowToHighSortButton.Selected);
        }

        public void VerifyProductsAmountIsIncreaced(int initProductAmount)
        {
            Assert.IsTrue(initProductAmount < getProductsAmount());
        }

        public void WirelessFilterCrossButtonClick()
        {
            Browser.Click(WirelessFilterCrossButton);
        }

        public void FingertipCheckBoxClick()
        {
            Browser.Click(FingertipCheckbox);
        }

        public void LowToHighSortButtonClick() 
        {
            Browser.Click(LowToHighSortButton);
        }

        public void VerifyProductsAreSortedLowToHigh()
        {
            var helpers = new ConvertHelpers();
            Thread.Sleep(1000);
            List<decimal> PricesList = helpers.ParsePricesToDecimal(ProductsPricesList);
            List<decimal> PricesListForSorting = new List<decimal>(PricesList);
            PricesListForSorting.Sort();
            Assert.AreEqual(PricesList, PricesListForSorting);
        }

        public int getProductsAmount()
        {
            return ProductsList.Count;
        }

        public void VerifyProductIsNotDisplayed(string product)
        {
            Assert.IsFalse(Browser.CheckIfElementExists(By.XPath($"//div[contains(@class, 'product__name') and contains(text(), '{product}')]")));
        }

        public void SortButtonClick()
        {
            Browser.Click(SortButton);
        }
    }
}
