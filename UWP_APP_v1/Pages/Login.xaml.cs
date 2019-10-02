using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_APP_v1.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_APP_v1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private string LOGIN_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/authentication";
        public Login()
        {
            this.InitializeComponent();
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("sample.txt").GetAwaiter().GetResult();
        }

        //login 
        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var memberLogin = new MemberLogin()
            {
                email = this.Email.Text,
                password = this.Pass.Password
            };

            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var responseContent = client.PostAsync(LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync().Result;
            JObject jsonJObject = JObject.Parse(responseContent);
            Debug.WriteLine(jsonJObject["token"]);



        }

        // method reset form login
        private void ButtonReset_OnClick(Object sender, RoutedEventArgs e)
        {
            this.Email.Text = string.Empty;
            this.Pass.Password = string.Empty;
        }

        private void RegisterButtonTextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }
    }
}
