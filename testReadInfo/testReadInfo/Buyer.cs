using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace testReadInfo
{
    class Buyer
    {
        private string buyerName, buyerCompany, buyerTaxCode, buyerAddress, buyerPaymentMethod;
        public Buyer()
        {
            this.buyerName = null;
            this.buyerCompany = null;
            this.buyerTaxCode = null;
            this.buyerAddress = null;
            this.buyerPaymentMethod = null;

        }
        public Buyer(string name, string company, string taxCode, string address, string paymentMethod) {
            this.buyerName = name;
            this.buyerCompany = company;
            this.buyerTaxCode = taxCode;
            this.buyerAddress = address;
            this.buyerPaymentMethod = paymentMethod;
        }
        public Buyer(Buyer a)
        {
            this.buyerName = a.buyerName;
            this.buyerCompany = a.buyerCompany;
            this.buyerTaxCode = a.buyerTaxCode;
            this.buyerAddress = a.buyerAddress;
            this.buyerPaymentMethod = a.buyerPaymentMethod;
        }
        public string Name
        {
            set { this.buyerName = value; }
            get { return this.buyerName;  } 
        }
        public string Company
        {
            set { this.buyerCompany = value; }
            get { return this.buyerCompany;  }
        }
        public string TaxCode
        {
            set { this.buyerTaxCode = value; }
            get { return this.buyerTaxCode;  }
        }
        public string Address
        {
            set { this.buyerAddress = value; }
            get { return this.buyerAddress;  }
        }
        public string PaymentMethod
        {
            set { this.buyerPaymentMethod = value; }
            get { return this.buyerPaymentMethod;  }
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager)
        {
            XElement xelement = XElement.Load(path);

            XElement buyerDisplayName = xelement.XPathSelectElement("./inv:invoiceData/inv:buyerDisplayName", namespaceManager);
            XElement buyerLegalName = xelement.XPathSelectElement("./inv:invoiceData/inv:buyerLegalName", namespaceManager);
            XElement buyerTaxCode = xelement.XPathSelectElement("./inv:invoiceData/inv:buyerTaxCode", namespaceManager);
            XElement buyerAddressLine = xelement.XPathSelectElement("./inv:invoiceData/inv:buyerAddressLine", namespaceManager);
            XElement buyerPaymentMethod = xelement.XPathSelectElement("./inv:invoiceData/inv:payments/inv:payment/inv:paymentMethodName", namespaceManager);

            if(buyerDisplayName == null)
                this.buyerName = "";
            else 
                this.buyerName = buyerDisplayName.Value;
            if (buyerLegalName == null)
                this.buyerCompany = "";
            else
                this.buyerCompany = buyerLegalName.Value;
            if (buyerTaxCode == null)
                this.buyerTaxCode = "";
            else 
                this.buyerTaxCode = buyerTaxCode.Value;
            if (buyerAddressLine == null)
                this.buyerAddress = "";
            else 
                this.buyerAddress = buyerAddressLine.Value;
            if(buyerPaymentMethod == null)
                this.buyerPaymentMethod = "";
            else
                this.buyerPaymentMethod = buyerPaymentMethod.Value;

        }
   }
}
