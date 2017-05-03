using EtmilanAutomation.CoreFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects
{
    public class QuicklySearchResults : BasePage<QuicklySearchResults>
    {
        private static int headerRow = 1;

        [LoadElement]
        [FindsBy(How = How.ClassName, Using = "List")]
        private IWebElement resultsTable { get; set; }

        public String getCellValue(String columnName, int row)
        {
            int columnIndex = 0;
            ReadOnlyCollection<IWebElement> columns = resultsTable.FindElements(By.TagName("th"));
            for(int i = 0; i< columns.Count; i++)
            {
                if (columns[i].Text.Equals(columnName))
                {
                    columnIndex = i+1;
                    break;
                }
            }

            return getCellValue(columnIndex, row);
        }

        public String getCellValue(int column, int row)
        {
            row = row + headerRow;
            return resultsTable.FindElement(By.CssSelector("table.List tr:nth-child(" + row + ") td:nth-child(1)")).Text;
        }
    }
}
