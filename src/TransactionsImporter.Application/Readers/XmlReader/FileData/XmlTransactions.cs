using System.Xml.Serialization;

namespace TransactionsImporter.Application.Readers.XmlReader.FileData
{
    public class XmlTransactions
    {
        [XmlElement("Transactions")]
        public XmlTransaction[] Transactions { get; set; }
    }
}