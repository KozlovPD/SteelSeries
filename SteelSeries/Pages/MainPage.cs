using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using WD;

namespace SteelSeries.Pages
{
    class MainPage : BasePage
    {
        
        private IWebElement DiscountButton => Browser.GetElement(By.XPath("//button[text() = 'Subscribe']"));
        private IWebElement DiscountPopUpCloseButton => Browser.GetElement(By.XPath("//div[@class = 'sc-close']"));
        private IWebElement SoftwareButton => Browser.GetElement(By.XPath("//li[contains(@class, 'category')]/button[contains(text(), 'Software')]"));
        private IWebElement EngineButton => Browser.GetElement(By.XPath("//li[contains(@class, 'category')]/a[contains(@href, '/engine')]"));
        private IWebElement MiceButton => Browser.GetElement(By.XPath("//button[contains(text(), 'Mice')]"));
        private IWebElement WirelessMiceButton => Browser.GetElement(By.XPath("//ul[contains(@class, 'dropdown')]/li/a[@href= '/gaming-mice/wireless']"));
        private IWebElement LoggedInNavBar => Browser.GetElement(By.XPath("//li[contains(@class, 'logged-in')]"));

        internal void verifyUserIsLoggedIn()
        {
            Assert.IsTrue(LoggedInNavBar.Displayed);
        }

        private IWebElement MousepadsButton => Browser.GetElement(By.XPath("//li[@class = 'category-navigation__item']/a[contains(text(), 'Mousepads')]"));
        private IWebElement HeadsetsButton => Browser.GetElement(By.XPath("//button[contains(text(), 'Headsets')]"));
        private IWebElement PcHeadsetsButton => Browser.GetElement(By.XPath("//ul[contains(@class, 'dropdown')]/li/a[@href= '/gaming-headsets/pc']"));
        private IWebElement SignUpButton => Browser.GetElement(By.XPath("//a[@href='/signup']"));


        public MainPage(Browser browser) : base(browser)
        {
        }

        public void SignUpButtonClick()
        {
            Browser.Click(SignUpButton);
        }


        public void SoftwareButtonClick()
        {
            Browser.Click(SoftwareButton);
        }

        public void EngineButtonClick()
        {
            Browser.Click(EngineButton);
        }


        public void HeadsetsButtonClick()
        {
            Browser.Click(HeadsetsButton);
        }

        public void PcHeadsetsButtonClick()
        {
            Browser.Click(PcHeadsetsButton);
        }


        public void closeDiscountPopUp()
        {
            Browser.WaitForElementToBeDisplayed(DiscountButton,120);
                Browser.MoveToElement(DiscountButton);
                Browser.Click(DiscountPopUpCloseButton);
        }


        public void OpenMainPage()
        {
            OpenPage("https://steelseries.com");
        }

        public void miceBtnClick() 
        {
            Browser.WaitForElementToBeEnabled(MiceButton,5);
            Browser.Click(MiceButton);
        }

        public void MousepadsBtnClick()
        {
            Browser.WaitForElementToBeEnabled(MousepadsButton, 5);
            Browser.Click(MousepadsButton);
        }


        public void hoverMiceCategoryButton()
        {
            Browser.MoveToElement(MiceButton);
        }


        public void wirelessMiceBtnClick()
        {
            Browser.WaitForElementToBeEnabled(WirelessMiceButton,10);
            Browser.Click(WirelessMiceButton);
        }
    }
}
