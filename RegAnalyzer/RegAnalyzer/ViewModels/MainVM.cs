using RegAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class MainVM : BaseVM
    {
        public CampaignListVM CampaignListVM { get; private set; }
        public RegisterInsightVM RegisterInsightVM { get; private set; }
        public CampaignVM SelectedCampaignVM { get; private set; }
        public ClickCountData ClickCountData { get; private set; }

        public ICommand CmdLoadRegisterData { get; private set; }
        public bool LoadRegisterDataEnabled
        {
            get
            {
                return CampaignListVM.SeletedCampaignVM != null;
            }
        }
        
        public MainVM()
        {
            CampaignListVM = new CampaignListVM();
            RegisterInsightVM = new RegisterInsightVM();
            ClickCountData = ClickCountData.Inst;
            CmdLoadRegisterData = new RelayCommand((obj) =>
            {
                if(CampaignListVM.SeletedCampaignVM == null)
                {
                    _showMessagge("You must specify campaign first", "Load regsiter data");
                } else {
                    RegisterInsightVM.Load(CampaignListVM.SeletedCampaignVM);
                    _notify("RegisterInsightVM");
                    _notify("ClickCountData");
                }
            });
        }

        public void Save()
        {
            CampaignListVM.Save();
        }
    }
}
