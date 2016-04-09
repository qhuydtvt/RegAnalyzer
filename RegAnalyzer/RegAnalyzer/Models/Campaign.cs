using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class Campaign
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "CampaignUrls")]
        public List<CampaignUrl> CampaignUrls { get; set; }

        public Campaign()
        {
            CampaignUrls = new List<CampaignUrl>();
        }
    }
}
