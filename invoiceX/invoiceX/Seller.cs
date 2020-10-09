using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data.SQLite;
using System.Windows.Forms;

namespace invoiceX
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
            get { return this.sellerName; }
            set { this.sellerName = value; }
        }
        public string SellerFaxNumber
        {
            set { this.sellerFaxNumber = value; }
            get { return this.sellerFaxNumber; }
        }
        public string SellerTaxCode
        {
            set { this.sellerTaxCode = value; }
            get { return this.sellerTaxCode; }
        }
        public string SellerAddress
        {
            set { this.sellerAddress = value; }
            get { return this.sellerAddress; }
        }
        public string SellerTel
        {
            set { this.sellerTel = value; }
            get { return this.sellerTel; }
        }
        public string SellerAccountNo
        {
            set { this.sellerAccountNo = value; }
            get { return this.sellerAccountNo; }
        }
        public string SellerBankName
        {
            get { return this.bankName; }
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
            DataAccess data = new DataAccess();
            XElement xelement = XElement.Load(path);
            // get node theo duong dan xpath
            XElement sellerLegalName = XPathElement(xelement, data.ReadData("Seller", "Name", typeInvoice), namespaceManager);
            XElement sellerTaxCode = XPathElement(xelement, data.ReadData("Seller", "Taxcode", typeInvoice), namespaceManager);
            XElement sellerAddressLine = XPathElement(xelement, data.ReadData("Seller", "Address", typeInvoice), namespaceManager);
            XElement sellerPhoneNumber = XPathElement(xelement, data.ReadData("Seller", "Phone", typeInvoice), namespaceManager);
            XElement sellerFaxNumber = XPathElement(xelement, data.ReadData("Seller", "Fax", typeInvoice), namespaceManager);
            XElement sellerBankAccount = XPathElement(xelement, data.ReadData("Seller", "BanKAccount", typeInvoice), namespaceManager);
            XElement sellerBankName = XPathElement(xelement, data.ReadData("Seller", "BankName", typeInvoice), namespaceManager);
            data.Close();
            //lay value node vua get duoc them vao trong object seller 
            //Kiem tra element node co null kho neu co gan gia tri rong cho flied do
            this.sellerName = sellerLegalName == null ? "" : sellerLegalName.Value;
            this.sellerTaxCode = sellerTaxCode == null ? "" : sellerTaxCode.Value;
            this.sellerAddress = sellerAddressLine == null ? "" : sellerAddressLine.Value;
            if (sellerPhoneNumber == null)
                this.sellerTel = "";
            else
            {
                if (sellerPhoneNumber.Value.Contains('-'))
                {
                    string[] cutStringPhoneFax = sellerPhoneNumber.Value.Split('-');
                    cutStringPhoneFax[0] = cutStringPhoneFax[0].TrimStart();
                    cutStringPhoneFax[0] = cutStringPhoneFax[0].TrimEnd();
                    cutStringPhoneFax[1] = cutStringPhoneFax[0].TrimStart();
                    cutStringPhoneFax[1] = cutStringPhoneFax[0].TrimEnd();
                    this.SellerFaxNumber = cutStringPhoneFax[1];
                    this.SellerTel = cutStringPhoneFax[0];
                }
                else
                    this.sellerTel = sellerPhoneNumber.Value;
            }
            this.sellerFaxNumber = sellerFaxNumber != null ? sellerFaxNumber.Value : this.SellerTel;
            this.sellerAccountNo = sellerBankAccount == null ? "" : sellerBankAccount.Value;
            this.bankName = sellerBankName == null ? "" : sellerBankName.Value;
        }
    }
}
