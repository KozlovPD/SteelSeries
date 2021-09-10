using DataHelpers;
using NUnit.Framework;
using SteelSeries.Pages;

namespace SteelSeries.Tests
{
    class FilmTest : BaseTest
    {

        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.FilmTest))]
        public void filmTest(string product, string extraInfo)
        {
            var mainPage = new MainPage(Browser);
            var productPage = new ProductPage(Browser);
            var openedItemPage = new OpenedItemPage(Browser);

            mainPage.OpenMainPage();
            mainPage.closeDiscountPopUp();
            mainPage.HeadsetsButtonClick();
            mainPage.PcHeadsetsButtonClick();
            productPage.OpenProduct(product, extraInfo);
            openedItemPage.WatchProductFilmButtonClick();
            openedItemPage.PlayYoutubeVideo();
            Assert.IsTrue(openedItemPage.getYoutubeVideoInPlayingMode().Displayed);
        }
    }
}
