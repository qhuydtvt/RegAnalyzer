using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CourseUrlList
    {
        public const String XML_FILE_NAME = "CourseUrl.xml";

        [XmlElement(ElementName = "CourseUrl")]
        public List<CourseUrl> List;

        public CourseUrl SelectedCourseUrl { get; set; }

        public CourseUrlList()
        {
            List = new List<CourseUrl>();
        }

        private static CourseUrlList inst;
        public static CourseUrlList Inst
        {
            get
            {
                if(inst == null)
                {
                    if (File.Exists(XML_FILE_NAME))
                        inst = LoadFromFile(XML_FILE_NAME);
                    else
                        inst = new CourseUrlList();
                }
                return inst;
            }
        }

        public void Save()
        {
            SaveToFile(XML_FILE_NAME, this);
        }

        public static void SaveToFile(string fileName, CourseUrlList courseUrlList)
        {
            var xmlSerializer = new XmlSerializer(typeof(CourseUrlList));
            var streamWriter = new StreamWriter(fileName);
            xmlSerializer.Serialize(streamWriter, courseUrlList);
            streamWriter.Close();
        }

        public static CourseUrlList LoadFromFile(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(CourseUrlList));
            var streamReader = new StreamReader(fileName);
            var courseUrlList = xmlSerializer.Deserialize(streamReader) as CourseUrlList;            
            streamReader.Close();
            return courseUrlList;
        }
    }
}
