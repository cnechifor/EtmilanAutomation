﻿using System;
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
    }
}
