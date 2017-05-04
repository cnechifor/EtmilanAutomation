using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.tools
{
    public class DAAndFeeLimits: StageBar
    {
        [LoadElement]
        [FindsBy(How = How.Id, Using = "extId_ArenaQueryParams_Param_Supplier-inputEl")]
        private IWebElement supplierInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='List']//td/a[text()='NEW']")]
        private IWebElement newLink { get; set; }

        public DAAndFeeLimits SelectSupplierAndSelect(String value)
        {
            supplierInput.SendKeys(value);
            Util.Wait(2);
            IWebElement item = browser.GetBrowser().FindElement(By.CssSelector("ul.x-list-plain li.x-boundlist-item"));
            item.Click();
            selectInput.Click();
            return new DAAndFeeLimits();
        }

        public Update ClickOnNEW()
        {
            newLink.Click();
            return new Update();
        }
    }
}
