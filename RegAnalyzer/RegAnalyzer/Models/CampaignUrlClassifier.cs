using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CampaignUrlClassifier
    {
        [XmlAttribute(AttributeName = "Pattern")]
        public string Pattern { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "Subtype")]
        public string Subtype { get; set; }

        [XmlAttribute(AttributeName = "Tag")]
        public string Tag { get; set; }

        public bool Match(string url)
        {
            return url.ToLower().Contains(Pattern.ToLower());
        }
    }
}
