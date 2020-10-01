using System.Xml.Serialization;

namespace TransactionsImporter.Application.Readers.XmlReader.FileData
{
    [XmlType(AnonymousType = true)]
    public class XmlTransaction
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        public string TransactionDate { get; set; }
        public XmlPaymentDetails PaymentDetails { get; set; }
        public string Status { get; set; }
    }
}