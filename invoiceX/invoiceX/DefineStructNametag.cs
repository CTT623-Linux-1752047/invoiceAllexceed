using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace invoiceX
{
    
    public partial class DefineStructNametag : Form
    {
        //Khai bao table name cho query insert 
        private string tableNameSeller = "Seller(InvoiceType,Name,Taxcode,Address,Phone,Fax,BankAccount,BankName)";
        private string tableNameBuyer = "Buyer(InvoiceType,DisplayName,LegalName,Taxcode,Address,Phone,Fax,PaymentMethod)";
        private string tableNameInvoiceInfo = "InvoiceInfo(InvoiceType,NumberSeries,NumberInvoice,TemplateCode,TotalAmountWithVATWords,TotalAmountWithoutVAT,TotalVATAmount,TotalAmountWithVAT,Date)";
        private string tableNameInvoiceType = "InvoiceType(Namespace)";
        private string tableNameItem = "Item(InvoiceType,STT,NameItem,NameUnite,Quantity,ItemTotalAmountWithoutVAT,VATPercentage,VATAmount,PriceUnite,Promotion,Items)";

        private string path = "" ;
        private string Namespace = "";
        private static string ReadData(SQLiteConnection conn, string column, string table, int typeInvoice)
        {
            string myreader = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("SELECT " + column + " FROM " + table + " WHERE InvoiceType = " + typeInvoice);
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    myreader = sqlite_datareader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return myreader;
        }
        public DefineStructNametag(string path)
        {
            this.path = path;
            //MessageBox.Show(this.path);
            InitializeComponent();
            //Load file xml 
            XElement xelemnent = XElement.Load(path);
            //Show xml vao tree view 
            ShowTreeFromPath(path);
            //Show duong dan thu muc 
            labelPath.Text = path.Replace("\\\\", "/");
            //Show namespace cua file xml 
            labelNamespace.Text = xelemnent.Name.NamespaceName;
            this.Namespace = xelemnent.Name.NamespaceName;
            //Bat su kien keo tha ben trong tree view 
            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            //Ket noi DB 
            DataAccess data = new DataAccess();
            //KT dieu kien da co namespace trong trong db chua neu co roi chi cho nguoi dung thuc hien chuc nang update 
            if ((data.QueryNamespace(xelemnent.Name.NamespaceName) != null) && (data.QueryNamespace(xelemnent.Name.NamespaceName) != ""))
            {
                //an nut add de nguoi dung khong the thuc hien chuc nang add 
                buttonAdd.Visible = false;
                //lay id co namepace theo file xml tu db 
                int temp = int.Parse(data.QueryNamespace(xelemnent.Name.NamespaceName));
                //Render data load tu db len de thuc hien chuc nang update neu KT da luu namespace trong db 
                //Render phan Invoice Infomation
                textBoxTemplateCode.Text = data.ReadData("InvoiceInfo", "TemplateCode", temp);
                textBoxNumInv.Text = data.ReadData("InvoiceInfo", "NumberInvoice", temp);
                textBoxNumSeries.Text = data.ReadData("InvoiceInfo", "NumberSeries", temp);
                textBoxDate.Text = data.ReadData("InvoiceInfo", "Date", temp);
                textBoxTotalAmountWithVATbyWords.Text = data.ReadData("InvoiceInfo", "TotalAmountWithVATWords", temp);
                textBoxTotalAmountWithoutVAT.Text = data.ReadData("InvoiceInfo", "TotalAmountWithoutVAT", temp);
                textBoxTotalVATAmount.Text = data.ReadData("InvoiceInfo", "TotalVATAmount", temp);
                textBoxTotalAmountWithVAT.Text = data.ReadData("InvoiceInfo", "TotalAmountWithVAT", temp);
                //Render phan Item Infomation
                textBoxNumber.Text = data.ReadData("Item", "STT", temp);
                textBoxItemName.Text = data.ReadData("Item", "NameItem", temp);
                textBoxUnitName.Text = data.ReadData("Item", "NameUnite", temp);
                textBoxQuantity.Text = data.ReadData("Item", "Quantity", temp);
                textBoxItemTotalAmountWithoutVAT.Text = data.ReadData("Item", "ItemTotalAmountWithoutVAT", temp);
                textBoxItemTotalVATAmount.Text = data.ReadData("Item", "VATAmount", temp);
                textBoxItemVATPercentage.Text = data.ReadData("Item", "VATPercentage", temp);
                textBoxUnitPrice.Text = data.ReadData("Item", "PriceUnite", temp);
                textBoxItemPromotion.Text = data.ReadData("Item", "Promotion", temp);
                textBoxItemItems.Text = data.ReadData("Item", "Items", temp);
                //Render phan Seller
                textBoxSellerName.Text = data.ReadData("Seller", "Name", temp);
                textBoxSellerPhone.Text = data.ReadData("Seller", "Phone", temp);
                textBoxSellerFax.Text = data.ReadData("Seller", "Fax", temp);
                textBoxSellerTaxCode.Text = data.ReadData("Seller", "Taxcode", temp);
                textBoxSellerAddress.Text = data.ReadData("Seller", "Address", temp);
                textBoxSellerBankAccount.Text = data.ReadData("Seller", "BanKAccount", temp);
                textBoxSellerBankName.Text = data.ReadData("Seller", "BankName", temp);
                //Render phan Buyer
                textBoxBuyerDisplayName.Text = data.ReadData("Buyer", "DisplayName", temp);
                textBoxBuyerLegalName.Text = data.ReadData("Buyer", "LegalName", temp);
                textBoxBuyerTaxCode.Text = data.ReadData("Buyer", "Taxcode", temp);
                textBoxBuyerPhone.Text = data.ReadData("Buyer", "Phone", temp);
                textBoxBuyerFax.Text = data.ReadData("Buyer", "Fax", temp);
                textBoxBuyerPaymentMethod.Text = data.ReadData("Buyer", "PaymentMethod", temp);
                textBoxBuyerAddress.Text = data.ReadData("Buyer", "Address", temp);
            }
            else
            {
                buttonUpdate.Visible = false;
            }
            data.Close();
        }
        //thuc hien render element xml len tree view 
        private void ShowTreeFromPath(string path)
        {

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNode xmlnode;

            xmldoc.Load(path);
            xmlnode = xmldoc.LastChild;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
            TreeNode tNode;
            tNode = treeView1.Nodes[0];
            AddNode(xmlnode, tNode);
        }
        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = "Value : " + inXmlNode.InnerText.ToString();
            }
        }
        //thuc hien chuc nang keo tha item trong tree view vao textbox 
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var node = (TreeNode)e.Item;
            if (node.Level > 0)
            {
                DoDragDrop(node.Text, DragDropEffects.Copy);
            }
        }
        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Copy;
        }
        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            // MessageBox.Show;
            ((TextBox)sender).Text = (string)e.Data.GetData(typeof(string));

        }
        //confirm lai nguoi co muon exit ko 
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
        //button thuc hien chuc nang add 
        private void button1_Click(object sender, EventArgs e)
        {
            //Khoi tao ket noi voi db 
            DataAccess data = new DataAccess();
            //Them namespace vao db 
            XElement xelement = XElement.Load(path);
            String Namespace = "(\'" + this.Namespace + "\')";
            data.InsertData(tableNameInvoiceType, Namespace);
            //Thuc hien chuc nang them du lieu vao db 
            string valueSeller = "(\'" + data.QueryNamespace(this.Namespace) + "\',\'" + textBoxSellerName.Text + "\',\'" + textBoxSellerTaxCode.Text + "\',\'" 
                + textBoxSellerAddress.Text + "\',\'" + textBoxSellerPhone.Text + "\',\'" + textBoxSellerFax.Text + "\',\'" + textBoxSellerBankAccount.Text + "\',\'" + textBoxSellerBankName.Text + "\')";
            string valueBuyer = "(\'" + data.QueryNamespace(this.Namespace) + "\',\'" + textBoxBuyerDisplayName.Text + "\',\'" + textBoxBuyerLegalName.Text + "\',\'" 
                + textBoxBuyerTaxCode.Text + "\',\'" + textBoxBuyerAddress.Text + "\',\'" + textBoxBuyerPhone.Text + "\',\'" + textBoxBuyerFax.Text + "\',\'" + textBoxBuyerPaymentMethod.Text + "\')";
            string valueInvoiceInfo = "(\'" + data.QueryNamespace(this.Namespace) + "\',\'" + textBoxNumSeries.Text + "\',\'" + textBoxNumInv.Text + "\',\'" + textBoxTemplateCode.Text + "\',\'" 
                + textBoxTotalAmountWithVATbyWords.Text + "\',\'" + textBoxTotalAmountWithoutVAT.Text + "\',\'" + textBoxTotalVATAmount.Text + "\',\'"  + textBoxTotalAmountWithVAT.Text + "\',\'" + textBoxDate.Text + "\')";
            string valueItem = "(\'" + data.QueryNamespace(this.Namespace) + "\',\'" + textBoxNumber.Text + "\',\'"
                + textBoxItemName.Text + "\',\'" + textBoxUnitName.Text + "\',\'" + textBoxQuantity.Text + "\',\'" + textBoxItemTotalAmountWithoutVAT.Text + "\',\'" + textBoxItemVATPercentage.Text + "\',\'"
                + textBoxItemTotalVATAmount.Text + "\',\'" + textBoxUnitPrice.Text + "\',\'" + textBoxItemPromotion.Text + "\',\'" + textBoxItemItems.Text + "\')";
            data.InsertData(tableNameSeller, valueSeller);
            data.InsertData(tableNameBuyer, valueBuyer);
            data.InsertData(tableNameInvoiceInfo, valueInvoiceInfo);
            data.InsertData(tableNameItem, valueItem);
            //ngat ket noi voi db sau khi da add
            data.Close();
            MessageBox.Show("Add succes");
            //dong forms
            Close();
        }
        //button thuc hien chuc nang update 
        private void button2_Click(object sender, EventArgs e)
        {
            //Khoi tao ket noi voi db 
            DataAccess data = new DataAccess();
            //Thuc hien chuc nang cap nhat du lieu vao db
            string valueUpdateSeller = "Name = \'" + textBoxSellerName.Text + "\', Taxcode = \'" + textBoxSellerTaxCode.Text
                + "\', Address = \'" + textBoxSellerAddress.Text + "\' , Phone = \'" + textBoxSellerPhone.Text
                + "\', Fax = \'" + textBoxSellerFax.Text + "\', BankAccount = \'" + textBoxSellerBankAccount.Text
                + "\', BankName = \'" + textBoxSellerBankName.Text + "\'";
            string valueUpdateBuyer = "DisplayName = \'" + textBoxBuyerDisplayName.Text + "\', LegalName = \'" 
                + textBoxBuyerLegalName.Text + "\', Taxcode = \'" + textBoxBuyerTaxCode.Text + "\' , Phone = \'" 
                + textBoxBuyerPhone.Text + "\', Fax = \'" + textBoxBuyerFax.Text + "\', Address = \'" 
                + textBoxBuyerAddress.Text + "\', PaymentMethod = \'" + textBoxBuyerPaymentMethod.Text + "\'";
            string valueUpdateInvoiceInfo = "NumberSeries = \'" + textBoxNumSeries.Text + "\', NumberInvoice = \'"
                + textBoxNumInv.Text + "\', TemplateCode = \'" + textBoxTemplateCode.Text + "\', TotalAmountWithVATWords = \'" 
                + textBoxTotalAmountWithVATbyWords.Text + "\', TotalAmountWithoutVAT = \'" + textBoxTotalAmountWithoutVAT.Text + "\', TotalVATAmount = \'" 
                + textBoxTotalVATAmount.Text + "\', TotalAmountWithVAT = \'" + textBoxTotalAmountWithVAT.Text + "\', Date = \'" + textBoxDate.Text + "\'";
            string valueUpdateItem = "STT = \'" + textBoxNumber.Text + "\', NameItem = \'"
                + textBoxItemName.Text + "\', NameUnite = \'" + textBoxUnitName.Text + "\', Quantity = \'" 
                + textBoxQuantity.Text + "\', ItemTotalAmountWithoutVAT = \'" + textBoxItemTotalAmountWithoutVAT.Text + "\', VATPercentage = \'" 
                + textBoxItemVATPercentage.Text + "\', VATAmount = \'"+ textBoxItemTotalVATAmount.Text + "\', PriceUnite = \'" 
                + textBoxUnitPrice.Text + "\', Promotion = \'" + textBoxItemPromotion.Text + "\', Items = \'" + textBoxItemItems.Text + "\'";
            data.UpdateData("Seller", valueUpdateSeller, data.QueryNamespace(this.Namespace));
            data.UpdateData("Buyer", valueUpdateBuyer, data.QueryNamespace(this.Namespace));
            data.UpdateData("InvoiceInfo", valueUpdateInvoiceInfo, data.QueryNamespace(this.Namespace));
            data.UpdateData("Item", valueUpdateItem, data.QueryNamespace(this.Namespace));
            //ngat ket noi voi db sau khi da update 
            data.Close();
            MessageBox.Show("Update succes ");
            //dong forms
            Close();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b') && !(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
