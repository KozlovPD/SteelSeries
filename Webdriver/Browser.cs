using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WD
{
    public class Browser
    {

        private Browser()
        {
            Driver = BrowserFactory.GetWebDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitTimeout);
        }

        private IWebDriver Driver { get; }
        private WebDriverWait WebDriverWait;
        private static Browser browserInstance;
        private int implicitTimeout = 3000;
        public static Browser GetBrowserInstance()
        {
            if (browserInstance == null)
            {
                browserInstance = new Browser();
            }
            return browserInstance;
        }
        public void Go(string uri)
        {
            var targetUri = new Uri(uri);
            INavigation navigation = Driver?.Navigate();
            navigation?.GoToUrl(targetUri);
        }

        #region Waiters

        public Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return Driver =>
            {
                return element.Displayed;
            };
        }

        Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return Driver =>
            {
                return !element.Displayed;
            };
        }

        Func<IWebDriver, bool> ElementIsEnabled(IWebElement element)
        {
            return Driver =>
            {
                return element.Enabled;
            };
        }

        Func<IWebDriver, bool> UrlContains(string urlFragment)
        {
            return Driver =>
            {
                return Driver.Url.Contains(urlFragment, StringComparison.InvariantCultureIgnoreCase);
            };
        }

        public bool CheckIfElementExists(By byElement)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            bool result;

            try
            {
                var element = Driver.FindElement(byElement);
                result = element.Displayed;
            }
            catch (NoSuchElementException)
            {
                result = false;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitTimeout);

            return result;
        }

        public bool CheckIfElementExists(IWebElement webElement)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            bool result;

            try
            {
                var element = webElement;
                result = element.Displayed;
            }
            catch (NoSuchElementException)
            {
                result = false;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitTimeout);

            return result;
        }


        public void WaitForElementToBeDisplayed(IWebElement element, int duration)
        {
            if (element == null) throw new Exception($"Element is not present in page DOM");

            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            WebDriverWait.Until(ElementIsVisible(element));
        }

        public void WaitForElementToBeNotDisplayed(IWebElement element, int duration)
        {
            if (element != null)
            {
                WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
                WebDriverWait.Until(ElementIsNotVisible(element));
            }
        }

        //public void WaitElementToExist(IWebElement element, int duration)
        //{
        //    WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
        //    WebDriverWait.Until(ElementExists(element));
        //}

        public void WaitForElementToBeEnabled(IWebElement element, int duration)
        {
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            WebDriverWait.Until(ElementIsEnabled(element));
        }

        public void WaitForPageBeingLoaded(int duration)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));

            wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

            /// <summary>
            /// Waiter for current browser URL to contain some pattern
            /// </summary>
            /// <param name="urlFragment">Pattern that we want to wait URL to contain</param>
            /// <param name="duration">Duration in seconds to wait for</param>
            public void WaitForUrlToContain(string urlFragment, int duration = 10)
        {
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            WebDriverWait.Until(UrlContains(urlFragment));
        }

        #endregion


        public bool GetAttributeOfShadowElement(string script)
        {
            bool root =(bool)((IJavaScriptExecutor)Driver).ExecuteScript(script);
            return root;
        }

        public IWebElement FindShadowRootElement(string script)
        {
            IWebElement root = (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript(script);
            return root;
        }
        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions?.MoveToElement(element).Build().Perform();
        }
        public void SwitchToFrame(IWebElement element) 
        {
            Driver.SwitchTo().Frame(element);
        }

        public void SwitchToDefaultFrame()
        {
            Driver.SwitchTo().DefaultContent();
        }



        public IWebElement GetElement(By by, bool noWait = false)
        {
            IWebElement element = null;

            if (noWait) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            element = Driver?.FindElement(by);

            if (noWait) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitTimeout);
            return element;
        }

        public List<IWebElement> GetElements(By by)
        {
            List<IWebElement> list = null;
            try
            {
                list = Driver?.FindElements(by).ToList();
            }
            catch (WebDriverException) { }
            return list;
        }

        public string GetElementValue(IWebElement element)
        {
            var value = element?.GetAttribute("value");
            return value;
        }

        public void Click(IWebElement element) => element?.Click();
        public void Type(IWebElement element, string inputText)
        {
            element?.Clear();
            element?.SendKeys(inputText);
        }

        public void Quit()
        {
            Driver?.Quit();
            browserInstance = null;
        }
        public void ScrollDownToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void CreateNewTab() 
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }


        class BrowserFactory
        {
            private BrowserFactory() { }

            public static IWebDriver GetWebDriver()
            {
                var options = new ChromeOptions();
                options.AddArguments(
               "start-maximized",
               "forced-maximize-mode",
               "disable-gpu",
               "disable-custom-jumplist",
               "disable-desktop-notifications",
               "disable-device-orientation",
               "disable-extensions",
               "disable-webgl",
               "no-default-browser-check",
               "dom-automation",
               "enable-navigation-tracing",
               "enable-renderer-backgrounding",
               "--test-type",
               "no-sandbox",
               "--disable-web-security"

           );
                options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                options.AddUserProfilePreference("download.prompt_for_download", "false");
                options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                options.AddUserProfilePreference("download.default_directory", "C:");
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                return new ChromeDriver(options);
                }
            }
        }
    }
