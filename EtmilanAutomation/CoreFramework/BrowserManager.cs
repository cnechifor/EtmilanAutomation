using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace EtmilanAutomation.CoreFramework
{
    public class BrowserManager
    {
        enum BrowserType
        {
            FIREFOX,
            IE,
            CHROME,
            SAFARI,
        };
        private static ThreadLocal<IWebDriver> browserDriver = new ThreadLocal<IWebDriver>();

        private static BrowserManager instance = null;

        private BrowserType browserType;

        private String titleBeforeClick;

        private int lenSourceBeforeClick;

        private Step step;

        private BrowserManager()
        {

        }

        public static BrowserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrowserManager();
                }
                return instance;
            }
        }

        public void StartBrowser()
        {
            String profile = ConfigurationManager.AppSettings["profile"];
            browserType = (BrowserType)Enum.Parse(typeof(BrowserType), profile.ToUpper());

            browserDriver.Value = GetLocalDriver(browserType);

            EventFiringWebDriver eventDriver = new EventFiringWebDriver(browserDriver.Value);
            eventDriver.ElementClicking += new EventHandler<WebElementEventArgs>(firingDriver_ElementClicking);
            eventDriver.ElementClicked += new EventHandler<WebElementEventArgs>(firingDriver_ElementClicked);
            eventDriver.FindingElement += new EventHandler<FindElementEventArgs>(firingDriver_FindingElement);
            eventDriver.ElementValueChanged += new EventHandler<WebElementEventArgs>(firingDriver_ElementValueChanged);
            browserDriver.Value = eventDriver;

            GetBrowser().Manage().Window.Maximize();
        }

        public Step StartStep(String testName)
        {
            step = new Step(GetBrowser());
            step.TestName = testName;
            return step;
        }

        /// <summary>
        /// gets the driver for current browserManager 
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetBrowser()
        {
            return browserDriver.Value;
        }

        public void GoTo()
        {
            GetBrowser().Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("url"));
        }

        public void GoBack()
        {
            GetBrowser().Navigate().Back();
        }

        public void RefreshBrowser()
        {
            GetBrowser().Navigate().GoToUrl(GetBrowser().Url);
        }


        public void StopBrowser()
        {
            var webDriver = GetBrowser();
            webDriver.Close();
            webDriver.Quit();
        }

        public void GoTo(string url)
        {
            GetBrowser().Navigate().GoToUrl(url);
        }



        void firingDriver_ElementValueChanged(object sender, WebElementEventArgs e)
        {
        }

        private void firingDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            titleBeforeClick = GetBrowser().Title;
            lenSourceBeforeClick = GetBrowser().PageSource.Length;
            step.No();
        }

        private void firingDriver_FindingElement(object sender, FindElementEventArgs e)
        {

        }

        void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Util.Wait(1);
            int len1 = GetBrowser().PageSource.Length;

            double time = Double.Parse(ConfigurationManager.AppSettings.Get("timeToLoad"));
            WebDriverWait wait = new WebDriverWait(GetBrowser(), TimeSpan.FromSeconds(time));
            wait.Until((x) =>
            {
                return (GetBrowser().PageSource.Length != lenSourceBeforeClick);
            });
            Util.Wait(1);
        }
        private IWebDriver GetLocalDriver(BrowserType browserType)
        {
            IWebDriver browserDriver = null;
            switch (browserType)
            {
                case BrowserType.IE:
                    break;
                case BrowserType.FIREFOX:
                    browserDriver = new FirefoxDriver();
                    break;
                case BrowserType.CHROME:
                    {
                        var options = new ChromeOptions();
                        options.AddArguments("--disable-extensions");
                        options.AddArguments("--disable-infobars");
                        options.AddArguments("test-Type");
                        options.AddUserProfilePreference("credentials_enable_service", false);
                        options.AddUserProfilePreference("password_manager_enabled", false);
                        browserDriver = new ChromeDriver(options);
                        break;
                    }
                default:
                    browserDriver = new ChromeDriver();
                    break;
            }
            return browserDriver;
        }

    }
}