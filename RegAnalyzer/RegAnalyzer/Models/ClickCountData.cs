using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class ClickCountData
    {
        [JsonProperty(PropertyName = "click_counts")]
        public int Count { get; set; }

        public static ClickCountData ParseFromJson(string json)
        {
            return JsonConvert.DeserializeObject<ClickCountData>(json);
        }
    }
}
