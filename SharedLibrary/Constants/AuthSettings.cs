using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace SharedLibrary
{
    public class AuthSettings
    {
        public const string ClientId = "";
       
        public static string ClientSecret = "";

        public static string PublicAccessToken
        {
            get { return ""; }
        }

        public const string Scope = "view_private,write";
        public const string RedirectUri = "ashishgangal.com"; 
        public static string ScopeAccessToken
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values["ScopeAccessToken"] != null)
                {
                    return ApplicationData.Current.LocalSettings.Values["ScopeAccessToken"].ToString();
                }
                return null;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["ScopeAccessToken"] = value;
            }
        }
        public static string AuthorizationCode
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values["AuthorizationCode"] != null)
                {
                    return ApplicationData.Current.LocalSettings.Values["AuthorizationCode"].ToString();
                }
                return null;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["AuthorizationCode"] = value;
            }
        }
    }
}
