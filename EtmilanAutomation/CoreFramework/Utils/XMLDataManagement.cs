using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EtmilanAutomation.CoreFramework.Utils
{
    public class XMLDataManagement
    {
        private XmlDocument xmlDoc;

        private XmlDocument GetXMLInstance(String str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (str != null)
            {
                xmlDoc.LoadXml(str);
            }
            return xmlDoc;
        }

        public String ModifyNode(String str, String path, String valueNode)
        {
            GetXMLInstance(str);
            XmlNode xmlNode = xmlDoc.SelectSingleNode(path);
            if (xmlNode != null)
            {
                xmlNode.InnerText = valueNode; // Set to new value.
            }
            return xmlDoc.OuterXml;
        }

        public String ModifyAttribute(String str, String path, String valueAttr)
        {
            GetXMLInstance(str);
            XmlAttribute formId = (XmlAttribute)xmlDoc.SelectSingleNode(path);
            if (formId != null)
            {
                formId.Value = valueAttr; // Set to new value.
            }
            return xmlDoc.OuterXml;
        }
    }
}

