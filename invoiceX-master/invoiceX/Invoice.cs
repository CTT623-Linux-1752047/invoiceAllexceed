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
    class Invoice
    {
        private static SQLiteConnection conn;
        private Buyer buyer;
        private Seller seller;
        private ListItem listItem;
        private string templateCode, invoiceSeries, invoiceNumber, totalAmountWithVATWords, day, month, year;
        private float totalAmountWithoutVAT, totalVATAmount, totalAmountWithVAT;
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
        private static string ReadData(SQLiteConnection conn, string column, string table, string condition)
        {
            string myreader = "";
            int temp;
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("SELECT ID FROM type_Invoice WHERE nameSpace LIKE \" % http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1%\"");
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    temp = (int)sqlite_datareader.GetValue(0);
                    MessageBox.Show("temp" + temp);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
            return myreader;
        }
        private static void Close(SQLiteConnection conn)
        {
            conn.Close();
        }

        public Invoice()
        {
            this.buyer = new Buyer();
            this.seller = new Seller();
            this.listItem = new ListItem();
        }
        public void getInfoFromPath(string path)
        {
            int type_Invoice = 0;
            XElement xelement = XElement.Load(path);
            string Namespace = xelement.Name.NamespaceName;
            string PrefixNamespace = xelement.GetPrefixOfNamespace(xelement.Name.Namespace);
            //Khoi tao NameTable va luu namespace;
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace(PrefixNamespace, Namespace);
            //so sanh namespace vua get va namespace co trong db de xac dinh type invoice 
            //connect DB 
            conn = CreateConnection();
            //get data from DB
            string temp = "";
            if (ReadData(conn, "ID", "type_Invoice", Namespace) != null)
            {
                temp = ReadData(conn, "ID", "type_Invoice", Namespace);
            }
            Close(conn);
            MessageBox.Show("type " + temp);
            XElement templateCode = xelement.XPathSelectElement("./inv:invoiceData/inv:templateCode", namespaceManager);
            XElement invoiceSeries = xelement.XPathSelectElement("./inv:invoiceData/inv:invoiceSeries", namespaceManager);
            XElement invoiceNumber = xelement.XPathSelectElement("./inv:invoiceData/inv:invoiceNumber", namespaceManager);
            XElement date = xelement.XPathSelectElement("./inv:invoiceData/inv:invoiceIssuedDate", namespaceManager);
            XElement totalAmountWithVATWords = xelement.XPathSelectElement("./inv:invoiceData/inv:totalAmountWithVATInWords", namespaceManager);
            XElement totalAmountWithoutVAT = xelement.XPathSelectElement("./inv:invoiceData/inv:totalAmountWithoutVAT", namespaceManager);
            XElement totalVATAmount = xelement.XPathSelectElement("./inv:invoiceData/inv:totalVATAmount", namespaceManager);
            XElement totalAmountWithVAT = xelement.XPathSelectElement("./inv:invoiceData/inv:totalAmountWithVAT", namespaceManager);
            if (templateCode == null)
                this.templateCode = "";
            else
                this.templateCode = templateCode.Value;
            if (invoiceSeries == null)
                this.invoiceSeries = "";
            else
                this.invoiceSeries = invoiceSeries.Value;
            if (invoiceNumber == null)
                this.invoiceNumber = "";
            else
                this.invoiceNumber = invoiceNumber.Value;
            if (date == null)
            {
                this.day = "00";
                this.month = "00";
                this.year = "xxxx";
            }
            else
            {
                if (date.Value.Contains("T"))
                {
                    string[] parseDateAndTime = date.Value.Split('T');
                    string[] dateTemp = parseDateAndTime[0].Split('-');
                    this.day = dateTemp[2];
                    this.month = dateTemp[1];
                    this.year = dateTemp[0];
                }
                else
                {
                    string[] dateTemp = date.Value.Split('/');
                    this.day = dateTemp[0];
                    this.month = dateTemp[1];
                    this.year = dateTemp[2];
                }
            }
            if (totalAmountWithoutVAT == null)
                this.totalAmountWithoutVAT = 0;
            else
                this.totalAmountWithoutVAT = float.Parse(totalAmountWithoutVAT.Value);
            if (totalAmountWithVATWords == null)
                this.totalAmountWithVATWords = "";
            else
                this.totalAmountWithVATWords = totalAmountWithVATWords.Value;
            if (totalVATAmount == null)
                this.totalVATAmount = 0;
            else
                this.totalVATAmount = float.Parse(totalVATAmount.Value);
            if (totalAmountWithVAT == null)
                this.totalAmountWithVAT = 0;
            else
                this.totalAmountWithVAT = float.Parse(totalAmountWithVAT.Value);
            // lay info Buyer
            buyer = new Buyer();
            buyer.getInfoFromPath(path, namespaceManager);
            //lay info Seller
            seller = new Seller();
            seller.getInfoFromPath(path, namespaceManager, conn, 1);
            //lay list item 
            listItem = new ListItem();
            listItem.getInfoFromPath(path, namespaceManager);
        }
        public Invoice(Buyer buyer, Seller seller, List<Item> listitems,
                        string templateCode, string invoiceSeries, string invoiceNumber, string totalAmountWithVATWorks,
                        long totalAmountWithoutVAT, long totalVATAmount, long totalAmountWithVAT)
        {
            this.buyer = new Buyer(buyer);
            this.seller = new Seller(seller);
            //this.listItem = lisIte;
            this.templateCode = templateCode;
            this.invoiceSeries = invoiceSeries;
            this.invoiceNumber = invoiceNumber;
            this.totalAmountWithVATWords = totalAmountWithVATWorks;
            this.totalAmountWithoutVAT = totalAmountWithoutVAT;
            this.totalVATAmount = totalVATAmount;
            this.totalAmountWithVAT = totalAmountWithVAT;
        }
        public string TemplateCode
        {
            set {; }
            get { return this.templateCode; }
        }
        public string InvoiceSeries
        {
            set {; }
            get { return this.invoiceSeries; }
        }
        public string InvoiceNumber
        {
            set {; }
            get { return this.invoiceNumber; }
        }
        public string TotalAmountWithVATWords
        {
            set {; }
            get { return this.totalAmountWithVATWords; }
        }
        public float TotalAmount
        {
            set {; }
            get { return this.totalVATAmount; }
        }
        public float TotalAmountWithoutVAT
        {
            set {; }
            get { return this.totalAmountWithoutVAT; }
        }
        public float TotalAmountWithVAT
        {
            set {; }
            get { return this.totalAmountWithVAT; }
        }
        public string Day
        {
            set {; }
            get { return this.day; }
        }
        public string Month
        {
            set {; }
            get { return this.month; }
        }
        public string Year
        {
            set {; }
            get { return this.year; }
        }
        public Seller Seller
        {
            get { return this.seller; }
        }
        public Buyer Buyer
        {
            get { return this.buyer; }
        }
        public ListItem ListItem
        {
            get { return this.listItem; }
        }
    }
}
