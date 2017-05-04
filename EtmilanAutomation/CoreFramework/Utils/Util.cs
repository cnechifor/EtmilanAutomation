using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EtmilanAutomation.CoreFramework.Utils
{
    public class Util
    {
        public static void Wait(int secondsToWait)
        {
            Thread.Sleep(TimeSpan.FromSeconds(secondsToWait));
        }


        public static void CompareValuesInLists(List<string> expected, List<string> actual)
        {

            string notMatch = "";
            for (int i = 0; i < expected.Count; i++)
            {
                if (!expected.Contains(actual[i]))
                    notMatch = notMatch + actual[i] + ";";
            }

            Assert.IsTrue(notMatch.Equals(""),
                          "The following values exist in list1 but don't exist in list2 :" + notMatch);

            notMatch = "";
            for (int i = 0; i < actual.Count; i++)
            {
                if (!actual.Contains(expected[i]))
                    notMatch = notMatch + expected[i] + ";";
            }

            Assert.IsTrue(notMatch.Equals(""),
                          "The following values exist in list2 but don't exist in list1 :" + notMatch);

        }
    }
}
