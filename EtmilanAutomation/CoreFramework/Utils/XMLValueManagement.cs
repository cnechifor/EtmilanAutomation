using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EtmilanAutomation.CoreFramework.Utils
{
    public class XMLValueManagement
    {
        private String str;

        public XMLValueManagement(String str)
        {
            this.str = str;
        }

        public String ModifyElement(String tag, String value, int type)
        {
            String tagL = null;
            String tagR = null;
            String tagRegExp = null;

            if (type == 1)
            {
                tagL = "<" + tag + ">";
                tagRegExp = "<\\/" + tag + ">";
                tagR = "</" + tag + ">";
                return Regex.Replace(str, tagL + ".*" + tagRegExp, tagL + value.ToString() + tagR);
            }
            if (type == 2)
            {
                tagL = "&lt;" + tag + "&gt;";
                tagR = "&lt;/" + tag + "&gt;";

                Regex x = new Regex("(" + tagL + ")(.*?)(" + tagR + ")");
                return x.Replace(str, "$1" + value + "$3");
            }
            return null;
        }

        public String ModifyElement(String tag, int value, int type)
        {
            String tagL = null;
            String tagR = null;
            String tagRegExp = null;

            if (type == 1)
            {
                tagL = "<" + tag + ">";
                tagRegExp = "<\\/" + tag + ">";
                tagR = "</" + tag + ">";
            }
            if (type == 2)
            {
                tagL = "&lt;" + tag + "&gt;";
                tagRegExp = "&lt;\\/" + tag + "&gt;";
                tagR = "&lt;/" + tag + "&gt;";
            }
            return Regex.Replace(str, tagL + ".*" + tagRegExp, tagL + value.ToString() + tagR);
        }
    }
}
