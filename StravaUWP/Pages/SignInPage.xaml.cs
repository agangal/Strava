﻿using StravaUWP.Helper;
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
    using SharedLibrary;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInPage()
        {
            this.InitializeComponent();
            this.Loaded += SignInPage_Loaded;
        }

        private void SignInPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (AuthSettings.ScopeAccessToken != null)
            {
                Frame RootFrame = Window.Current.Content as Frame;
                RootFrame.Navigate(typeof(MainPage));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);            
        }
        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Results res = await AuthHelper.StravaSigninFlow();
            if (res.result == ResultStatus.Successful)
            {
                Frame RootFrame = Window.Current.Content as Frame;
                RootFrame.Navigate(typeof(MainPage));
            }
        }
    }
}
