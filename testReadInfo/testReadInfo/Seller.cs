using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace testReadInfo
{
    class Seller 
    {
        private string sellerName, sellerTaxCode, sellerAddress, sellerTel, sellerAccountNo, sellerFaxNumber, bankName;
        public Seller()
        {
        }
        public Seller(string name, string tax, string address, string tel, string account, string fax, string bankName)
        {
            this.sellerName = name;
            this.sellerTaxCode = tax;
            this.sellerAddress = address;
            this.sellerTel = tel;
            this.sellerAccountNo = account;
            this.sellerFaxNumber = fax;
            this.bankName = bankName;
        }
        public Seller(Seller a)
        {
            this.sellerName = a.sellerName;
            this.sellerTaxCode = a.sellerTaxCode;
            this.sellerAddress = a.SellerAddress;
            this.sellerTel = a.sellerTel;
            this.sellerAccountNo = a.sellerAccountNo;
            this.bankName = a.bankName;
        }
        public string SellerName
        {
            get { return this.sellerName;  }
            set { this.sellerName = value; }
        }
        public string SellerFaxNumber
        {
            set { this.sellerFaxNumber = value; }
            get { return this.sellerFaxNumber;  }
        }    
        public string SellerTaxCode
        {
            set { this.sellerTaxCode = value; }
            get { return this.sellerTaxCode;  }
        }
        public string SellerAddress
        {
            set { this.sellerAddress = value; }
            get { return this.sellerAddress;  }
        }
        public string SellerTel
        {
            set { this.sellerTel = value; }
            get { return this.sellerTel;  }
        }
        public string SellerAccountNo
        {
            set { this.sellerAccountNo = value; }
            get { return this.sellerAccountNo;  }
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager)
        {
            XElement xelement = XElement.Load(path);

            // get node theo duong dan xpath
            XElement sellerLegalName = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerLegalName", namespaceManager);
            XElement sellerTaxCode = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerTaxCode", namespaceManager);
            XElement sellerAddressLine = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerAddressLine", namespaceManager);
            XElement sellerPhoneNumber = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerPhoneNumber", namespaceManager);
            XElement sellerFaxNumber = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerFaxNumber", namespaceManager);
            XElement sellerBankAccount = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerLegalName", namespaceManager);
            XElement sellerBankName = xelement.XPathSelectElement("./inv:invoiceData/inv:sellerBankName", namespaceManager);

            //lay value node vua get duoc them vao trong object seller 
            //Kiem tra element node co null kho neu co gan gia tri rong cho flied do
            if (sellerLegalName == null)
                this.sellerName = "";
            else 
                this.sellerName = sellerLegalName.Value;
            if (sellerTaxCode == null)
                this.sellerTaxCode = "";
            else 
                this.sellerTaxCode = sellerTaxCode.Value;
            if (sellerAddressLine == null)
                this.sellerAddress = "";
            else 
                this.sellerAddress = sellerAddressLine.Value;
            if (sellerPhoneNumber == null)
                this.sellerTel = "";
            else 
                this.sellerTel = sellerPhoneNumber.Value;
            if (sellerBankAccount == null)
                this.sellerAccountNo = null;
            else 
                this.sellerAccountNo = sellerBankAccount.Value;
            if (sellerFaxNumber == null)
                this.sellerFaxNumber = "";
            else 
                this.sellerFaxNumber = sellerFaxNumber.Value;
            if (sellerBankName == null)
                this.bankName = "";
            else
                this.bankName = sellerBankName.Value;

        }
    }

}
