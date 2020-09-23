using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace testReadInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
            namespaceManager.AddNamespace("aw", "http://www.w3.org/2000/09/xmldsig#");

            String path = @"C:\\Users\\toanlm\\Desktop\\C#\\Receipt\\AT_19E_6079577signed.xml";
            /*
            Invoice HoaDonTiKi = new Invoice() ;
            HoaDonTiKi.getInfoFromPath(path, namespaceManager);
            foreach(Item item in HoaDonTiKi.ListItem.Item)
            {
                Console.WriteLine(item.VATPercentage);
            }
            */
            String extensions = path.Substring(path.Length - 3, 3);
            Console.WriteLine(extensions);
        }
    }
}
