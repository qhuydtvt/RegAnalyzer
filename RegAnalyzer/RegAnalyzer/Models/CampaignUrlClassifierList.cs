using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CampaignUrlClassifierList
    {
        public const string XML_FILE_NAME = "CampaignUrlClassifier.xml";
        public const string FACEBOOK = "Facebook";
        public const string WEB = "Web";
        public const string FACEBOOK_FANPAGE = "Fanpage";
        public const string FACEBOOK_GROUP = "Group";
        public const string FACEBOOK_PERSONAL = "Personal";
        public const string OTHERS = "Others";

        [XmlElement(ElementName = "ClassifierList")]
        public List<CampaignUrlClassifier> List;

        public CampaignUrlClassifierList()
        {
            List = new List<CampaignUrlClassifier>();
        }

        public void Save()
        {
            SaveToFile(XML_FILE_NAME, this);
        }

        public String GetGeneralType(string url)
        {
            if(url.Contains("www.facebook.com"))
            {
                return FACEBOOK;
            }
            return WEB;
        }

        public String GetFBSubType(string url)
        {
            if (url.ToLower().Contains("/groups/"))
            {
                return FACEBOOK_GROUP;
            }
            foreach(var cf in List)
            {
                if (cf.Match(url)) return FACEBOOK_FANPAGE;
            }
            return FACEBOOK_PERSONAL;
        }

        public String GetTag(string url)
        {
            foreach (var cf in List)
            {
                if (cf.Match(url)) return cf.Tag;
            }
            return OTHERS;
        }

        public String GetPartOfUrl(string url)
        {
            return url.Split('/').Last();
        }

        private static CampaignUrlClassifierList inst;
        public static CampaignUrlClassifierList Inst
        {
            get
            {
                if(inst == null)
                {
                    if (File.Exists(XML_FILE_NAME))
                    {
                        inst = LoadFromFile(XML_FILE_NAME);
                    }
                    else
                    {
                        inst = new CampaignUrlClassifierList();
                    }
                }
                return inst;
            }
        }

        public static void SaveToFile(string fileName, CampaignUrlClassifierList classifierList)
        {
            var xmlSerializer = new XmlSerializer(typeof(CampaignUrlClassifierList));
            var streamWriter = new StreamWriter(fileName);
            xmlSerializer.Serialize(streamWriter, classifierList);
            streamWriter.Close();
        }

        public static CampaignUrlClassifierList LoadFromFile(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(CampaignUrlClassifierList));
            var streamReader = new StreamReader(fileName);
            var classifierList = xmlSerializer.Deserialize(streamReader) as CampaignUrlClassifierList;
            streamReader.Close();
            return classifierList;
        }
    }
}
