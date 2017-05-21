using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.find
{
    public class ReserveAndRecovery : BasePage<ReserveAndRecovery>
    {
        [LoadElement]
        [FindsBy(How = How.Id, Using = "OptionsBarSubmitButton")]
        private IWebElement submitButton { get; set; }

        [FindsBy(How = How.Id, Using = "ReserveAndRecovery_IndemnityReserve")]
        private IWebElement indemnityInput { get; set; }

        [FindsBy(How = How.Id, Using = "ReserveAndRecovery_FeeReserve")]
        private IWebElement feeInput { get; set; }

        
        public ReserveAndRecovery ClickApply()
        {
            submitButton.Click();
            return this;
        }


        public InsuranceInstructionPlan SetIndemnityAndFeeAndApply(String indemnity, String fee)
        {
            indemnityInput.SendKeys(indemnity);
            feeInput.SendKeys(fee);
            submitButton.Click();
            return new InsuranceInstructionPlan();
        }
    }
}
