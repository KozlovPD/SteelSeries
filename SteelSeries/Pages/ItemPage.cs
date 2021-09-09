using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WD;

namespace SteelSeries.Pages
{
    public class ItemPage : BasePage
    {
        private IWebElement PlayVideoButton => Browser.GetElement(By.XPath("//button[contains(@class, 'ytp-play-button')]"));
        private IWebElement WatchProdcuctFilmButton => Browser.GetElement(By.XPath("//a[contains(text(), 'Watch product film')]"));
        private IWebElement YoutubeFrame => Browser.GetElement(By.XPath("//iframe[@class = 'mfp-iframe']"));
        private IWebElement YoutubeVideo => Browser.GetElement(By.XPath("//div[@class = 'html5-video-container']/video"));
        private IWebElement YoutubeVideoInPlayingMode => Browser.GetElement(By.XPath("//div[contains(@class, 'playing-mode')]//video"));

        public ItemPage(Browser browser) : base(browser)
        {
        }

        public void WatchProductFilmButtonClick()
        {
            Browser.Click(WatchProdcuctFilmButton);
        }
        public void PlayAndVerifyVideo()
        {
            Browser.SwitchToFrame(YoutubeFrame);
            Browser.Click(PlayVideoButton);
            Assert.IsTrue(YoutubeVideoInPlayingMode.Displayed);
        }
    }
}