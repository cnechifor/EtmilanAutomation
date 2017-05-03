using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.tools
{
    public class Tools : BasePage<Tools>
    {
        [LoadElement]
        [FindsBy(How = How.ClassName, Using = "List")]
        protected IWebElement toolsTable { get; set; }

        public object SelectItem(String value)
        {
            return browser.GetBrowser().FindElement(By.XPath("//a[@title='" + value + "']"));

        }
    }
}
