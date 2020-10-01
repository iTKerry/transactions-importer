using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TransactionsImporter.Application.Readers.XmlReader.FileData
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class XmlPaymentDetails
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}