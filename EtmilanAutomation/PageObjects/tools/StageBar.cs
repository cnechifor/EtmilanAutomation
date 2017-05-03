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
        [FindsBy(How = How.Name, Using = "Second")]
        protected IWebElement selectInput { get; set; }
    }
}