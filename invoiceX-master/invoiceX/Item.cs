using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace invoiceX
{
    class ListItem
    {
        List<Item> item;

        public ListItem()
        {
            this.item = new List<Item>();
        }
        public List<Item> Item
        {
            get { return this.item; }
        }
        public bool checkColumnDiscount()
        {
            bool flag = false; 
            foreach(Item item in this.item)
            {
                if (item.ItemDscnAmnt == 0)
                    flag = true;
            }
            return flag;
        }
        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=C:..\\invoiceDB.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        private static string ReadData(SQLiteConnection conn, string column, string table, int typeInvoice)
        {
            string myreader = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT "+column+" FROM "+table+" WHERE InvoiceType = "+typeInvoice;
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
        private static void closeDB(SQLiteConnection conn)
        {
            conn.Close();
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager, int typeInvoice)
        {
            XElement xelement = XElement.Load(path);

            SQLiteConnection conn = CreateConnection();
            
            XElement rootItem = xelement.XPathSelectElement(".//" + ReadData(conn,"Items","Item",typeInvoice), namespaceManager);
            IEnumerable<XElement> listItems = rootItem.Elements();
            foreach (XElement item in listItems)
            {
                Item temp = new Item();
                XElement stt = item.XPathSelectElement("./"+ ReadData(conn, "STT","Item", typeInvoice), namespaceManager);
                XElement itemName = item.XPathSelectElement("./"+ ReadData(conn, "NameItem", "Item", typeInvoice), namespaceManager);
                XElement unitName = item.XPathSelectElement("./" + ReadData(conn, "NameUnite", "Item", typeInvoice), namespaceManager);
                XElement quantity = item.XPathSelectElement("./" + ReadData(conn, "Quantity", "Item", typeInvoice), namespaceManager);
                XElement itemTotalAmountWithoutVAT = item.XPathSelectElement("./" + ReadData(conn, "ItemTotalAmountWithoutVAT", "Item", typeInvoice), namespaceManager);
                XElement vatAmount = item.XPathSelectElement("./" + ReadData(conn, "VATAmount", "Item", typeInvoice), namespaceManager);
                XElement vatPercentage = item.XPathSelectElement("./" + ReadData(conn, "VATPercentage", "Item", typeInvoice), namespaceManager);
                XElement discountAmount = item.XPathSelectElement("./" + ReadData(conn, "Promotion", "Item", typeInvoice), namespaceManager);
                XElement unitPrice = item.XPathSelectElement("./" + ReadData(conn, "PriceUnite", "Item", typeInvoice), namespaceManager);
                
                if (stt == null)
                    temp.LineNumber = 0;
                else
                    temp.LineNumber = int.Parse(stt.Value);

                if (itemName == null)
                    temp.ItemName = "";
                else
                    temp.ItemName = itemName.Value;

                if (unitName == null)
                    temp.UnitName = "";
                else
                    temp.UnitName = unitName.Value;

                if (quantity == null)
                    temp.Quanity = 0;
                else
                    temp.Quanity = float.Parse(quantity.Value);

                if (itemTotalAmountWithoutVAT == null)
                    temp.ItemToTalAmountWithoutVAT = 0;
                else
                    temp.ItemToTalAmountWithoutVAT = float.Parse(itemTotalAmountWithoutVAT.Value);

                if (vatAmount == null)
                    temp.VATAmount = 0;
                else
                    temp.VATAmount = float.Parse(vatAmount.Value);

                if (vatPercentage == null)
                    temp.VATPercentage = 0;
                else
                    temp.VATPercentage = float.Parse(vatPercentage.Value);

                if (discountAmount == null)
                    temp.ItemDscnAmnt = 0;
                else
                    temp.ItemDscnAmnt = float.Parse(discountAmount.Value);

                if (unitPrice == null)
                    temp.UnitPrice = 0;
                else
                    temp.UnitPrice = float.Parse(unitPrice.Value);
                this.item.Add(temp);
            }
            closeDB(conn);
        }
    }
    class Item
    {
        private long lineNumber;
        private float quanity, itemTotalAmountWithoutVAT, unitPrice, vatPercentage, vatAmount, itemDscnAmnt;
        private string itemName, unitName;

        public Item()
        {

        }
        public Item(long stt, float quanity, float itemTotalAmountWithoutVAT,
                    float unitPrice, float vatPercentage, float vatAmount,
                    float itemDscnAmnt, string itemName, string unitName)
        {
            this.lineNumber = stt;
            this.quanity = quanity;
            this.itemTotalAmountWithoutVAT = itemTotalAmountWithoutVAT;
            this.unitPrice = unitPrice;
            this.vatPercentage = vatPercentage;
            this.vatAmount = vatAmount;
            this.itemDscnAmnt = itemDscnAmnt;
            this.itemName = itemName;
            this.unitName = unitName;
        }
        public Item(Item item)
        {
            this.lineNumber = item.lineNumber;
            this.quanity = item.quanity;
            this.itemTotalAmountWithoutVAT = item.itemTotalAmountWithoutVAT;
            this.unitPrice = item.unitPrice;
            this.vatPercentage = item.vatPercentage;
            this.vatAmount = item.vatAmount;
            this.itemName = item.itemName;
            this.unitName = item.unitName;
            this.itemDscnAmnt = item.itemDscnAmnt;
        }
        public long LineNumber
        {
            set { this.lineNumber = value; }
            get { return this.lineNumber; }
        }
        public float Quanity
        {
            set { this.quanity = value; }
            get { return this.quanity; }
        }
        public float ItemToTalAmountWithoutVAT
        {
            set { this.itemTotalAmountWithoutVAT = value; }
            get { return this.itemTotalAmountWithoutVAT; }
        }
        public float UnitPrice
        {
            set { this.unitPrice = value; }
            get { return this.unitPrice; }
        }
        public float VATPercentage
        {
            set { this.vatPercentage = value; }
            get { return this.vatPercentage; }
        }
        public float VATAmount
        {
            set { this.vatAmount = value; }
            get { return this.vatAmount; }
        }
        public float ItemDscnAmnt
        {
            get { return this.itemDscnAmnt ; }
            set { this.itemDscnAmnt = value; }
        }
        public string ItemName
        {
            set { this.itemName = value; }
            get { return this.itemName; }
        }
        public string UnitName
        {
            set { this.unitName = value; }
            get { return this.unitName; }
        }
    }
}
