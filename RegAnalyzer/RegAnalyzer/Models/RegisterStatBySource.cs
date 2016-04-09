using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class RegisterStatBySource
    {
        public string Source { get; set; }
        public int Count { get; set; }
        public RegisterStatBySource() { }
        
        public RegisterStatBySource(String source, int count)
        {
            Source = source;
            Count = count;
        }
    }
}
