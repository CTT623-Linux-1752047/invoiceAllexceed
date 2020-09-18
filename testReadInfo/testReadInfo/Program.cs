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
            
            Seller A = new Seller();
            A.getInfoFromPath(path, namespaceManager);
            Console.WriteLine(A.SellerTaxCode);

            Buyer B = new Buyer();
            B.getInfoFromPath(path, namespaceManager);
            //Console.WriteLine(B.PaymentMethod);

            
        }
    }
}
