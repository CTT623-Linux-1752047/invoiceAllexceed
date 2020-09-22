using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace invoiceX
{
    class ListItem
    {
        List<Item> items;

        public ListItem()
        {
            this.items = new List<Item>();
        }
        public List<Item> Item
        {
            get { return this.items; }
        }
        public bool checkColumnDiscount()
        {
            bool flag = false; 
            foreach(Item item in this.items)
            {
                if (item.ItemDscnAmnt == 0)
                    flag = true;
            }
            return flag;
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager)
        {
            XElement xelement = XElement.Load(path);
            XElement rootItem = xelement.XPathSelectElement("./inv:invoiceData/inv:items", namespaceManager);
            IEnumerable<XElement> listItems = rootItem.Elements();
            foreach (XElement item in listItems)
            {
                Item temp = new Item();
                XElement stt = item.XPathSelectElement("./inv:lineNumber", namespaceManager);
                XElement itemName = item.XPathSelectElement("./inv:itemName", namespaceManager);
                XElement unitName = item.XPathSelectElement("./inv:unitName", namespaceManager);
                XElement quantity = item.XPathSelectElement("./inv:quantity", namespaceManager);
                XElement itemTotalAmountWithoutVAT = item.XPathSelectElement("./inv:itemTotalAmountWithoutVat", namespaceManager);
                XElement vatAmount = item.XPathSelectElement("./inv:vatAmount", namespaceManager);
                XElement vatPercentage = item.XPathSelectElement("./inv:vatPercentage", namespaceManager);
                XElement discountAmount = item.XPathSelectElement("./inv:ItemDscnAmount", namespaceManager);
                XElement unitPrice = item.XPathSelectElement("./inv:unitPrice", namespaceManager);

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
                this.items.Add(temp);
            }
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
