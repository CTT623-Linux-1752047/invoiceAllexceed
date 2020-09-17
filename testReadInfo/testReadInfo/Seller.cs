using System;
using System.Collections.Generic;
using System.Text;

namespace testReadInfo
{
    class Seller 
    {
        private string sellerName, sellerTaxCode, sellerAddress, sellerTel, sellerAccountNo;
        public Seller()
        {

        }
        public Seller(string name, string tax, string address, string tel, string account)
        {
            this.sellerName = name;
            this.sellerTaxCode = tax;
            this.sellerAddress = address;
            this.sellerTel = tel;
            this.sellerAccountNo = account;
        }
        public Seller(Seller a)
        {
            this.sellerName = a.sellerName;
            this.sellerTaxCode = a.sellerTaxCode;
            this.sellerAddress = a.SellerAddress;
            this.sellerTel = a.sellerTel;
            this.sellerAccountNo = a.sellerAccountNo;
        }
        public string SellerName
        {
            get;
            set;
        }
        public string SellerTaxCode
        {
            set;
            get;
        }
        public string SellerAddress
        {
            set;
            get;
        }
        public string SellerTel
        {
            set;
            get;
        }
        public string SellerAccountNo
        {
            set;
            get;
        }
    }
}
