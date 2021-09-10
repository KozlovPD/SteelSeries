﻿using NUnit.Framework;
using SteelSeries.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelSeries.Tests
{
    class FilmTest : BaseTest
    {

        [TestCase("Arctis Pro Wireless", "white")]
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
