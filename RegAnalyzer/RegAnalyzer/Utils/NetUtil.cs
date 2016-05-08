using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using BitlyDotNET.Implementations;
using RegAnalyzer.Models;

namespace RegAnalyzer.Utils
{
    public static class NetUtil
    {
        //public static string REG_ROOT = "http://iliat.org/register/?";
        //public static string API_URL_REGISTER_ROOT = "http://iliat.org/register/api/register/?";    
        //public static string API_URL_CLICK_COUNT_ROOT = "http://iliat.org/register/api/click_counts/?";

        public static string REG_ROOT
        {
            get
            {
                return CourseUrlList.Inst.SelectedCourseUrl.RegUrl;
            }
        }
        public static string API_URL_REGISTER_ROOT
        {
            get
            {
                return CourseUrlList.Inst.SelectedCourseUrl.ApiUrl;
            }
        }

        public static string API_URL_CLICK_COUNT_ROOT = "http://iliat.org/register/api/click_counts/?";

        public const string API_URL_CLICK_COUNT_PARAMS = "campaign={0}";
        public const string API_FB_AUTH_ROOT = "https://graph.facebook.com/oauth/access_token?";

        public const string API_URL_CLICK_COUNT_FORMAT = "http://iliat.org/register/api/click_counts/?" + API_URL_CLICK_COUNT_PARAMS;

        public static string API_URL_REGISTER_DATA_FORMAT { get { return API_URL_REGISTER_ROOT + "campaign={0}"; } }
        public static string REG_URL_FORMAT { get { return REG_ROOT + "source={1}&source_type={2}&campaign={0}"; } }

        public const string API_FB_AUTH_FORMAT = API_FB_AUTH_ROOT + "client_id={0}&client_secret={1}&grant_type=client_credentials";

        public const string APP_ID = "1097955463600030";
        public const string APP_SECRET = "d2d8d08cff42d1183a053629680bfdc5";

        public const string SOURCE_TYPE_FACEBOOK = "fb";
        public const string SOURCE_TYPE_WEB = "wb";

        public const string BIT_LY_ID = "iliattools";
        public const string BIT_LY_API_KEY = "R_422cbf162d264b9d95d445b31ba4c0f0";

        private static BitlyService bitlyService;
        public static BitlyService BitlyService
        {
            get
            {
                if(bitlyService == null)
                {
                    bitlyService = new BitlyService(BIT_LY_ID, BIT_LY_API_KEY);
                }
                return bitlyService;
            }
        }

        public static string DownloadWebpage(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = request.GetResponse();

            var reader = new StreamReader(((HttpWebResponse)response).GetResponseStream());
            var content = reader.ReadToEnd();
            reader.Close();

            return content;
        }

        public static string DownloadHTMLInnerText(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = request.GetResponse();

            var reader = new StreamReader(((HttpWebResponse)response).GetResponseStream());
            var content = reader.ReadToEnd();
            reader.Close();

            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);
            var htmlNode = document.DocumentNode.SelectSingleNode("html");

            return htmlNode.InnerText;
        }


        public static string GetFBAccessToken()
        {
            return DownloadWebpage(string.Format(API_FB_AUTH_FORMAT, APP_ID, APP_SECRET)).
                Replace("access_token=","");
        }

        public static String DownloadCampaignWebpage(String campaignName)
        {
            return DownloadHTMLInnerText(BuildAPIRegDataUrl(campaignName.ToLower()));
        }

        public static String DownloadClickCountWebpage(String campaignName)
        {
            return DownloadHTMLInnerText(BuildClickCountAPIUrl(campaignName));
        }

        public static String BuildClickCountAPIUrl(String campaignName)
        {
            return string.Format(API_URL_CLICK_COUNT_FORMAT, campaignName.ToLower());
        }

        public static string BuildAPIRegDataUrl(string campaignName)
        {
            return string.Format(API_URL_REGISTER_DATA_FORMAT, campaignName.ToLower());
        }

        public static string BuildRegLink(string campaignName, string source)
        {
            string sourceType;
            if (isFacebookLink(source))
            {
                sourceType = SOURCE_TYPE_FACEBOOK;
            }
            else
            {
                sourceType = SOURCE_TYPE_WEB;
            }
            return string.Format(REG_URL_FORMAT, campaignName.ToLower(), source.ToLower(), sourceType.ToLower());
        }

        private static bool isFacebookLink(string source)
        {
            return source.Contains("www.facebook.com");
        }

        public static string GetRootDomain(string url)
        {
            var extensions = new[] { ".co.uk", ".com", ".net", ".org", ".vn", ".biz" };//valid domain extensions
            if (url.IndexOf("//") > -1)
                url = url.Substring(url.IndexOf("//") + 2);//remove 'http://', 'https://', 'ftp://' etc etc.
            if (url.IndexOf("/") > 2)
                url = url.Substring(0, url.IndexOf("/")); //remove '/subdir' from 'www.test.com/subdir'
            for (int i = url.Length; i > 0; i--)//work backwards
            {
                var possibleExtension = url.Substring(i);
                if (extensions.Any(a => a.Equals(possibleExtension)))
                {
                    var extension = possibleExtension;
                    var remainingUrl = url.Substring(0, i);
                    var remainingUrlSections = remainingUrl.Split(new char[] { '.', '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (remainingUrlSections.Length > 0)
                    {
                        url = remainingUrlSections[remainingUrlSections.Length - 1] + extension;
                        break;
                    }
                }
            }
            return url;
        }

        public static string GetFBType(string url)
        {
            if (url.ToLower().Contains("/groups/"))
            {
                return "Group";
            }
            else
            {
                return "Personal or Fanpage";
            }
        }


        public static string GetFBSourceType(String url)
        {
            return null;
        }

    }
}
