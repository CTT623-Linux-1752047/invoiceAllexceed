using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace testReadInfo
{
    class ListItem
    {
        List<Item> items;

        public ListItem() {
            this.items = new List<Item>() ;
        }
        public List<Item> Item
        {
            get { return this.items; }
        }
        public void getInfoFromPath(string path, XmlNamespaceManager namespaceManager)
        {
            XElement xelement = XElement.Load(path);
            XElement rootItem = xelement.XPathSelectElement("./inv:invoiceData/inv:items", namespaceManager);
            IEnumerable<XElement> listItems = rootItem.Elements();
            foreach(XElement item in listItems)
            {
                Item temp = new Item();
                XElement stt = item.XPathSelectElement("./inv:lineNumber", namespaceManager);
                XElement itemName = item.XPathSelectElement("./inv:itemName", namespaceManager);
                XElement unitName = item.XPathSelectElement("./inv:unitName", namespaceManager);
                XElement quanity = item.XPathSelectElement("./inv:quanyity", namespaceManager);
                XElement itemTotalAmountWithoutVAT = item.XPathSelectElement("./inv:itemTotalAmountWithoutVAT", namespaceManager);
                XElement vatAmount = item.XPathSelectElement("./inv:vatAmount", namespaceManager);
                XElement vatPercentage = item.XPathSelectElement("./inv:vatPercentage", namespaceManager);
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
                if (quanity == null)
                    temp.Quanity = 0;
                else
                    temp.Quanity = int.Parse(quanity.Value);
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
        private float quanity, itemTotalAmountWithoutVAT, unitPrice, vatPercentage, vatAmount;
        private string itemName, unitName ; 

        public Item()
        {

        }
        public Item(long stt, float quanity,float itemTotalAmountWithoutVAT, 
                    float unitPrice, float vatPercentage, float vatAmount, 
                    string itemName, string unitName)
        {
            this.lineNumber = stt;
            this.quanity = quanity;
            this.itemTotalAmountWithoutVAT = itemTotalAmountWithoutVAT;
            this.unitPrice = unitPrice;
            this.vatPercentage = vatPercentage;
            this.vatAmount = vatAmount;
            this.itemName = itemName;
            this.unitName = unitName;
        }
        public Item(Item item){
            this.lineNumber = item.lineNumber;
            this.quanity = item.quanity;
            this.itemTotalAmountWithoutVAT = item.itemTotalAmountWithoutVAT;
            this.unitPrice = item.unitPrice;
            this.vatPercentage = item.vatPercentage;
            this.vatAmount = item.vatAmount;
            this.itemName = item.itemName;
            this.unitName = item.unitName;
        }
        public long LineNumber
        {
            set { this.lineNumber = value; }
            get { return this.lineNumber;  }
        }
        public float Quanity
        {
            set { this.quanity = value; }
            get { return this.quanity;  }
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
        public string ItemName
        {
            set { this.itemName = value; }
            get { return this.itemName;  }
        }
        public string UnitName
        {
            set { this.unitName = value; }
            get { return this.unitName;  }
        }
    }
}
