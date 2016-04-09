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
using System.Windows.Shapes;
using System.Web;
using System.Diagnostics;

namespace RegAnalyzer
{
    /// <summary>
    /// Interaction logic for FBAuthenticateWindow.xaml
    /// </summary>
    public partial class FBAuthenticateWindow : Window
    {
        public String AppID = "1097955463600030";
        public String AccessToken { get; set; }
        public FBAuthenticateWindow()
        {
            InitializeComponent();
            this.Loaded += FBAuthenticateWindow_Loaded;
            this.webBrowser.Navigated += WebBrowser_Navigated;
            this.webBrowser.Navigating += WebBrowser_Navigating;
        }

        private void FBAuthenticateWindow_Loaded(object sender, RoutedEventArgs e)
        {
            webBrowser.MessageHook += webBrowser_MessageHook;

            //Delete the cookies since the last authentication
            DeleteFacebookCookie();

            //Create the destination URL
            var destinationURL = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&scope={1}&display=popup&redirect_uri=http://www.facebook.com/connect/login_success.html&response_type=token",
               AppID, //client_id
               "email,user_birthday" //scope
               
            );

            webBrowser.Navigate(destinationURL);
        }

        private void DeleteFacebookCookie()
        {
            //Set the current user cookie to have expired yesterday
            string cookie = String.Format("c_user=; expires={0:R}; path=/; domain=.facebook.com", DateTime.UtcNow.AddDays(-1).ToString("R"));
            Application.SetCookie(new Uri("https://www.facebook.com"), cookie);
        }

        private void WebBrowser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.Uri.LocalPath == "/r.php")
            {
                MessageBox.Show("To create a new account go to www.facebook.com", "Could Not Create Account", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }
        }

        IntPtr webBrowser_MessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //msg = 130 is the last call for when the window gets closed on a window.close() in javascript
            if (msg == 130)
            {
                this.Close();
            }
            return IntPtr.Zero;
        }

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var url = e.Uri.Fragment;
            if (url.Contains("access_token") && url.Contains("#"))
            {
                url = (new System.Text.RegularExpressions.Regex("#")).Replace(url, "?", 1);

                //HttpUtility.
                //AccessToken = HttpUtility.ParseQueryString(url).Get("access_token");
                DialogResult = true;
                this.Close();
            }
        }
    }
}
