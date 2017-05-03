using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EtmilanAutomation.Tests
{
    [TestFixture]
    class Test01 : TestBase
    {
        [Test]
        public void EtmilanTest01()
        {
            //Step 01
            Login loginPage = new Login();
            loginPage.Logon();

            //Step 02
            JSMenu menu = new JSMenu();
            XMLSubmissionTool xmlSelection = (XMLSubmissionTool)menu.SelectItem("XML Submission Tool");

            //Step 03
            xmlSelection.SelectMessageTemplate("REST - Household Property First Tier Instruction with Legal Panel - 14");

            //Step 04
            String claimNumber = "btronixtestclaim1";
            xmlSelection.ModifyXMLMessageAndApply("XWWWWWWWWWWWWXXXX");

            //Step 05
            menu = new JSMenu();
            Home home = menu.ClickHome();
            QuicklySearchResults results = home.OnQuickSearch().SelectSupplierAndRun("_Feature Test Supplier V14");
            Assert.AreEqual(claimNumber, results.getCellValue("Claim Number", 1), "Check claim numbers are equal");
        }

    }
}
