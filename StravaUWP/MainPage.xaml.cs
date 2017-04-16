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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StravaUWP
{
    using Helper;
    using SharedLibrary;
 
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(typeof(Pages.ProfilePage));
        }

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(typeof(Pages.FeedPage));
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(typeof(Pages.RecordActivity));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(typeof(Pages.ProfilePage));
        }
    }
}
