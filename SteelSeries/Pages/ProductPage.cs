using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        private IWebElement ExactProduct(string productName, string extraInfo) => Browser.GetElement(By.XPath($"//div[contains(@class, 'product__name') and contains (text(), '{productName}')]/ancestor::a[contains(@href, '={extraInfo}')]"));
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
                    WaitHelper.WaitFor(() => element.Displayed, 4);
                    Browser.MoveToElement(element);
                }
            }
        }

        public IWebElement GetXLPreviewIcon()
        {
            return XLPreviewIcon;

        }

        public void HoverProduct(string productName, string extraInfo)
        {
            Browser.MoveToElement(ExactProduct(productName, extraInfo));
        }

        public IWebElement getLowToHighSortButton()
        {
            return LowToHighSortButton;
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
            Browser.WaitForUrlToContain("sort=price-low-to-high");
        }


        public Tuple<List<decimal>, List<decimal>> getCurrentAndSortedPrices()
        {
            var helpers = new ConvertHelpers();
            List<decimal> PricesList = helpers.ParsePricesToDecimal(ProductsPricesList);
            List<decimal> PricesListForSorting = new List<decimal>(PricesList);
            PricesListForSorting.Sort();
            return new Tuple<List<decimal>, List<decimal>>(PricesList, PricesListForSorting);
        }

        public int getProductsAmount()
        {
            return ProductsList.Count;
        }

        public bool VerifyProductIsNotDisplayed(string product)
        {
            return Browser.CheckIfElementExists(By.XPath($"//div[contains(@class, 'product__name') and contains(text(), '{product}')]"));
        }

        public void SortButtonClick()
        {
            Browser.Click(SortButton);
        }
    }
}
