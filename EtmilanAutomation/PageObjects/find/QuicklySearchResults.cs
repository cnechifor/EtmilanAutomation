using EtmilanAutomation.CoreFramework;
using EtmilanAutomation.PageObjects.find;
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

        public String GetCellValue(String columnName, int row)
        {
            return GetCellValue(GetColumnIndex(columnName), row);
        }

        public String GetCellValue(int column, int row)
        {
            row = row + headerRow;
            return resultsTable.FindElement(By.CssSelector("table.List tr:nth-child(" + row + ") td:nth-child(" + column  + ")")).Text;
        }

        private int GetColumnIndex(String columnName)
        {
            int columnIndex = 0;
            ReadOnlyCollection<IWebElement> columns = resultsTable.FindElements(By.CssSelector("th input"));
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].GetAttribute("value").Equals(columnName))
                {
                    columnIndex = i + 1;
                    return columnIndex;
                }
            }

            return -1;
        }

        public InsuranceInstructionPlan ClickOnCellOnColumn(String columnName, String value)
        {
            int columnIndex =  GetColumnIndex(columnName);
            IWebElement cell = resultsTable.FindElement(By.XPath(".//tr/td[" + columnIndex +"]/a[text()='" + value + "']"));
            cell.Click();
            return new InsuranceInstructionPlan();
        }
    }
}
