using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EtmilanAutomation.CoreFramework.Utils
{
    public class Step
    {
        private IWebDriver driver;
        private String pathToScreen;
        private String testName;
        private String stepNo;

        public Step(IWebDriver webdriver)
        {
            driver = webdriver;
            pathToScreen = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Steps");
            if (!System.IO.Directory.Exists(pathToScreen))
                System.IO.Directory.CreateDirectory(pathToScreen);
        }

        public string TestName { get => testName; set => testName = value; }

        public void No(String no)
        {
            stepNo = no;
            No();
        }

        public void No()
        {
            DateTime time = DateTime.Now;
            String dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(pathToScreen, testName + "_" + stepNo + dateToday + ".jpeg"), System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}