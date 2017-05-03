using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.CoreFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace EtmilanAutomation.PageObjects
{
    public class Home : JSMenu, IBase<Home>
    {
        private static String URL = "&MenuId=&Action=Home";

        public Home Get()
        {
           //base.Get(URL);
           return new Home();
        }

        public QuickSeach OnQuickSearch()
        {
            return new QuickSeach();
        }
    }
}