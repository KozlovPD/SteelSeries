using NUnit.Framework;
using SteelSeries.Pages;
using Utils;

namespace SteelSeries.Tests
{
    class DownloadTest : BaseTest
    {
        string FileName;
        FileHelper fileHelper = new FileHelper();
        [Test]
        public void downloadTest()
        {
            var mainPage = new MainPage(Browser);
            var enginePage = new EnginePage(Browser);
            var chromeDownloadsPage = new ChromeDownloadsPage(Browser);

            mainPage.OpenMainPage();
            mainPage.SoftwareButtonClick();
            mainPage.EngineButtonClick();
            enginePage.WindowsDownloadButtonClick();
            chromeDownloadsPage.NavigateToDownloadsPage();
            FileName = chromeDownloadsPage.GetFileTitleAndWaitForLoadIsDone();
            Assert.IsTrue(fileHelper.CheckFileDownloaded(FileName));
        }

        [TearDown]
        public void removeFile()
        {
            fileHelper.DeleteFileIfExists(FileName);
        }
    }
}
