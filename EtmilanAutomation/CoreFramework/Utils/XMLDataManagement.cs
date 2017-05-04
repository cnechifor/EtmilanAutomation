using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace EtmilanAutomation.CoreFramework.Utils
{
    public class XMLDataManagement
    {
        private XmlDocument xmlDoc;
        private String str1;

        public XMLDataManagement(String str)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(WebUtility.HtmlDecode(str));
            //xmlDoc.LoadXml(str);
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
           // nsmgr.AddNamespace("ab", "http://schemas.xmlsoap.org/soap/envelope/");
        }

        public void ModifyNode(String tag, String value)
        {
            xmlDoc.GetElementsByTagName(tag)[0].InnerText = value;
        }

        public void ModifyNode(String tag, int value)
        {
            xmlDoc.GetElementsByTagName(tag)[0].InnerText = value.ToString();
        }

        public void ModifyAttribute(String path, String valueAttr)
        {
            XmlAttribute formId = (XmlAttribute)xmlDoc.SelectSingleNode(path);
            if (formId != null)
            {
                formId.Value = valueAttr; // Set to new value.
            }
        }

        public String GetNodeValue(String node)
        {
            return xmlDoc.GetElementsByTagName(node)[0].InnerText;
        }

        public String Output()
        {
            return xmlDoc.OuterXml;
        }


    }
}

