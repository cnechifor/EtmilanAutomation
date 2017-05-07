using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects.tools
{
    public class StageBar : BasePage<StageBar>
    {
        [LoadElement]
        [FindsBy(How = How.Id, Using = "OptionsBar")]
        protected IWebElement optionsBar { get; set; }

        [FindsBy(How = How.Name, Using = "Second")]
        protected IWebElement selectInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='StageLeft Present'] span")]
        protected IWebElement updateInput { get; set; }

        [FindsBy(How = How.Name, Using = "Complete")]
        protected IWebElement completeInput { get; set; }

        
        public void ClickOnComplete()
        {
            completeInput.Click();
        }
    }
}