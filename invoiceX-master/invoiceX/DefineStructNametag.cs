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

namespace invoiceX
{
    public partial class DefineStructNametag : Form
    {
        private string path;
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
                MessageBox.Show("connect OK");
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
        private static void Close(SQLiteConnection conn)
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
            MessageBox.Show(this.path);
            InitializeComponent();
            ShowTreeFromPath(path);
            labelPath.Text = path.Replace("\\\\", "/");
            XElement xelemnet = XElement.Load(path);
            labelNamespace.Text = xelemnet.Name.NamespaceName;
            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            conn = CreateConnection(); 
            if((QueryNamespace(conn, "ID", "InvoiceType", xelemnet.Name.NamespaceName) != null) && (QueryNamespace(conn, "ID", "InvoiceType", xelemnet.Name.NamespaceName) != ""))
            {
                buttonAdd.Visible = false;
                //Render data load tu db len de thuc hien chuc nang update neu KT da luu namespace trong db 
                
            }
            else
            {
                buttonUpdate.Visible = false;
            }
            Close(conn);
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var node = (TreeNode)e.Item;
            if (node.Level > 0)
            {
                DoDragDrop(node.Text, DragDropEffects.Copy);
            }
        }
        private void ShowTreeFromPath(string path)
        {

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNode xmlnode;

            xmldoc.Load(path);
            xmlnode = xmldoc.ChildNodes[1];
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Khoi tao ket noi voi db 
            conn = CreateConnection();
            //Thuc hien chuc nang them du lieu vao db 

            //ngat ket noi voi db sau khi da add
            Close(conn);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Khoi tao ket noi voi db 
            conn = CreateConnection();
            //Thuc hien chuc nang cap nhat du lieu vao db

            //ngat ket noi voi db sau khi da update 
            Close(conn);
        }
    }
}
