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
        private Buyer buyer;
        private Seller seller;
        private ListItem listItem;
        private string templateCode, invoiceSeries, invoiceNumber, totalAmountWithVATWords, day, month, year;
        private float totalAmountWithoutVAT, totalVATAmount, totalAmountWithVAT;
        public Invoice()
        {
            this.buyer = new Buyer();
            this.seller = new Seller();
            this.listItem = new ListItem();
            
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
        public XElement XPathElement(XElement root, string read, XmlNamespaceManager namespaceManager)
        {
            XElement node = null;
            try
            {
                node = root.XPathSelectElement(".//" + read, namespaceManager);
            }
            catch (Exception ex)
            {
                node = null;
            }
            return node;
        }
        public void getInfoFromPath(string path)
        {
            XElement xelement = XElement.Load(path);
            string Namespace = xelement.Name.NamespaceName;
            if(Namespace.Length == 0 )
            {
                MessageBox.Show("xml chưa được định dạng, không tồn tại namespace trong xml");
                System.Windows.Forms.Application.Exit();
            }
            string PrefixNamespace = xelement.GetPrefixOfNamespace(xelement.Name.Namespace);
            //Khoi tao NameTable va luu namespace;
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace(PrefixNamespace, Namespace);
            //connect DB 
            DataAccess data = new DataAccess();
            //conn = CreateConnection();
            //so sanh namespace vua get va namespace co trong db de xac dinh type invoice 
            int temp = 0;
            if ((data.QueryNamespace(Namespace) != null) && (data.QueryNamespace(Namespace) != ""))
            {
                temp = int.Parse(data.QueryNamespace(Namespace));
            }
            else
            {
                DefineStructNametag define = new DefineStructNametag(path);
                define.ShowDialog();
                try
                {
                    temp = int.Parse(data.QueryNamespace(Namespace));
                }
                catch
                {
                    MessageBox.Show("XML cần phải được định dạng trước khi mở !!! ");
                    System.Windows.Forms.Application.Exit();
                }
            }
            //MessageBox.Show("Loai hoa don " + temp);
            //get cac truong trong invoice info theo id cua namespace vua get duoc 
            XElement templateCode = XPathElement(xelement, data.ReadData("InvoiceInfo", "TemplateCode", temp), namespaceManager);
            XElement invoiceSeries = XPathElement(xelement, data.ReadData("InvoiceInfo", "NumberSeries", temp), namespaceManager);
            XElement invoiceNumber = XPathElement(xelement, data.ReadData("InvoiceInfo", "NumberInvoice", temp), namespaceManager);
            XElement date = XPathElement(xelement, data.ReadData("InvoiceInfo", "Date", temp), namespaceManager);
            XElement totalAmountWithVATWords = XPathElement(xelement, data.ReadData("InvoiceInfo", "TotalAmountWithVATWords", temp), namespaceManager);
            XElement totalAmountWithoutVAT = XPathElement(xelement, data.ReadData("InvoiceInfo", "TotalAmountWithoutVAT", temp), namespaceManager);
            XElement totalVATAmount = XPathElement(xelement, data.ReadData("InvoiceInfo", "TotalVATAmount", temp), namespaceManager);
            XElement totalAmountWithVAT = XPathElement(xelement, data.ReadData("InvoiceInfo", "TotalAmountWithVAT", temp), namespaceManager);
            //dong DB
            data.Close();
            this.templateCode = templateCode == null ? "" : templateCode.Value;
            this.invoiceSeries = invoiceSeries == null ? "" : invoiceSeries.Value;
            this.invoiceNumber = invoiceNumber == null ? "" : invoiceNumber.Value;
            this.totalAmountWithoutVAT = totalAmountWithoutVAT == null ? 0 : float.Parse( totalAmountWithoutVAT.Value);
            this.totalAmountWithVATWords = totalAmountWithVATWords == null ? "" : totalAmountWithVATWords.Value;
            this.totalVATAmount = totalVATAmount == null ? 0 : float.Parse(totalVATAmount.Value);
            this.totalAmountWithVAT = totalAmountWithVAT == null ? 0 : float.Parse(totalAmountWithVAT.Value);
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
            // lay info Buyer
            buyer = new Buyer();
            buyer.getInfoFromPath(path, namespaceManager,temp);
            //lay info Seller
            seller = new Seller();
            seller.getInfoFromPath(path, namespaceManager, temp);
            //lay list item 
            listItem = new ListItem();
            listItem.getInfoFromPath(path, namespaceManager, temp);
        }
    }
}
