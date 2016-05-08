using RegAnalyzer.Models;
using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class RegisterInsightVM : BaseVM
    {
        public List<RegisterData> ListOfRegisterData { get; private set; }

        public int SubmissionCount
        {
            get {
                if (ListOfRegisterData == null) return 0;
                else return ListOfRegisterData.Count();
            }
        }

        public ObservableCollection<RegisterStatBySource> RegisterStatsBySourceType { get; private set; }

        public ObservableCollection<RegisterStatBySource> RegisterStatsFromWeb { get; private set; }

        public ObservableCollection<RegisterStatBySource> RegisterStatsFromFB { get; private set; }

        public ObservableCollection<RegisterStatBySource> RegisterStatsFromFBFanpage { get; private set; }

        public ObservableCollection<RegisterStatBySource> RegisterStatsFromFBGroup { get; private set; }

        public ObservableCollection<RegisterStatBySource> RegisterStatsFromFBPersonal { get; private set; }

        public ObservableCollection<RegisterDataByTime> RegisterStatsByTime { get; private set; }

        public RegisterInsightVM() {
        }

        public void Load(CampaignVM campaignVM)
        {
            Console.Write("Downloading register data...");
            var regDataList = RegisterDataList.ParseFromJson(
                NetUtil.DownloadCampaignWebpage(campaignVM.Name));
            Console.WriteLine("Done");
            ListOfRegisterData = regDataList.List;
            _notify("ListOfRegisterData");
            
            Console.Write("Analyzing register data...");
            CampaignUrlClassifierList campaignClassifierList = CampaignUrlClassifierList.Inst;

            IEnumerable<RegisterData> fbRegList = 
                from regData in regDataList.List
                where campaignClassifierList.GetGeneralType(regData.Source) 
                    == CampaignUrlClassifierList.FACEBOOK
                select regData;

            IEnumerable<RegisterData> webRegList =
                from regData in regDataList.List
                where campaignClassifierList.GetGeneralType(regData.Source)
                    == CampaignUrlClassifierList.WEB
                select regData;

            IEnumerable<RegisterData> fbFanpageRegList =
                from regData in fbRegList
                where campaignClassifierList.GetFBSubType(regData.Source)
                    == CampaignUrlClassifierList.FACEBOOK_FANPAGE
                select regData;

            IEnumerable<RegisterData> fbGroupRegList =
                from regData in fbRegList
                where campaignClassifierList.GetFBSubType(regData.Source)
                    == CampaignUrlClassifierList.FACEBOOK_GROUP
                select regData;

            IEnumerable<RegisterData> fbPersonalRegList =
                from regData in fbRegList
                where campaignClassifierList.GetFBSubType(regData.Source)
                    == CampaignUrlClassifierList.FACEBOOK_PERSONAL
                select regData;

            RegisterStatsBySourceType = new ObservableCollection<RegisterStatBySource>
                (RegisterDataList.GroupBySource(regDataList.List));

            RegisterStatsFromWeb = new ObservableCollection<RegisterStatBySource>
                (RegisterDataList.GroupByBaseUrl(webRegList));

            RegisterStatsFromFB = new ObservableCollection<RegisterStatBySource>
                (RegisterDataList.GroupByFBType(fbRegList));

            RegisterStatsFromFBFanpage = new ObservableCollection<RegisterStatBySource>
                (from regData in fbFanpageRegList
                  group regData by campaignClassifierList.GetTag(regData.Source) into fanpage
                  select new RegisterStatBySource(fanpage.Key, fanpage.Count())
                );

            RegisterStatsFromFBGroup  = new ObservableCollection<RegisterStatBySource>
                (from regData in fbGroupRegList
                 group regData by campaignClassifierList.GetTag(regData.Source) into _group
                 select new RegisterStatBySource(_group.Key, _group.Count())
                );

            RegisterStatsFromFBPersonal = new ObservableCollection<RegisterStatBySource>
                (from regData in fbPersonalRegList
                 group regData by campaignClassifierList.GetPartOfUrl(regData.Source) into _group
                 select new RegisterStatBySource(_group.Key, _group.Count())
                );

            RegisterStatsByTime = new ObservableCollection<RegisterDataByTime>(
                from regData in regDataList.List
                group regData by RegisterData.ClassifyTime(regData) into  _group
                select new RegisterDataByTime(_group.Key, _group.Count())
                );

            _notify("RegisterStatsBySourceType");
            _notify("RegisterStatsFromWeb");
            _notify("RegisterStatsFromFB");
            _notify("RegisterStatsFromFBFanpage");
            _notify("RegisterStatsFromFBGroup");
            _notify("RegisterStatsFromFBPersonal");
            _notify("RegisterStatsByTime");
            _notify("SubmissionCount");
            Console.WriteLine("Done");
        }
    }
}
