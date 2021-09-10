using System;
using WD;

namespace SteelSeries.Pages
{
    public abstract class BasePage
    {
        public Browser Browser { get; set; }

        protected BasePage(Browser browser)
        {
            Browser = browser;
        }

        protected void OpenPage(String url)
        {
            Browser.Go(url);
        }
    }
}