using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace EtmilanAutomation.CoreFramework
{
    [TestFixture]
    public class TestBase
    {
        protected BrowserManager browser = BrowserManager.Instance;


        [OneTimeSetUp]
        public void TestFixtureSetupBase()
        {
            browser.StartBrowser();
            browser.GoTo();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            browser.StopBrowser();
        }

    }
}
