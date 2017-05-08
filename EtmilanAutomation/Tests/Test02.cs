using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
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
            Tools tools = menu.ClickTools();
            DAAndFeeLimits feeLimits = (DAAndFeeLimits)tools.SelectTool("DA and Fee Limits");

            //Step 3: Choose "_Feature Test Supplier V14
            //Step 4 : Click on Select
            feeLimits = feeLimits.SelectSupplierAndSelect("_Feature Test Supplier V14");

            //Step 5 : Click on New
            Update updateTool = feeLimits.ClickOnNEW();

            //Step 6: Enter the following values :
            updateTool.SetSupplierName("_Feature Test Supplier V14");

            //Step 7 : In the Delegate Authority Limits box, click on Add Row 
            updateTool = updateTool.ClickAddRow();

            //Step 8 : Enter the following values in the new row :
            //a.Managing Agent : *
            //b.Workstream : Household Property
            //c.Loss Type : Accidental Damage
            //d.Supplier Type : Third - Party Administrator
            //e.DA Limit : 15,000

            updateTool.SetManagingAgent("*");
            updateTool.SetWorkstream("Household Property");
            updateTool.SetLossType("Accidental damage");
            updateTool.SetSupplierType("Third-Party Administrator");
            updateTool.SetDALimit("15000.00");

            List<String> expectedList = new List<String> { "*", "Household Property", "Accidental damage", "Third-Party Administrator", "15000.00" };

            //Step 9 : Click on Update
            updateTool.ClickOnComplete();

            //Step 10 : Confirm row has been updated correctly
            List<String> actualValues = updateTool.GetValuesWithDALimit("15000.00");
            Util.CompareValuesInLists(expectedList, actualValues);
        }
    }
}
