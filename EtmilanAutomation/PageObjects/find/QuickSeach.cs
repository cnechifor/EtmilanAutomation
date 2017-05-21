using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects
{
    public class QuickSeach : BasePage<QuickSeach>
    {
        [LoadElement]
        [FindsBy(How = How.CssSelector, Using = "form[name='LibertyForm'][action*='Quick%20Search']")]
        private IWebElement container { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "form[name='LibertyForm'][action*='Quick%20Search'] input[id$='Supplier-inputEl']")]
        private IWebElement usernameInput { get; set; }

        [LoadElement]
        [FindsBy(How = How.CssSelector, Using = "form[name='LibertyForm'][action*='Quick%20Search'] input[name='Run']")]
        private IWebElement runButton { get; set; }

        public QuicklySearchResults SelectSupplierAndRun(String value)
        {
            usernameInput.SendKeys(value);
            Util.Wait(1);
            IWebElement item = browser.GetBrowser().FindElement(By.CssSelector("ul.x-list-plain li.x-boundlist-item"));
            item.Click();
            runButton.Click();
            return new QuicklySearchResults();
        }
        
    }
}
