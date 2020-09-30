using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Linq.Expressions;

namespace invoiceX
{
    class Buyer
    {
        private string buyerName, buyerCompany, buyerTaxCode, buyerAddress, buyerPaymentMethod, buyerAccount;
        public Buyer()
        {
            this.buyerName = null;
            this.buyerCompany = null;
            this.buyerTaxCode = null;
            this.buyerAddress = null;
            this.buyerPaymentMethod = null;

        }
        public Buyer(string name, string company, string taxCode, string address, string paymentMethod, string buyerAccount)
        {
            this.buyerName = name;
            this.buyerCompany = company;
            this.buyerTaxCode = taxCode;
            this.buyerAddress = address;
            this.buyerPaymentMethod = paymentMethod;
            this.buyerAccount = buyerAccount;
        }
        public Buyer(Buyer a)
        {
            this.buyerName = a.buyerName;
            this.buyerCompany = a.buyerCompany;
            this.buyerTaxCode = a.buyerTaxCode;
            this.buyerAddress = a.buyerAddress;
            this.buyerPaymentMethod = a.buyerPaymentMethod;
            this.buyerAccount = a.buyerAccount;
        }
        public string Name
        {
            set { this.buyerName = value; }
            get { return this.buyerName; }
        }
        public string Company
        {
            set { this.buyerCompany = value; }
            get { return this.buyerCompany; }
        }
        public string TaxCode
        {
            set { this.buyerTaxCode = value; }
            get { return this.buyerTaxCode; }
        }
        public string Address
        {
            set { this.buyerAddress = value; }
            get { return this.buyerAddress; }
        }
        public string PaymentMethod
        {
            set { this.buyerPaymentMethod = value; }
            get { return this.buyerPaymentMethod; }
        }
        public string Account
        {
            get { return this.buyerAccount; }
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
            sqlite_cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE InvoiceType = " + typeInvoice;
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

            //tao ket noi voi db 
            SQLiteConnection conn = CreateConnection();
            
                XElement buyerDisplayName = xelement.XPathSelectElement(".//" + ReadData(conn, "DisplayName", "Buyer", typeInvoice), namespaceManager);
                XElement buyerLegalName = xelement.XPathSelectElement(".//" + ReadData(conn, "LegalName", "Buyer", typeInvoice), namespaceManager);
                XElement buyerTaxCode = xelement.XPathSelectElement(".//" + ReadData(conn, "Taxcode", "Buyer", typeInvoice), namespaceManager);
                XElement buyerAddressLine = xelement.XPathSelectElement(".//" + ReadData(conn, "Address", "Buyer", typeInvoice), namespaceManager);
                XElement buyerPaymentMethod = xelement.XPathSelectElement(".//" + ReadData(conn, "PaymentMethod", "Buyer", typeInvoice), namespaceManager);
                closeDB(conn);
                if ((buyerDisplayName == null) || (buyerDisplayName.Value == ""))
                    this.buyerName = buyerLegalName.Value;
                else
                    this.buyerName = buyerDisplayName.Value;
                if (buyerLegalName == null)
                    this.buyerCompany = "";
                else
                    this.buyerCompany = buyerLegalName.Value;
                if (buyerTaxCode == null)
                    this.buyerTaxCode = "";
                else
                    this.buyerTaxCode = buyerTaxCode.Value;
                if (buyerAddressLine == null)
                    this.buyerAddress = "";
                else
                    this.buyerAddress = buyerAddressLine.Value;
                if (buyerPaymentMethod == null)
                    this.buyerPaymentMethod = "";
                else
                    this.buyerPaymentMethod = buyerPaymentMethod.Value;
            
        }
    }
}
