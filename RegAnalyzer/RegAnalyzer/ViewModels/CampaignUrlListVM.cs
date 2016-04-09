using RegAnalyzer.Models;
using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegAnalyzer.ViewModels
{
    public class CampaignUrlListVM
    {
        public List<CampaignUrlVM> CampaignUrlVMList { get; private set; }

        private Campaign campaign;

        public CampaignUrlListVM(Campaign campaign)
        {
            this.campaign = campaign;
            //CampaignUrlVMList = new List<CampaignUrlVM>(
                
        }
    }
}
