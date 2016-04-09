using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class RegisterData
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "submitted_time")]
        public string SubmittedTime { get; set; }
        
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "facebook")]
        public string Facebook { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "feedback")]
        public string Feedback { get; set;}

        [JsonProperty(PropertyName = "presenter")]
        public string Presenter { get; set; }

        [JsonProperty(PropertyName = "purpose")]
        public string Purpose { get; set; }

        [JsonProperty(PropertyName = "learn_before")]
        public string LearnBefore { get; set; }

        [JsonProperty(PropertyName = "know_by")]
        public string KnowBy { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "source_type")]
        public string SourceType { get; set; }

        [JsonProperty(PropertyName = "campaign")]
        public string Campaign { get; set; }

        /*Format 0000-00-00 00:00:00 */

        private static readonly string DATE_TIME_FORMAT = "yyyy-mm-dd hh:mm:ss";
        private static readonly string TIME_FORMAT = "hh:mm:ss";
        private static readonly int TIME_INTERVAL = 1;
        public static String ClassifyTime(RegisterData data)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            
            DateTime datetime = DateTime.ParseExact(data.SubmittedTime.Split(' ').Last(), TIME_FORMAT, cultureInfo,DateTimeStyles.None);

            for (int hour = 0; hour <= 23; hour += TIME_INTERVAL)
            {
                if (hour <= datetime.Hour && datetime.Hour < hour + TIME_INTERVAL)
                {
                    return String.Format("{0}-{1} h", hour, hour + TIME_INTERVAL);
                }
            }
            return "";
        }
    }
}
