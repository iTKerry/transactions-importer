using System;
using System.Xml.Serialization;

namespace TransactionsImporter.Application.Readers.XmlReader.FileData
{
    public class XmlTransaction
    {
        [XmlAttribute]
        public string Id { get; set; }

        public DateTime? TransactionDate { get; set; }
        public XmlPaymentDetails PaymentDetails { get; set; }
        public string Status { get; set; }
    }
}