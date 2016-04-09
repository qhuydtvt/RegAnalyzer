using Newtonsoft.Json;
using RegAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using RegAnalyzer.Utils;
using RegAnalyzer.ViewModels;
using System.Net;
using System.IO;

namespace RegAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainVM mainVM
        {
            get
            {
                return this.layoutRoot.DataContext as MainVM;
            }
        }

        public MainWindow() 
        {
            InitializeComponent();

            Closing += (sender, e) => { mainVM.Save(); };

            Activate();

            var classifier = CampaignUrlClassifierList.Inst;

            //var token = NetUtil.GetFBAccessToken();

            //FBAuthenticateWindow wnd = new FBAuthenticateWindow();
            //wnd.ShowDialog();

            //string url = NetUrl.BuildAPIUrlByCampaign("big");

            //var content = Net.LoadInnerTextFromWebPage(url);

            ////Console.WriteLine(content);

            //var regDataList = RegisterDataList.ParseFromJson(content);

            //var campaignStatList = RegisterDataList.AnalyzeBySource(regDataList.List);

            //var fbRegDataList = RegisterDataList.GetRegDataBySourceType(regDataList.List,
            //    "fb");

            //var campaignList = new CampaignList();
            //campaignList.List.Add(new Campaign() { Name = "test" });
            //campaignList.List.Add(new Campaign() { Name = "big" });

            //CampaignList.SaveToFile("Campaign.xml", campaignList);

            //var campaignList = CampaignList.LoadFromFile("Campaign.xml");
        }
    }
}
