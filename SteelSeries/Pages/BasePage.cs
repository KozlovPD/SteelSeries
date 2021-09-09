using System;
using System.Collections.Generic;
using System.Text;
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

        public BasePage()
        {

        }

        protected void OpenPage(String url)
        {         
            Browser.Go(url);
        }
    }
}