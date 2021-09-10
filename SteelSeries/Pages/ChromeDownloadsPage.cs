using Utils;
using WD;

namespace SteelSeries.Pages
{
    class ChromeDownloadsPage : BasePage
    {
        private const string FileName = "return document.querySelector('downloads-manager').shadowRoot.querySelector('#downloadsList').querySelector('downloads-item').shadowRoot.querySelector('#name')";

        private const string ProgressBar = "return document.querySelector('downloads-manager').shadowRoot.querySelector('#downloadsList').querySelector('downloads-item').shadowRoot.querySelector('#description').hidden";

        public ChromeDownloadsPage(Browser browser) : base(browser)
        {
        }

        public void NavigateToDownloadsPage()
        {
            Browser.CreateNewTab();
            OpenPage("chrome://downloads/");
        }


        public string GetFileTitle()
        {
            return Browser.FindShadowRootElement(FileName).Text;
        }

        public string GetFileTitleAndWaitForLoadIsDone()
        {
            WaitHelper.WaitFor(() => Browser.FindShadowRootElement(FileName).Text != null);
            string Name = Browser.FindShadowRootElement(FileName).Text;
            WaitHelper.WaitFor(() => Browser.GetAttributeOfShadowElement(ProgressBar) == true, 300);
            return Name;

        }
    }
}
