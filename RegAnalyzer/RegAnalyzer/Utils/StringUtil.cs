using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Utils
{
    public static class StringUtil
    {
        public const char STRING_DELIMITER_NEW_LINE = '\n';

        public static string Combine(IEnumerable<string> strings, char delimiter)
        {
            if (strings.Count() == 0) return "";
            return strings.Aggregate<string> ( 
                (current, next) => current + delimiter + next);
        }

        public static List<String> Split(string combinedString, char delimiter)
        {
            return (from s in combinedString.Split(delimiter)
                    where (s.Trim() != null && s.Trim() != "")
                           select s).ToList();
        }
    }
}
