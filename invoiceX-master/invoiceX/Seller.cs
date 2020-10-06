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
    class Seller
    {
        private string sellerName, sellerTaxCode, sellerAddress, sellerTel, sellerAccountNo, sellerFaxNumber, bankName;
        public Seller()
        {
        }
        public Seller(string name, string tax, string address, string tel, string account, string fax, string bankName)
        {
            this.sellerName = name;
            this.sellerTaxCode = tax;
            this.sellerAddress = address;
            this.sellerTel = tel;
            this.sellerAccountNo = account;
            this.sellerFaxNumber = fax;
            this.bankName = bankName;
        }
        public Seller(Seller a)
        {
            this.sellerName = a.sellerName;
            this.sellerTaxCode = a.sellerTaxCode;
            this.sellerAddress = a.SellerAddress;
            this.sellerTel = a.sellerTel;
            this.sellerAccountNo = a.sellerAccountNo;
            this.bankName = a.bankName;
        }
        public string SellerName
        {
            get { return this.sellerName; }
            set { this.sellerName = value; }
        }
        public string SellerFaxNumber
        {
            set { this.sellerFaxNumber = value; }
            get { return this.sellerFaxNumber; }
        }
        public string SellerTaxCode
        {
            set { this.sellerTaxCode = value; }
            get { return this.sellerTaxCode; }
        }
        public string SellerAddress
        {
            set { this.sellerAddress = value; }
            get { return this.sellerAddress; }
        }
        public string SellerTel
        {
            set { this.sellerTel = value; }
            get { return this.sellerTel; }
        }
        public string SellerAccountNo
        {
            set { this.sellerAccountNo = value; }
            get { return this.sellerAccountNo; }
        }
        public string SellerBankName
        {
            get { return this.bankName; }
        }
        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source="+ AppDomain.CurrentDomain.BaseDirectory + "invoiceDB.db; Version = 3; New = True; Compress = True; ");
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
            sqlite_cmd.CommandText = "SELECT "+ column +" FROM " + table + " WHERE InvoiceType = " + typeInvoice;
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    myreader = sqlite_datareader.GetString(0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return myreader;
        }
        private static void closeDB(SQLiteConnection conn)
        {
            conn.Close();
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager, SQLiteConnection conn, int typeInvoice)
        {
            conn = CreateConnection();
            //MessageBox.Show("resualt : " + ReadData(conn, "legalName", "Seller"));
            XElement xelement = XElement.Load(path);
            // get node theo duong dan xpath
            XElement sellerLegalName = null;
            XElement sellerTaxCode = null;
            XElement sellerAddressLine = null;
            XElement sellerPhoneNumber = null;
            XElement sellerFaxNumber = null;
            XElement sellerBankAccount = null;
            XElement sellerBankName = null;
            try
            {
                sellerLegalName = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "Name", "Seller", typeInvoice)), namespaceManager);
                sellerTaxCode = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "Taxcode", "Seller", typeInvoice)), namespaceManager);
                sellerAddressLine = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "Address", "Seller", typeInvoice)), namespaceManager);
                sellerPhoneNumber = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "Phone", "Seller", typeInvoice)), namespaceManager);
                sellerFaxNumber = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "Fax", "Seller", typeInvoice)), namespaceManager);
                sellerBankAccount = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "BanKAccount", "Seller", typeInvoice)), namespaceManager);
                sellerBankName = xelement.XPathSelectElement(".//" + String.Format(ReadData(conn, "BankName", "Seller", typeInvoice)), namespaceManager);
                closeDB(conn);
            }
            finally
            {
                //lay value node vua get duoc them vao trong object seller 
                //Kiem tra element node co null kho neu co gan gia tri rong cho flied do
                if (sellerLegalName == null)
                    this.sellerName = "";
                else
                    this.sellerName = sellerLegalName.Value;
                if (sellerTaxCode == null)
                    this.sellerTaxCode = "";
                else
                    this.sellerTaxCode = sellerTaxCode.Value;
                if (sellerAddressLine == null)
                    this.sellerAddress = "";
                else
                    this.sellerAddress = sellerAddressLine.Value;
                if (sellerPhoneNumber == null)
                    this.sellerTel = "";
                else
                {
                    if (sellerPhoneNumber.Value.Contains('-'))
                    {
                        string[] cutStringPhoneFax = sellerPhoneNumber.Value.Split('-');
                        cutStringPhoneFax[0] = cutStringPhoneFax[0].TrimStart();
                        cutStringPhoneFax[0] = cutStringPhoneFax[0].TrimEnd();
                        cutStringPhoneFax[1] = cutStringPhoneFax[0].TrimStart();
                        cutStringPhoneFax[1] = cutStringPhoneFax[0].TrimEnd();
                        this.SellerFaxNumber = cutStringPhoneFax[1];
                        this.SellerTel = cutStringPhoneFax[0];
                    }
                    else
                        this.sellerTel = sellerPhoneNumber.Value;

                }
                if ((sellerFaxNumber != null))
                    this.sellerFaxNumber = sellerFaxNumber.Value;
                if (sellerBankAccount == null)
                    this.sellerAccountNo = null;
                else
                    this.sellerAccountNo = sellerBankAccount.Value;
                if (sellerBankName == null)
                    this.bankName = "";
                else
                    this.bankName = sellerBankName.Value;
            }
        }
    }
}
