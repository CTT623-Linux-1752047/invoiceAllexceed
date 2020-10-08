using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace invoiceX
{
    public partial class ReadXML : Form
    {
       
        private Invoice invoice;
        private string path;
        public ReadXML()
        {
                      
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.path == null)
            {
                cậpNhậtNamespaceToolStripMenuItem.Visible = false;
            }

            if ((invoiceX.Program.FileName1 != null))
            {
                if (!checkExtensionsPath(invoiceX.Program.FileName1))
                {
                    MessageBox.Show("Không phải file XML");
                    Close();
                }
                else
                {
                   this.path = invoiceX.Program.FileName1;  
                   this.ShowInvoice(invoiceX.Program.FileName1);
                    cậpNhậtNamespaceToolStripMenuItem.Visible = true;
                }
            }
        }
        
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                if (checkExtensionsPath(file))
                {
                    this.path = file;
                    ShowInvoice(file);
                    cậpNhậtNamespaceToolStripMenuItem.Visible = true;
                }
                else
                    MessageBox.Show("không phải file XML");
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
                this.path = path;
                ShowInvoice(path);
                cậpNhậtNamespaceToolStripMenuItem.Visible = true;
            }

        }
        private void ShowInvoice(string path)
        {
            this.invoice = new Invoice();
            this.invoice.getInfoFromPath(path);

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
            if (this.invoice.ListItem.checkColumnDiscount())
            {

            }
            listItems.Items.Clear();
            listItems.Columns[4].TextAlign = HorizontalAlignment.Right;
            listItems.Columns[5].TextAlign = HorizontalAlignment.Right;
            listItems.Columns[6].TextAlign = HorizontalAlignment.Right;
            listItems.Columns[7].TextAlign = HorizontalAlignment.Right;
            listItems.Columns[8].TextAlign = HorizontalAlignment.Right;
            listItems.Columns[9].TextAlign = HorizontalAlignment.Right;
            //listItems.HeaderStyle = (ColumnHeaderStyle)ColumnHeaderAutoResizeStyle.ColumnContent;

            foreach (Item item in this.invoice.ListItem.Item)
            {

                listItems.Items.Add(item.LineNumber.ToString());
                listItems.Items[i].ForeColor = Color.DarkCyan;
                listItems.Items[i].SubItems.Add(item.ItemName);
                listItems.ShowItemToolTips = true;
                listItems.Items[i].Font = new Font("calibri", 12, FontStyle.Regular);
                listItems.Items[i].SubItems.Add(item.UnitName);
                listItems.Items[i].SubItems.Add(item.Quanity.ToString());
                listItems.Items[i].SubItems.Add(item.UnitPrice.ToString("#,##0"));
                listItems.Items[i].SubItems.Add(item.ItemDscnAmnt.ToString("#,##0"));// phan chiet khau | promotion
                listItems.Items[i].SubItems.Add(item.ItemToTalAmountWithoutVAT.ToString("#,##0"));
                listItems.Items[i].SubItems.Add(item.VATPercentage.ToString("#,##0"));
                listItems.Items[i].SubItems.Add(item.VATAmount.ToString("#,##0"));
                listItems.Items[i].SubItems.Add((item.VATAmount + item.ItemToTalAmountWithoutVAT).ToString("#,##0"));
                //check xem flied promotion va discount co chua neu chua chu thi set with = 0 gian with cac cot con lai 

                i++;
            }
        }
        private void numberForm_Click(object sender, EventArgs e)
        {
        }
        private bool checkExtensionsPath(string link)
        {
            bool flag = false;
           
            String extensions = link.Substring(link.Length - 3, 3);
            if (extensions.CompareTo("xml") == 0)
                flag = true;
            return flag;
        }

        private void cậpNhậtNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineStructNametag define = new DefineStructNametag(this.path);
            define.ShowDialog();
            this.Controls.Clear();
            this.InitializeComponent();
            ShowInvoice(path);
        }
    }
}
