using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TransactionsImporter.Application.Readers.XmlReader.FileData
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "Transactions", Namespace = "", IsNullable = false)]
    public class XmlTransactions
    {
        [XmlElement("Transaction")]
        public XmlTransaction[] Transactions { get; set; }
    }
}