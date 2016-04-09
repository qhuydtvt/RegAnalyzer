using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class ClickCountData
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        private static ClickCountData inst;
        public static ClickCountData Inst
        {
            get
            {
                if(inst == null)
                {
                    inst = new ClickCountData();
                }
                return inst;
            }
        }
    }
}
