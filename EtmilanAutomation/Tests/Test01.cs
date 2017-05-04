﻿using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace EtmilanAutomation.Tests
{
    [TestFixture]
    class Test01 : TestBase
    {
        public static int messageIDValue;
        public static int btronixtestclaim = 1;

        [Test]
        public void EtmilanTest01()
        {
            //Step 1 :  Login (as Insurer) to the following URL: ti6.etmilan.com
            Login loginPage = new Login();
            loginPage.Logon();

            //Step 2: Select Tools  XML Submission Tool
            JSMenu menu = new JSMenu();
            XMLSubmissionTool xmlSelection = (XMLSubmissionTool)menu.SelectItem("XML Submission Tool");

            //Step 3 : From Message Templates, Select REST Household Property First Tier instruction with Legal Panel – 14
            xmlSelection.SelectMessageTemplate("REST - Household Property First Tier Instruction with Legal Panel - 14");

            //Step 4: From the XML message, update the fields
            xmlSelection.SetXmlMessageContent();
            messageIDValue = Int32.Parse(ConfigurationManager.AppSettings["messageID"]) + 1;

            xmlSelection.ModifyXMLNode("MessageID", messageIDValue, 1);
            xmlSelection.ModifyXMLNode("SupplierName", "Imperial Consultants", 2);
            xmlSelection.ModifyXMLNode("SupplierType", "Third-Party Administrator", 2);
            String claimNumber = "btronixtestclaim" + btronixtestclaim;
            xmlSelection.ModifyXMLNode("ClaimNumber", claimNumber, 2);
            btronixtestclaim++;

            xmlSelection.PasteXMLMessage();

            //Step 5 : Click Apply
            xmlSelection.ApplyXMLMessage();

            //Step 6 : Validate Response <Detail> OK</Detail>
            Assert.IsTrue(xmlSelection.ValidateResult(), "The XML Message result is not OK");

            //Step 7:  Click on Home
            menu = new JSMenu();
            Home home = menu.ClickHome();

            //Step 8 : From Quick Search, select Supplier as "_Feature Test Supplier V14"
            //Step 9 : Click Run
            QuicklySearchResults results = home.OnQuickSearch().SelectSupplierAndRun("_Feature Test Supplier V14");

            //Step 10 :  Validate that 1st row is Claim Number provided in Step 4.d
            Assert.AreEqual(claimNumber, results.getCellValue("Claim Number", 1), "Check claim numbers are equal");
        }

    }
}
