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
        private SQLiteConnection conn;
        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "invoiceDB.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error connect db : " + ex);
            }
            return sqlite_conn;
        }
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
        private static void InsertData(SQLiteConnection conn, string tableName, string value)
        {
            String queryInsert = @"INSERT INTO " + tableName +" VALUES " + value;
            try
            {
                using var cmd = new SQLiteCommand(conn);
                cmd.CommandText = queryInsert;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("message error : " + ex.Message);
            }
        }
        private static void UpdateData(SQLiteConnection conn, string table,string value, string condition)
        {
            String queryUpdate = @"UPDATE " + table + " SET " + value + " WHERE InvoiceType = " + condition;
            try
            {
                using var cmd = new SQLiteCommand(conn);
                cmd.CommandText = queryUpdate;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("message error : " + ex.Message);
            }
        }
        private static void CloseDB(SQLiteConnection conn)
        {
            conn.Close();
        }
        private string QueryNamespace(SQLiteConnection conn, string column, string table, string condition)
        {
            string myreader = "";
            int temp;
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("SELECT " + column + " FROM " + table + " WHERE Namespace LIKE '%" + condition + "%'");
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {

                    myreader = Convert.ToString(sqlite_datareader["ID"]);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return myreader;
        }
        public DefineStructNametag(string path)
        {

            this.path = path;
            //MessageBox.Show(this.path);
            InitializeComponent();
            //Load file xml 
            XElement xelemnet = XElement.Load(path);
            //Show xml vao tree view 
            ShowTreeFromPath(path);
            //Show duong dan thu muc 
            labelPath.Text = path.Replace("\\\\", "/");
            //Show namespace cua file xml 
            labelNamespace.Text = xelemnet.Name.NamespaceName;
            this.Namespace = xelemnet.Name.NamespaceName;
            //Bat su kien keo tha ben trong tree view 
            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            //Ket noi DB 
            conn = CreateConnection(); 
            //KT dieu kien da co namespace trong trong db chua neu co roi chi cho nguoi dung thuc hien chuc nang update 
            if((QueryNamespace(conn, "ID", "InvoiceType", xelemnet.Name.NamespaceName) != null) && (QueryNamespace(conn, "ID", "InvoiceType", xelemnet.Name.NamespaceName) != ""))
            {
                //an nut add de nguoi dung khong the thuc hien chuc nang add 
                buttonAdd.Visible = false;
                //lay id co namepace theo file xml tu db 
                int temp = int.Parse(QueryNamespace(conn, "ID", "InvoiceType", xelemnet.Name.NamespaceName));
                //Render data load tu db len de thuc hien chuc nang update neu KT da luu namespace trong db 
                //Render phan Invoice Infomation
                textBoxTemplateCode.Text =              ReadData(conn, "TemplateCode", "InvoiceInfo", temp);
                textBoxNumInv.Text =                    ReadData(conn, "NumberInvoice", "InvoiceInfo", temp);
                textBoxNumSeries.Text =                 ReadData(conn, "NumberSeries", "InvoiceInfo", temp);
                textBoxDate.Text =                      ReadData(conn, "Date", "InvoiceInfo", temp);
                textBoxTotalAmountWithVATbyWords.Text = ReadData(conn, "TotalAmountWithVATWords", "InvoiceInfo", temp);
                textBoxTotalAmountWithoutVAT.Text =     ReadData(conn, "TotalAmountWithoutVAT", "InvoiceInfo", temp);
                textBoxTotalVATAmount.Text =            ReadData(conn, "TotalVATAmount", "InvoiceInfo", temp);
                textBoxTotalAmountWithVAT.Text =        ReadData(conn, "TotalAmountWithVAT", "InvoiceInfo", temp);
                //Render phan Item Infomation
                textBoxNumber.Text =                    ReadData(conn, "STT", "Item", temp);
                textBoxItemName.Text =                  ReadData(conn, "NameItem", "Item", temp);
                textBoxUnitName.Text =                  ReadData(conn, "NameUnite", "Item", temp);
                textBoxQuantity.Text =                  ReadData(conn, "Quantity", "Item", temp);
                textBoxItemTotalAmountWithoutVAT.Text = ReadData(conn, "ItemTotalAmountWithoutVAT", "Item", temp);
                textBoxItemTotalVATAmount.Text =        ReadData(conn, "VATAmount", "Item", temp);
                textBoxItemVATPercentage.Text =         ReadData(conn, "VATPercentage", "Item", temp);
                textBoxUnitPrice.Text =                 ReadData(conn, "PriceUnite", "Item", temp);
                textBoxItemPromotion.Text =             ReadData(conn, "Promotion", "Item", temp);
                textBoxItemItems.Text =                 ReadData(conn, "Items", "Item", temp);
                //Render phan Seller
                textBoxSellerName.Text =                ReadData(conn, "Name", "Seller", temp);
                textBoxSellerPhone.Text =               ReadData(conn, "Phone", "Seller", temp);
                textBoxSellerFax.Text =                 ReadData(conn, "Fax", "Seller", temp);
                textBoxSellerTaxCode.Text =             ReadData(conn, "Taxcode", "Seller", temp);
                textBoxSellerAddress.Text =             ReadData(conn, "Address", "Seller", temp);
                textBoxSellerBankAccount.Text =         ReadData(conn, "BanKAccount", "Seller", temp);
                textBoxSellerBankName.Text =            ReadData(conn, "BankName", "Seller", temp);
                //Render phan Buyer
                textBoxBuyerDisplayName.Text =          ReadData(conn, "DisplayName", "Buyer", temp);
                textBoxBuyerLegalName.Text =            ReadData(conn, "LegalName", "Buyer", temp);
                textBoxBuyerTaxCode.Text =              ReadData(conn, "Taxcode", "Buyer", temp);
                textBoxBuyerPhone.Text =                ReadData(conn, "Phone", "Buyer", temp);
                textBoxBuyerFax.Text =                  ReadData(conn, "Fax", "Buyer", temp);
                textBoxBuyerPaymentMethod.Text =        ReadData(conn, "PaymentMethod", "Buyer", temp); 
                textBoxBuyerAddress.Text =              ReadData(conn, "Address", "Buyer", temp);
            }
            else
            {
                buttonUpdate.Visible = false;
            }
            CloseDB(conn);
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
            conn = CreateConnection();
            //Them namespace vao db 
            XElement xelement = XElement.Load(path);
            try
            {
                String Namespace = "(\'" + this.Namespace + "\')";
                InsertData(conn, tableNameInvoiceType, Namespace);
                //MessageBox.Show(this.Namespace);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Thuc hien chuc nang them du lieu vao db 
            string valueSeller = "(\'" + QueryNamespace(conn, "ID", "InvoiceType", this.Namespace) + "\',\'" + textBoxSellerName.Text + "\',\'"
                    + textBoxSellerTaxCode.Text + "\',\'" + textBoxSellerAddress.Text + "\',\'" + textBoxSellerPhone.Text + "\',\'"
                    + textBoxSellerFax.Text + "\',\'" + textBoxSellerBankAccount.Text + "\',\'" + textBoxSellerBankName.Text + "\')";
            string valueBuyer = "(\'" + QueryNamespace(conn, "ID", "InvoiceType", this.Namespace) + "\',\'" + textBoxBuyerDisplayName.Text + "\',\'"
                    + textBoxBuyerLegalName.Text + "\',\'" + textBoxBuyerTaxCode.Text + "\',\'" + textBoxBuyerAddress.Text + "\',\'"
                    + textBoxBuyerPhone.Text + "\',\'" + textBoxBuyerFax.Text + "\',\'" + textBoxBuyerPaymentMethod.Text + "\')";
            string valueInvoiceInfo = "(\'" + QueryNamespace(conn, "ID", "InvoiceType", this.Namespace) + "\',\'" + textBoxNumSeries.Text + "\',\'"
                    + textBoxNumInv.Text + "\',\'" + textBoxTemplateCode.Text + "\',\'" + textBoxTotalAmountWithVATbyWords.Text + "\',\'"
                    + textBoxTotalAmountWithoutVAT.Text + "\',\'" + textBoxTotalVATAmount.Text + "\',\'" 
                    + textBoxTotalAmountWithVAT.Text + "\',\'" + textBoxDate.Text + "\')";
            string valueItem = "(\'" + QueryNamespace(conn, "ID", "InvoiceType", this.Namespace) + "\',\'" + textBoxNumber.Text + "\',\'"
                    + textBoxItemName.Text + "\',\'" + textBoxUnitName.Text + "\',\'" + textBoxQuantity.Text + "\',\'" 
                    + textBoxItemTotalAmountWithoutVAT.Text + "\',\'" + textBoxItemVATPercentage.Text + "\',\'"
                    + textBoxItemTotalVATAmount.Text + "\',\'" + textBoxUnitPrice.Text + "\',\'"
                    + textBoxItemPromotion.Text + "\',\'" + textBoxItemItems.Text + "\')";
            
            InsertData(conn, tableNameSeller, valueSeller);
            InsertData(conn, tableNameBuyer, valueBuyer);
            InsertData(conn, tableNameInvoiceInfo, valueInvoiceInfo);
            InsertData(conn, tableNameItem, valueItem);
            //ngat ket noi voi db sau khi da add
            CloseDB(conn);
            MessageBox.Show("Add succes");
            Close();
        }
        //button thuc hien chuc nang update 
        private void button2_Click(object sender, EventArgs e)
        {
            //Khoi tao ket noi voi db 
            conn = CreateConnection();
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
            //MessageBox.Show(valueUpdateSeller);
            //MessageBox.Show(valueUpdateBuyer);
            //MessageBox.Show(valueUpdateInvoiceInfo);
            //MessageBox.Show(valueUpdateItem);
            UpdateData(conn, "Seller", valueUpdateSeller, QueryNamespace(conn, "ID", "InvoiceType", this.Namespace));
            UpdateData(conn, "Buyer", valueUpdateBuyer, QueryNamespace(conn, "ID", "InvoiceType", this.Namespace));
            UpdateData(conn, "InvoiceInfo", valueUpdateInvoiceInfo, QueryNamespace(conn, "ID", "InvoiceType", this.Namespace));
            UpdateData(conn, "Item", valueUpdateItem, QueryNamespace(conn, "ID", "InvoiceType", this.Namespace));
            //ngat ket noi voi db sau khi da update 
            CloseDB(conn);
            MessageBox.Show("Update succes ");
            Close();
        }
    }
}
