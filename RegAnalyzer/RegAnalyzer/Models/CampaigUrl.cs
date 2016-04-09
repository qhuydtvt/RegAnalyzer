using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CampaignUrl
    {
        [XmlElement(ElementName = "SourceUrl")]
        public string SourceUrl { get; set; }

        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "ShortenedUrl")]
        public string ShortenedUrl { get; set; }

        public static void GenerateUrls(CampaignUrl campaignUrl, string campaignName)
        {
            campaignUrl.Url = NetUtil.BuildRegLink(campaignName, campaignUrl.SourceUrl);
            campaignUrl.ShortenedUrl = NetUtil.BitlyService.Shorten(campaignUrl.Url);
        }
    }
}
