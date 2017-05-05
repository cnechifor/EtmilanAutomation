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
        [FindsBy(How = How.CssSelector, Using = "table.List")]
        protected IWebElement toolsTable { get; set; }

        public object SelectTool(String value)
        {
            object Instance = null;
            toolsTable.FindElement(By.XPath(".//td/a[text()='" + value + "']")).Click();
            Type ClassType;
            switch (value)
            {
                case "XML Submission Tool":
                    ClassType = typeof(XMLSubmissionTool); break;//Declare the type by Class name string
                case "DA and Fee Limits":
                    ClassType = typeof(DAAndFeeLimits); break;
                default:
                    ClassType = null;
                    break;
            }
            if (ClassType != null)
            {
                Instance = Activator.CreateInstance(ClassType); //Create instance from the type
            }
            return Instance;
        }
    }
}
