using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using EtmilanAutomation.PageObjects.tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects
{
    public class JSMenu : BasePage<JSMenu>
    {

        [LoadElement]
        [FindsBy(How = How.Id, Using = "JSMenuH")]
        private IWebElement jsMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title=Tools]")]
        private IWebElement toolsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#JSMenuH a[title='Home']")]
        private IWebElement homeLink { get; set; }

        public object SelectItem(String value)
        {
            object Instance = null;
            IWebElement toolsMenu1 = browser.GetBrowser().FindElement(By.CssSelector("div#JSMenuH a[title='Tools']"));
            //Actions action = new Actions(browser.GetBrowser());
            String javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";

            int counter = 0;
            while (counter < 3)
            {
                ((IJavaScriptExecutor)browser.GetBrowser()).ExecuteScript(javaScript, toolsMenu1);
                //action.MoveToElement(toolsMenu).Perform();
                Util.Wait(1);
                try
                {
                    IWebElement item = browser.GetBrowser().FindElement(By.XPath("//div[@id='Tools']//a[text()='" + value + "']"));
                    if (item.Displayed && item.Enabled)
                    {
                        item.Click();
                        break;
                    }
                }
                catch (NoSuchElementException e)
                {

                }
                catch (ElementNotVisibleException)
                {

                }
                finally
                {
                    counter++;
                }
            }

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

        public Tools ClickTools()
        {
            toolsLink.Click();
            return new Tools();
        }

        public Home ClickHome()
        {
            homeLink.Click();
            return new Home();

        }

    }
}
