using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StravaUWP.Pages
{
    using Newtonsoft.Json;
    using SharedLibrary;
    using SharedLibrary.Constants;
    using SharedLibrary.Helper;
    using SharedLibrary.ViewModel;
    using Helper;
    using Windows.Storage;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            this.InitializeComponent();
           
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Profile = new ProfileViewModel();
            Profile.LoadAthleteInfo();
            Profile.RefreshAthleteInfo();
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localFolder = applicationData.LocalFolder;
            StorageFile sampleFile = await localFolder.GetFileAsync("sample.gpx");
            //await GenericHelpers.UploadActivity(sampleFile.Path, "sample.gpx");
            this.DataContext = Profile;
        }   
        
        public ProfileViewModel Profile { get; set; }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthSettings.ScopeAccessToken = null;
        }
    }
}
