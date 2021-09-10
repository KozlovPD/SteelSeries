using OpenQA.Selenium;
using WD;

namespace SteelSeries.Pages
{
    class EnginePage : BasePage
    {
        private IWebElement WindowsDownloadButton => Browser.GetElement(By.XPath("//div[contains(@class, 'engine-download')]/a[contains(@href, '/windows')]"));

        public EnginePage(Browser browser) : base(browser)
        {
        }

        public void WindowsDownloadButtonClick()
        {
            Browser.Click(WindowsDownloadButton);
        }

    }
}
