using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_ManagingAgent-inputEl")]
        private IWebElement managingAgentInput { get; set; }

        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_Workstream-inputEl")]
        private IWebElement workstreamInput { get; set; }

        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_LossType-inputEl")]
        private IWebElement lossTypeInput { get; set; }

        [FindsBy(How = How.Id, Using = "extId_Catalog_DAFEELimits_SupplierType-inputEl")]
        private IWebElement supplierTypeInput { get; set; }

        [FindsBy(How = How.Id, Using = "Catalog_DAFEELimits_DALimit")]
        private IWebElement daLimitInput { get; set; }


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

        public void SetManagingAgent(String Value)
        {
            managingAgentInput.SendKeys(Value);
            managingAgentInput.SendKeys(Keys.Tab);
            Util.Wait(1);
        }

        public void SetWorkstream(String Value)
        {
            workstreamInput.SendKeys(Value);
            workstreamInput.SendKeys(Keys.Tab);
            Util.Wait(1);
        }

        public void SetLossType(String Value)
        {
            lossTypeInput.SendKeys(Value);
            lossTypeInput.SendKeys(Keys.Tab);
            Util.Wait(1);
        }

        public void SetSupplierType(String Value)
        {
            supplierTypeInput.SendKeys(Value);
            supplierTypeInput.SendKeys(Keys.Tab);
            Util.Wait(1);
        }

        public void SetDALimit(String value)
        {
            daLimitInput.SendKeys(value);
            daLimitInput.SendKeys(Keys.Tab);
            Util.Wait(1);
        }

        public List<String> GetValuesWithDALimit(String value)
        {
            IWebElement row =  delegatedLimitTable.FindElement(By.XPath(".//td[contains(@class,'Catalog_DAFEELimits_DALimit')]/div[text()='" + value + "']/../.."));
            ReadOnlyCollection<IWebElement> cells = row.FindElements(By.CssSelector("td>div"));
            List<String> returnedList = new List<string>();

            foreach(IWebElement cell in cells)
            {
                returnedList.Add(cell.Text);
            }

            return returnedList;
        }
    }
}
