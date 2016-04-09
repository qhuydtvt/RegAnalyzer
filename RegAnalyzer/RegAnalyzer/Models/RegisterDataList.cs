using Newtonsoft.Json;
using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.Models
{
    public class RegisterDataList
    {
        [JsonProperty(PropertyName = "items")]
        public List<RegisterData> List { get; set; }

        public List<RegisterData> GetListBySourceType(string sourceType)
        {
            return (from regData in List
                    where regData.SourceType.Equals(sourceType)
                    select regData).ToList();
        }

        public static List<RegisterStatBySource> GroupBySource(List<RegisterData> RegDataList)
        {
            var campainStatList = from regData in RegDataList
                    group regData by CampaignUrlClassifierList.Inst.GetGeneralType(regData.Source) into regDataGroup
                    select new RegisterStatBySource(
                        regDataGroup.Key,
                        regDataGroup.Count());
            return  campainStatList.ToList();
        }

        public static List<RegisterStatBySource> GroupByBaseUrl(IEnumerable<RegisterData> RegDataList)
        {
            var campainStatList = from regData in RegDataList
                                  group regData by NetUtil.GetRootDomain(regData.Source) into regDataGroup
                                  select new RegisterStatBySource (
                                      regDataGroup.Key,
                                      regDataGroup.Count());
            return campainStatList.ToList();
        }

        public static List<RegisterStatBySource> GroupByFBType(IEnumerable<RegisterData> RegDataList)
        {
            var campainStatList = from regData in RegDataList
                                  group regData by CampaignUrlClassifierList.Inst.GetFBSubType(regData.Source) into regDataGroup
                                  select new RegisterStatBySource(
                                      regDataGroup.Key,
                                      regDataGroup.Count());
            return campainStatList.ToList();
        }

        public static List<RegisterStatBySource> GroupByFBSubType(List<RegisterData> RegDataList)
        {
            var campainStats = from regData in RegDataList
                                  group regData by NetUtil.GetFBType(regData.Source) into regDataGroup
                                  select new RegisterStatBySource(
                                      regDataGroup.Key,
                                      regDataGroup.Count());
            return campainStats.ToList();
        }


        public static List<RegisterData> GetRegDataBySourceType(List<RegisterData> RegDataList, String sourceType)
        {
            return (from regData in RegDataList
                   where regData.SourceType.Equals(sourceType)
                   select regData).ToList();
        }

        public static RegisterDataList ParseFromJson(String json)
        {
            return JsonConvert.DeserializeObject<RegisterDataList>(json);
        }
    }
}
