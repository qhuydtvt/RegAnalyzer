using RegAnalyzer.Models;
using RegAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class CampaignVM : BaseVM
    {
        private Campaign campaign;
        public ICommand CmdGenerateLinks { get; private set; }

        public CampaignVM(Campaign campaign)
        {
            this.campaign = campaign;
            CmdGenerateLinks = new RelayCommand(GenerateLinks);
            campaignUrlCollection = new ObservableCollection<CampaignUrl>(campaign.CampaignUrls);
        }

        public string Name { get { return campaign.Name; } set { campaign.Name = value; } }

        private ObservableCollection<CampaignUrl> campaignUrlCollection;
        public ObservableCollection<CampaignUrl> CampaignUrlCollection
        {
            get { return campaignUrlCollection; }
            set { campaignUrlCollection = value; }
        }

        //public string SourcesString
        //{
        //    get
        //    {
        //        return StringUtil.Combine(
        //            campaign.SourceList,
        //            StringUtil.STRING_DELIMITER_NEW_LINE);
        //    }
        //    set
        //    {
        //        campaign.SourceList.Clear();
        //        campaign.SourceList.AddRange(StringUtil.Split(
        //            value,
        //            StringUtil.STRING_DELIMITER_NEW_LINE));
        //    }
        //}

        //public string UrlsString
        //{
        //    get
        //    {
        //        return StringUtil.Combine(campaign.UrlList, StringUtil.STRING_DELIMITER_NEW_LINE);
        //    }
        //    set
        //    {
        //        campaign.UrlList.Clear();
        //        campaign.UrlList.AddRange(
        //            StringUtil.Split(value, StringUtil.STRING_DELIMITER_NEW_LINE));
        //    }
        //}

        //public String ShortenedUrlsString
        //{
        //    get
        //    {
        //        return StringUtil.Combine(campaign.ShortenedUrlList,
        //            StringUtil.STRING_DELIMITER_NEW_LINE);
        //    }
        //    set
        //    {
        //        campaign.ShortenedUrlList.Clear();
        //        campaign.ShortenedUrlList.AddRange(
        //            StringUtil.Split(value, StringUtil.STRING_DELIMITER_NEW_LINE));
        //    }
        //}

        //public ObservableCollection<CampaignUrlVM> CampaignUrlVMs { get; private set; }

        public void GenerateLinks(Object obj)
        {
            //if (campaign.SourceList.Count == 0) return;

            //campaign.UrlList.Clear();
            //campaign.ShortenedUrlList.Clear();

            //campaign.UrlList.AddRange(
            //    from source in campaign.SourceList
            //    select NetUtil.BuildRegLink(campaign.Name, source)
            //    );

            //campaign.ShortenedUrlList.AddRange(
            //    from url in campaign.UrlList
            //    where url != null && url != ""
            //    select NetUtil.BitlyService.Shorten(url)
            //    );

            //var campaignUrlVMs =  campaign.SourceList.Select<string, CampaignUrlVM>(
            //    sourceUrl => {
            //        string url = NetUtil.BuildRegLink(campaign.Name, sourceUrl);
            //        string shortenedUrl = NetUtil.BitlyService.Shorten(url);
            //        return new CampaignUrlVM() {
            //            SourceUrl = sourceUrl,
            //            Url = url,
            //            ShortenedUrl = shortenedUrl
            //        };
            //    });

            //CampaignUrlVMs = new ObservableCollection<CampaignUrlVM>(campaignUrlVMs);

            try
            {
                campaign.CampaignUrls.Clear();

                foreach (CampaignUrl campaignUrl in campaignUrlCollection)
                {
                    CampaignUrl.GenerateUrls(campaignUrl, campaign.Name);
                    campaign.CampaignUrls.Add(campaignUrl);
                }
                campaignUrlCollection = new ObservableCollection<CampaignUrl>(campaign.CampaignUrls);

                _notify("UrlsString");
                _notify("CampaignUrlCollection");
            }
            catch(Exception e)
            {
                Console.WriteLine(" " + e.Message);
            }
        }
    }
}
