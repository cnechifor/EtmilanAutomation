using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using EtmilanAutomation.CoreFramework.Utils;

namespace EtmilanAutomation.CoreFramework
{
    [TestFixture]
    public class TestBase
    {
        protected BrowserManager browser = BrowserManager.Instance;
        protected Step step;

        [OneTimeSetUp]
        public void TestFixtureSetupBase()
        {
            browser.StartBrowser();
            browser.GoTo();
            step = browser.StartStep(NUnit.Framework.TestContext.CurrentContext.Test.Name);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            browser.StopBrowser();
        }

    }
}
