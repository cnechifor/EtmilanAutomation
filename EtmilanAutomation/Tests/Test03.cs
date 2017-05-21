using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.PageObjects;
using EtmilanAutomation.PageObjects.find;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.Tests
{
    [TestFixture]
    class Test03 : TestBase
    {
        [Test]
        public void Test03ForReserveRecoveryValue()
        {
            //Step 1 :  Login (as Insurer) to the following URL: ti6.etmilan.com
            step.No("Step1");
            Login loginPage = new Login();
            Home home = loginPage.Logon("btronixSupplier.user", "Adjuno1!");


            //Step 2 :  Select "_Feature Test Supplier V14" from dropdown in Quick Search box and click run
            step.No("Step2");
            QuicklySearchResults results = home.OnQuickSearch().SelectSupplierAndRun("_Feature Test Supplier V14");

            //Step 3: In Claim Number Column Search for btronix and select
            step.No("Step3");
            InsuranceInstructionPlan plan = results.ClickOnCellOnColumn("Claim Number", "btronixtestclaim998");

            //Step 4 : Scroll down to and click on Reserve and Recovery
            step.No("Step4");
            ReserveAndRecovery reserve = plan.ClickOnEvent("Reserve and Recovery");

            //Step 5 : Click Apply at the top of the screen
            step.No("Step5");
            reserve.ClickApply();

            //Step 6 :  Update values 
            //Step 7 : Click Apply
            step.No("Step6-7");
            plan = reserve.SetIndemnityAndFeeAndApply("35000", "250");

            //Step 8 : Validate if fields have been updated wit the correct value
            step.No("Step8");
            String indemnityActualValue = plan.getIndemnityReserve();
            Assert.AreEqual("35000.00", indemnityActualValue, "Check Indemnity values are equal");

            String feeActualValue = plan.getFeeReserve();
            Assert.AreEqual("250.00", feeActualValue, "Check Fee values are equal");


        }
    }

}