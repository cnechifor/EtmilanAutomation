using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.find
{
    public class InsuranceInstructionPlan : BasePage<InsuranceInstructionPlan>
    {
        [LoadElement]
        [FindsBy(How = How.ClassName, Using = "Track")]
        private IWebElement trackTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id^='ReserveAndRecovery'][class='ArenaPanel']")]
        private IWebElement reserveAndRecoveryPanel { get; set; }

        

        public ReserveAndRecovery ClickOnEvent(String eventName)
        {
            IWebElement eventEl = trackTable.FindElement(By.XPath("//a[@class='Event' and text()='" + eventName  + "']"));
            eventEl.Click();
            return new ReserveAndRecovery();
        }

        public String getIndemnityReserve()
        {
            IWebElement input = reserveAndRecoveryPanel.FindElement(By.CssSelector("input[name$='IndemnityReserve']"));
            return input.GetAttribute("value");
        }

        public String getFeeReserve()
        {
            IWebElement input = reserveAndRecoveryPanel.FindElement(By.CssSelector("input[name$='FeeReserve']"));
            return input.GetAttribute("value");
        }
    }
}
