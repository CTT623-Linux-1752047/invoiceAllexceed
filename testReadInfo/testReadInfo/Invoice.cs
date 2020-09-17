using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace testReadInfo
{
    class Invoice
    {
        private Buyer A;
        private Seller B;
        private List<Item> listItem;
        private string templateCode, invoiceSeries, invoiceNumber, totalAmountWithVATWorks;
        private long totalAmountWithoutVAT, totalVATAmount, totalAmountWithVAT;
        public Invoice()
        {
            this.A = new Buyer();
            this.B = new Seller();
            this.listItem = new List<Item>();
        }
        public Invoice(Buyer buyer, Seller seller, List<Item> listitems,
                        string templateCode, string invoiceSeries, string invoiceNumber, string totalAmountWithVATWorks,
                        long totalAmountWithoutVAT, long totalVATAmount, long totalAmountWithVAT)
        {
            this.A = new Buyer(buyer);
            this.B = new Seller(seller);
            this.listItem = listitems;
            this.templateCode = templateCode;
            this.invoiceSeries = invoiceSeries;
            this.invoiceNumber = invoiceNumber;
            this.totalAmountWithVATWorks = totalAmountWithVATWorks;
            this.totalAmountWithoutVAT = totalAmountWithoutVAT;
            this.totalVATAmount = totalVATAmount;
            this.totalAmountWithVAT = totalAmountWithVAT;
        }
        public string TemplateCode
        {
            set;
            get; 
        }
        public string InvoiceSeries
        {
            set;
            get;
        }
        public string InvoiceNumber
        {
            set;
            get;
        }
        public string TotalAmountWithVATWorks
        {
            set;
            get;
        }
        public long TotalAmount
        {
            set;
            get;
        }
        public long TotalAmountWithoutVAT
        {
            set;
            get;
        }
        public long TotalAmountWithVAT
        {
            set;
            get;
        }
    }
}
