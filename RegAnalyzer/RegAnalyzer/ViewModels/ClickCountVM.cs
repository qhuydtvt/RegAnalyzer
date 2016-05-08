using RegAnalyzer.Models;
using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class ClickCountVM : BaseVM
    {
        private ClickCountData clickCountData;

        public ClickCountVM()
        {

        }

        public int ClickCount
        {
            get
            {
                if (clickCountData != null)
                    return clickCountData.Count;
                else return 0;
            }

        }

        public void Load(CampaignVM campaignVM)
        {
            string campaignName = campaignVM.Name;
            string json = NetUtil.DownloadClickCountWebpage(campaignName);
            if (json == "null") { clickCountData = new ClickCountData() { Count = 0 }; }
            else
            {
                clickCountData = ClickCountData.ParseFromJson(json);
            }
            _notify("ClickCount");
        }   
    }
}
