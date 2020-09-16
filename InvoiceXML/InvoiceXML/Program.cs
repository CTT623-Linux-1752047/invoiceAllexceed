using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace InvoiceXML
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:\\Users\\toanlm\\Desktop\\C#\\0009786.xml";
            XElement xelement = XElement.Load(path);

            //var numele = xelement.Elements().Count();
            //Console.WriteLine(numele);
            //XmlReader reader = XmlReader.Create(new StringReader(path));
            //XmlNameTable nameTable = reader.NameTable;
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager( new NameTable());
            namespaceManager.AddNamespace("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
            namespaceManager.AddNamespace("aw", "http://www.w3.org/2000/09/xmldsig#");
            XElement test = xelement.XPathSelectElement("./aw:Signature/aw:SignatureValue", namespaceManager);
            Console.WriteLine(test.Value);
                        /*
            foreach (var ele in itemChild)
            {
                Console.WriteLine(ele.Name.LocalName);
            }
            */
            //IEnumerable<XElement> itemChildChild = itemChild.Elements();


        }
    }
}
