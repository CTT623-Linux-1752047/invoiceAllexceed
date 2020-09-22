using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace invoiceX
{
    public partial class Form1 : Form
    {
        private Invoice invoice; 
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đọcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                //String path1 = @"C:\\Users\\toanlm\\Desktop\\C#\\Receipt\\0009786.xml";
                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
                namespaceManager.AddNamespace("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
                namespaceManager.AddNamespace("aw", "http://www.w3.org/2000/09/xmldsig#");
                this.invoice = new Invoice();
                this.invoice.getInfoFromPath(path, namespaceManager);

                //Add info buyer to display windows 
                buyerName.Text = this.invoice.Buyer.Name;
                buyerCompany.Text = this.invoice.Buyer.Company;
                buyerAddress.Text = this.invoice.Buyer.Address;
                buyerTaxCode.Text = this.invoice.Buyer.TaxCode;
                buyerPaymentMethod.Text = this.invoice.Buyer.PaymentMethod;
                buyerAccount.Text = this.invoice.Buyer.Account;

                //Add info seller to display windows 
                sellerName.Text = this.invoice.Seller.SellerName;
                sellerTaxCode.Text = this.invoice.Seller.SellerTaxCode;
                sellerAddress.Text = this.invoice.Seller.SellerAddress;
                sellerTel.Text = this.invoice.Seller.SellerTel;
                sellerAccount.Text = this.invoice.Seller.SellerAccountNo;
                sellerFax.Text = this.invoice.Seller.SellerFaxNumber;
                sellerAddressOfAccount.Text = this.invoice.Seller.SellerBankName;

                //Add info invoice header to display windows 
                day.Text = this.invoice.Day;
                month.Text = this.invoice.Month;
                year.Text = this.invoice.Year;
                numberForm.Text = this.invoice.TemplateCode;
                numberSeries.Text = this.invoice.InvoiceSeries;
                numberInvoice.Text = this.invoice.InvoiceNumber;
                totalAmountWithVATByWords.Text = this.invoice.TotalAmountWithVATWords;
                totalAmountWithVAT.Text = this.invoice.TotalAmountWithVAT.ToString("#,##0");
                AmountVAT.Text = this.invoice.TotalAmount.ToString("#,##0");
                totalAmountKhongVAT.Text = this.invoice.TotalAmountWithoutVAT.ToString("#,##0");

                //Add item to display windows 
                int i = 0;
                if(this.invoice.ListItem.checkColumnDiscount())
                {

                }
                listItems.Items.Clear();
                foreach(Item item in this.invoice.ListItem.Item)
                {
                    listItems.Items.Add(item.LineNumber.ToString());
                    listItems.Items[i].SubItems.Add(item.ItemName);
                    listItems.Items[i].SubItems.Add(item.UnitName);
                    listItems.Items[i].SubItems.Add(item.Quanity.ToString());
                    listItems.Items[i].SubItems.Add(item.UnitPrice.ToString("#,##0"));
                    listItems.Items[i].SubItems.Add(item.ItemDscnAmnt.ToString("#,##0"));// phan chiet khau | promotion
                    listItems.Items[i].SubItems.Add(item.ItemToTalAmountWithoutVAT.ToString("#,##0"));
                    listItems.Items[i].SubItems.Add(item.VATPercentage.ToString("#,##0"));
                    listItems.Items[i].SubItems.Add(item.VATAmount.ToString("#,##0"));
                    listItems.Items[i].SubItems.Add((item.VATAmount+item.ItemToTalAmountWithoutVAT).ToString("#,##0"));
                    //check xem flied promotion va discount co chua neu chua chu thi set with = 0 gian with cac cot con lai 
                    
                    i++;
                }
            }
        }
    }
}
