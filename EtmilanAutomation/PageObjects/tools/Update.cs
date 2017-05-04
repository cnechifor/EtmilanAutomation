using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.tools
{
    public class Update : StageBar
    {
        [LoadElement]
        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_SupplierName-inputEl")]
        private IWebElement supplierName { get; set; }

        [LoadElement]
        [FindsBy(How = How.CssSelector, Using = "#extId_Catalog_DAFEELimits_GRID_DALimits table[id*='gridview']")]
        private IWebElement delegatedLimitTable { get; set; }

        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_Toolbar1_Button_AddDALimitRow-btnIconEl")]
        private IWebElement addRowfromDelegatedAuthLimits { get; set; }
        

        public void SetSupplierName(String value)
        {
            supplierName.SendKeys(value);
            Util.Wait(2);
            IWebElement item = browser.GetBrowser().FindElement(By.CssSelector("ul.x-list-plain li.x-boundlist-item"));
            item.Click();
        }

        public Update ClickAddRow()
        {
            addRowfromDelegatedAuthLimits.Click();
            return this;
        }

        public void addValue(int column, String Value)
        {
            int rows = delegatedLimitTable.FindElements(By.CssSelector("tr")).Count;
            IWebElement input = delegatedLimitTable.FindElement(By.CssSelector("tr:nth-child(" + rows + ") td:nth-child(" + column + ") > div"));
            input.SendKeys(Value);
        }
    }
}
