using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegAnalyzer.Models
{
    public class CourseUrl
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set;}

        [XmlAttribute(AttributeName = "RegUrl")]
        public string RegUrl { get; set; }

        [XmlAttribute(AttributeName = "ApiUrl")]
        public string ApiUrl { get; set; }
    }
}
