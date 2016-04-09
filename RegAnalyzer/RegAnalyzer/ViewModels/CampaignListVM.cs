using RegAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class CampaignListVM : BaseVM
    {
        private CampaignList campaignList;

        public String CampaignNameInput { get; set; }

        public ICommand CmdAddNewCampagin { get; private set; }

        public List<CampaignVM> VMs
        {
            get
            {
                return 
                    (from campaign in campaignList.List
                     select new CampaignVM(campaign)).ToList();
            }
        }

        public CampaignVM SeletedCampaignVM { get; set; }

        public CampaignListVM()
        {
            campaignList = CampaignList.Inst;
            CmdAddNewCampagin = new RelayCommand(AddNewCampaign);
        }

        public void AddNewCampaign(Object obj)
        {
            if(this.CampaignNameInput != null && CampaignNameInput != "")
            {
                campaignList.List.Add(new Campaign() { Name = CampaignNameInput });
                _notify("VMs");
            }
        }
        
        public void Save()
        {
            campaignList.Save();
        }
    }
}
