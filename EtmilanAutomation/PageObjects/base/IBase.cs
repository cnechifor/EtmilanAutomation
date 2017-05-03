using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtmilanAutomation.PageObjects
{
    interface IBase<T>
    {
        T Get();
    }
}
