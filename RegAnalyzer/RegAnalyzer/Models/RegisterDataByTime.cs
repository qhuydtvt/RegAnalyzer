using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class RegisterDataByTime
    {
        public string Time { get; set; }
        public int Count { get; set; }

        public RegisterDataByTime (string time,  int count)
        {
            Time = time;
            Count = count;
        }
    }
}
