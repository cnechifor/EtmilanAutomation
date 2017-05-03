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
            Login loginPage = new Login();
            loginPage.Logon();

            JSMenu menu = new JSMenu();
            DAAndFeeLimits feeLimits = (DAAndFeeLimits)menu.SelectItem("DA and Fee Limits");
            feeLimits = feeLimits.SelectSupplierAndSelect("_Feature Test Supplier V14");
            
        }
    }
}
