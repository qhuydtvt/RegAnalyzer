using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CampaignList
    {
        public const String XML_FILE_NAME = "Campaign.xml";

        public List<Campaign> List { get; }
        private CampaignList()
        {
            List = new List<Campaign>();
        }

        public void Save()
        {
            SaveToFile(XML_FILE_NAME, this);
        }

        private static CampaignList inst;
        public static CampaignList Inst
        {
            get
            {
                if(inst  == null)
                {
                    if (File.Exists(XML_FILE_NAME))
                        inst = LoadFromFile(XML_FILE_NAME);
                    else
                        inst = new CampaignList();
                }
                return inst;
            }
        }

        public static void SaveToFile(string fileName, CampaignList campaignList)
        {
            var xmlSerializer = new XmlSerializer(typeof(CampaignList));
            var streamWriter = new StreamWriter(fileName);
            xmlSerializer.Serialize(streamWriter, campaignList);
            streamWriter.Close();
        }

        public static CampaignList LoadFromFile(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(CampaignList));
            var streamReader = new StreamReader(fileName);
            var campaignList = xmlSerializer.Deserialize(streamReader) as CampaignList;
            streamReader.Close();
            return campaignList;
        }
    }
}
