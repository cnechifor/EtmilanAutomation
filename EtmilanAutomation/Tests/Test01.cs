using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using EtmilanAutomation.PageObjects;
using EtmilanAutomation.PageObjects.tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace EtmilanAutomation.Tests
{
    [TestFixture]
    class Test01 : TestBase
    {
        [Test]
        public void Test01ForSupplierInstruction()
        {
            //Step 1 :  Login (as Insurer) to the following URL: ti6.etmilan.com
            step.No("Step1");
            Login loginPage = new Login();
            loginPage.Logon();


            //Step 2: Select Tools  XML Submission Tool
            step.No("Step2");
            JSMenu menu = new JSMenu();
            Tools tools = menu.ClickTools();
            XMLSubmissionTool xmlSelection = (XMLSubmissionTool)tools.SelectTool("XML Submission Tool");

            //Step 3 : From Message Templates, Select REST Household Property First Tier instruction with Legal Panel – 14
            step.No("Step3");
            xmlSelection.SelectMessageTemplate("REST - Household Property First Tier Instruction with Legal Panel - 14");


            //Step 4: From the XML message, update the fields
            step.No("Step4");
            xmlSelection.SetXmlMessageContent();

            String messageIDValue = Util.GenerateRandomMessageId();
       
            xmlSelection.ModifyXMLNode("MessageID", messageIDValue, 1);
            xmlSelection.ModifyXMLNode("SupplierName", "_Feature Test Supplier V14", 2);
            xmlSelection.ModifyXMLNode("SupplierType", "Third-Party Administrator", 2);

            String claimNumber = Util.GenerateRandomName("btronixtestclaim", 100, 999);
            xmlSelection.ModifyXMLNode("ClaimNumber", claimNumber, 2);

            xmlSelection.PasteXMLMessage();

            //Step 5 : Click Apply
            step.No("Step5");
            xmlSelection.ApplyXMLMessage();

            //Step 6 : Validate Response <Detail> OK</Detail>
            step.No("Step6");
            Assert.IsTrue(xmlSelection.ValidateResult(), "The XML Message result is not OK");

            //Step 7:  Click on Home
            step.No("Step7");
            menu = new JSMenu();
            Home home = menu.ClickHome();

            //Step 8 : From Quick Search, select Supplier as "_Feature Test Supplier V14"
            //Step 9 : Click Run
            step.No("Step8-9");
            QuicklySearchResults results = home.OnQuickSearch().SelectSupplierAndRun("_Feature Test Supplier V14");

            //Step 10 :  Validate that 1st row is Claim Number provided in Step 4.d
            step.No("Step10");
            Assert.AreEqual(claimNumber, results.GetCellValue("Claim Number", 1), "Check claim numbers are equal");
        }

    }
}
