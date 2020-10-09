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
        public XElement XPathElement(XElement root, string read, XmlNamespaceManager namespaceManager)
        {
            XElement node = null;
            try
            {
                node = root.XPathSelectElement(".//" + read, namespaceManager);
            }
            catch(Exception ex)
            {
                node = null; 
            }
            return node;
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManagers, int typeInvoice)
        {
            XElement xelement = XElement.Load(path);
            DataAccess data = new DataAccess();
            XElement rootItem = XPathElement(xelement, data.ReadData("Item", "Items", typeInvoice), namespaceManagers);
            IEnumerable<XElement> listItems = rootItem.Elements();
            foreach (XElement item in listItems)
            {
                Item temp = new Item();
                XElement stt = XPathElement(item, data.ReadData("Item", "STT", typeInvoice), namespaceManagers);
                XElement itemName = XPathElement(item, data.ReadData("Item", "NameItem", typeInvoice), namespaceManagers);
                XElement unitName = XPathElement(item, data.ReadData("Item", "NameUnite", typeInvoice), namespaceManagers);
                XElement quantity = XPathElement(item, data.ReadData("Item", "Quantity", typeInvoice), namespaceManagers);
                XElement itemTotalAmountWithoutVAT = XPathElement(item, data.ReadData("Item", "ItemTotalAmountWithoutVAT", typeInvoice), namespaceManagers);
                XElement vatAmount = XPathElement(item, data.ReadData("Item", "VATAmount", typeInvoice), namespaceManagers);
                XElement vatPercentage = XPathElement(item, data.ReadData("Item", "VATPercentage", typeInvoice), namespaceManagers);
                XElement discountAmount = XPathElement(item, data.ReadData("Item", "Promotion", typeInvoice), namespaceManagers);
                XElement unitPrice = XPathElement(item, data.ReadData("Item", "PriceUnite", typeInvoice), namespaceManagers);

                temp.LineNumber = stt == null ? -1 : int.Parse(stt.Value);
                temp.ItemName = itemName == null ? "" : itemName.Value;
                temp.UnitName = unitName == null ? "" : unitName.Value;
                temp.Quanity = quantity == null ? 0 : float.Parse(quantity.Value);
                temp.ItemToTalAmountWithoutVAT = itemTotalAmountWithoutVAT == null ? 0 : float.Parse(itemTotalAmountWithoutVAT.Value);
                temp.VATAmount = vatAmount == null ? 0 : float.Parse(vatAmount.Value);
                temp.VATPercentage = vatPercentage == null ? 0 : float.Parse(vatPercentage.Value);
                temp.ItemDscnAmnt = discountAmount == null ? 0 : float.Parse(discountAmount.Value);
                temp.UnitPrice = unitPrice == null ? 0 : float.Parse(unitPrice.Value);
                this.item.Add(temp);
            }
            data.Close();
        }
    }
    class Item
    {
        private long lineNumber;
        private float quanity, itemTotalAmountWithoutVAT, unitPrice, vatPercentage, vatAmount, itemDscnAmnt;
        private string itemName, unitName;
        public Item()
        {
            this.lineNumber = 0;
            this.quanity = 0;
            this.itemTotalAmountWithoutVAT = 0;
            this.unitPrice = 0;
            this.vatPercentage = 0;
            this.vatAmount = 0;
            this.itemDscnAmnt = 0;
            this.itemName = "";
            this.unitName = "";
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
