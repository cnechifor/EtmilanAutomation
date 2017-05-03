using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects
{
    public class Login : BasePage<Login>
    {
        [LoadElement]
        [FindsBy(How = How.Name, Using = "Username")]
        private IWebElement usernameInput { get; set; }

        [LoadElement]
        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement passwordInput { get; set; }

        [LoadElement]
        [FindsBy (How = How.Name, Using = "Logon")]
        private IWebElement logonButton { get; set; }

        public IWebElement dsd;

        public Home Logon()
        {
            return Logon(getUserName(), getPassword());
        }

        public Home Logon(String username, String password)
        {
            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            logonButton.Click();
            return new Home();
        }
    }
}
