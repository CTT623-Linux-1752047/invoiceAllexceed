using System;
using System.Collections.Generic;
using System.Text;

namespace testReadInfo
{
    class Buyer
    {
        private string buyerName, buyerCompany, buyerTaxCode, buyerAddress, buyerPaymentMethod;
        public Buyer(){}

        public Buyer(string name, string company, string taxCode, string address, string paymentMethod) {
            this.buyerName = name;
            this.buyerCompany = company;
            this.buyerTaxCode = taxCode;
            this.buyerAddress = address;
            this.buyerPaymentMethod = paymentMethod;
        }
        public Buyer(buyer a)
        {
            this.buyerName = a.buyerName;
            this.buyerCompany = a.buyerCompany;
            this.buyerTaxCode = a.buyerTaxCode;
            this.buyerAddress = a.buyerAddress;
            this.buyerPaymentMethod = a.buyerPaymentMethod;
        }
        public string Name
        {
            set;
            get; 
        }
        public string Company
        {
            set;
            get;
        }
        public string TaxCode
        {
            set;
            get;
        }
        public string Address
        {
            set;
            get;
        }
        public string PaymentMethod
        {
            set;
            get;
        }

   }
}
