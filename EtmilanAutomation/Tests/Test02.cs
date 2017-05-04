using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.PageObjects;
using EtmilanAutomation.PageObjects.tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EtmilanAutomation.Tests
{
    [TestFixture]
    public  class Test02 : TestBase
    {
        [Test]
        public void EtmilanTest02()
        {
            //Step 1 :  Login (as Insurer) to the following URL: ti6.etmilan.com
            Login loginPage = new Login();
            loginPage.Logon();

            //Step 2: Select Tools   DA and Fee Limits
            JSMenu menu = new JSMenu();

            //Step 3: Choose "_Feature Test Supplier V14
            //Step 4 : Click on Select
            DAAndFeeLimits feeLimits = (DAAndFeeLimits)menu.SelectItem("DA and Fee Limits");
            feeLimits = feeLimits.SelectSupplierAndSelect("_Feature Test Supplier V14");

            //Step 5 : Click on New
            Update updateTool = feeLimits.ClickOnNEW();

            //Step 6: Enter the following values :
            updateTool.SetSupplierName("_Feature Test Supplier V14");

            //Step 7 : In the Delegate Authority Limits box, click on Add Row 
            updateTool = updateTool.ClickAddRow();

            //Step 8 : Enter the following values in the new row :
            updateTool.addValue(1, "*");
            updateTool.addValue(2, "Household Property");
        }
    }
}
