using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace EtmilanAutomation.PageObjects
{

    public class XMLSubmissionTool : BasePage<XMLSubmissionTool>
    {
        [LoadElement]
        [FindsBy (How = How.Id, Using = "XMLSubmissionTool_XMLMessage")]
        private IWebElement xmlMessageTextarea { get; set; }

        [LoadElement]
        [FindsBy(How = How.Id, Using = "extId_XMLSubmissionTool_SampleMessages-inputEl")]
        private IWebElement xmlInput { get; set; }

        [LoadElement]
        [FindsBy(How = How.Id, Using = "OptionsBarSubmitButton")]
        private IWebElement applybutton { get; set; }

        [FindsBy(How = How.Id, Using = "XMLSubmissionTool_Result")]
        private IWebElement xmlResultTextarea { get; set; }

        private String xmlMessageContent;

        public void SelectMessageTemplate(String value)
        {
            xmlInput.SendKeys(value);
            Util.Wait(2);
            IWebElement item = browser.GetBrowser().FindElement(By.CssSelector("ul.x-list-plain li.x-boundlist-item"));
            item.Click();
        }

        public void ModifyXMLNode(String tag, String value, int type)
        {
            XMLValueManagement s = new XMLValueManagement(xmlMessageContent);
            xmlMessageContent = s.ModifyElement(tag, value, type);
        }

        public void ModifyXMLNode(String tag, int value, int type)
        {
            XMLValueManagement s = new XMLValueManagement(xmlMessageContent);
            xmlMessageContent = s.ModifyElement(tag, value, type);
        }

        public void PasteXMLMessage()
        {
            xmlMessageTextarea.Click();
            xmlMessageTextarea.Clear();

            Thread thread = new Thread(() => Clipboard.SetText(xmlMessageContent));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();

            Actions paste = new Actions(browser.GetBrowser());
            paste.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control);
            paste.Perform();
        }

        public void ApplyXMLMessage()
        {
            applybutton.Click();
        }

        public Boolean ValidateResult()
        {
            String xmlMessageResult =  xmlResultTextarea.GetAttribute("value");
            XMLDataManagement xmlData = new XMLDataManagement(xmlMessageResult);
            String result = xmlData.GetNodeValue("Detail");

            if (result.Equals("OK"))
                return true;
            else
                return false;
        }

        public void SetXmlMessageContent()
        {
            xmlMessageContent = xmlMessageTextarea.GetAttribute("value");
        }


        public void ModifyXMLMessageAndApply(String messageId)
        {
            SetXmlMessageContent();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlMessageContent);
            XmlNode xmlNode =  xmlDoc.SelectSingleNode("/Message/MessageID");
            xmlNode.InnerText = messageId;

            xmlMessageContent = xmlDoc.OuterXml;
            xmlMessageTextarea.Click();
            xmlMessageTextarea.Clear();

            Thread thread = new Thread(() => Clipboard.SetText(xmlMessageContent));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();

            Actions paste = new Actions(browser.GetBrowser());
            paste.KeyDown(OpenQA.Selenium.Keys.Control).SendKeys("v").KeyUp(OpenQA.Selenium.Keys.Control);
            paste.Perform();
            applybutton.Click();
        }

    }
}
