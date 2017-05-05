using EtmilanAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EtmilanAutomation.CoreFramework
{
    public class BasePage<T>
        where T:BasePage<T>
    {
        protected BrowserManager browser = BrowserManager.Instance;
        protected BasePage()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(browser.GetBrowser(), TimeSpan.FromSeconds(30)));
            isLoaded(typeof(T));
        }

        private void waitToLoad(FindsByAttribute byAttribute)
        {
            By by = null ;
            String how = byAttribute.How.ToString();
            switch(how)
            {
                case "Name":
                    by = By.Name(byAttribute.Using);
                    break;
                case "CssSelector":
                    by = By.CssSelector(byAttribute.Using);
                    break;
                case "ClassName":
                    by = By.ClassName(byAttribute.Using);
                    break;
                case "Id":
                    by = By.Id(byAttribute.Using);
                    break;
            }

            WebDriverWait wait = new WebDriverWait(browser.GetBrowser(), TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void isLoaded(Type t)
        {

            MemberInfo[] members = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance );
            foreach (MemberInfo member in members)
            {
                if(member.GetCustomAttributes(typeof(LoadElement), true).Length > 0)
                {
                    FindsByAttribute findBy = (FindsByAttribute)member.GetCustomAttributes(typeof(FindsByAttribute), true)[0];
                    waitToLoad(findBy);
                }
            }
        }

        //protected void Get(String pageURL)
        //{
        //    String actualCookie = browser.GetBrowser().Manage().Cookies.AllCookies.First().Name;
        //    String idUser = actualCookie.Replace("ediTRACK_i_BtronixInsurer.User_", "");
         
        //    String url = ConfigurationManager.AppSettings.Get("url") + "/default.aspx?Guid=" + idUser + pageURL;

        //    // T obj = new T();
        //    //  FieldInfo aa = obj.GetType().GetField("URL", BindingFlags.Static | BindingFlags.NonPublic);
        //    browser.GoTo(url);
        //   // return new T();
        //}

        protected String getUserName()
        {
            return ConfigurationManager.AppSettings.Get("user");
        }

        protected String getPassword()
        {
            return ConfigurationManager.AppSettings.Get("password");
        }
    }


}
