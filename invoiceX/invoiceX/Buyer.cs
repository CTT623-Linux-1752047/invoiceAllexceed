using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Linq.Expressions;

namespace invoiceX
{
    class Buyer
    {
        private string buyerName, buyerCompany, buyerTaxCode, buyerAddress, buyerPaymentMethod, buyerAccount;
        public Buyer()
        {
            this.buyerName = null;
            this.buyerCompany = null;
            this.buyerTaxCode = null;
            this.buyerAddress = null;
            this.buyerPaymentMethod = null;
        }
        public Buyer(string name, string company, string taxCode, string address, string paymentMethod, string buyerAccount)
        {
            this.buyerName = name;
            this.buyerCompany = company;
            this.buyerTaxCode = taxCode;
            this.buyerAddress = address;
            this.buyerPaymentMethod = paymentMethod;
            this.buyerAccount = buyerAccount;
        }
        public Buyer(Buyer a)
        {
            this.buyerName = a.buyerName;
            this.buyerCompany = a.buyerCompany;
            this.buyerTaxCode = a.buyerTaxCode;
            this.buyerAddress = a.buyerAddress;
            this.buyerPaymentMethod = a.buyerPaymentMethod;
            this.buyerAccount = a.buyerAccount;
        }
        public string Name
        {
            set { this.buyerName = value; }
            get { return this.buyerName; }
        }
        public string Company
        {
            set { this.buyerCompany = value; }
            get { return this.buyerCompany; }
        }
        public string TaxCode
        {
            set { this.buyerTaxCode = value; }
            get { return this.buyerTaxCode; }
        }
        public string Address
        {
            set { this.buyerAddress = value; }
            get { return this.buyerAddress; }
        }
        public string PaymentMethod
        {
            set { this.buyerPaymentMethod = value; }
            get { return this.buyerPaymentMethod; }
        }
        public string Account
        {
            get { return this.buyerAccount; }
        }
        public XElement XPathElement(XElement root, string read, XmlNamespaceManager namespaceManager)
        {
            XElement node = null;
            try
            {
                node = root.XPathSelectElement(".//" + read, namespaceManager);
            }
            catch (Exception ex)
            {
                node = null;
            }
            return node;
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager, int typeInvoice)
        {
            XElement xelement = XElement.Load(path);
            //tao ket noi voi db 
            DataAccess data = new DataAccess();
            XElement buyerDisplayName = XPathElement(xelement, data.ReadData("Buyer", "DisplayName", typeInvoice), namespaceManager);
            XElement buyerLegalName = XPathElement(xelement, data.ReadData("Buyer", "LegalName", typeInvoice), namespaceManager);
            XElement buyerTaxCode = XPathElement(xelement, data.ReadData("Buyer", "Taxcode", typeInvoice), namespaceManager);
            XElement buyerAddressLine = XPathElement(xelement, data.ReadData("Buyer", "Address", typeInvoice), namespaceManager);
            XElement buyerPaymentMethod = XPathElement(xelement, data.ReadData("Buyer", "PaymentMethod", typeInvoice), namespaceManager);
            data.Close();
            this.buyerCompany = buyerLegalName == null ? "" : buyerLegalName.Value;
            this.buyerName = buyerDisplayName == null ? this.buyerCompany : buyerDisplayName.Value;
            this.buyerTaxCode = buyerTaxCode == null ? "" : buyerTaxCode.Value;
            this.buyerAddress = buyerAddressLine == null ? "" : buyerAddressLine.Value;
            this.buyerPaymentMethod = buyerPaymentMethod == null ? "" : buyerPaymentMethod.Value;
        }
    }
}
