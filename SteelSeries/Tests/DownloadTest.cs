using NUnit.Framework;
using SteelSeries.Pages;
using Utils;

namespace SteelSeries.Tests
{
    class DownloadTest : BaseTest
    { 

        [TestCase]
        public void downloadTest() 
        {
            var mainPage = new MainPage(Browser);
            var enginePage = new EnginePage(Browser);
            var fileHelper = new FileHelper();
            var chromeDownloadsPage = new ChromeDownloadsPage(Browser);

            mainPage.OpenMainPage();
            mainPage.SoftwareButtonClick();
            mainPage.EngineButtonClick();
            enginePage.WindowsDownloadButtonClick();
            chromeDownloadsPage.NavigateToDownloadsPage();
             var FileName = chromeDownloadsPage.GetFileTitleAndWaitForLoadIsDone();
            Assert.IsTrue(fileHelper.CheckFileDownloaded(FileName));
            fileHelper.DeleteFileIfExists(FileName);
        }
    }
}
