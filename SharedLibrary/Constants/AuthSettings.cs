using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace SharedLibrary
{
    public class AuthSettings
    {
        public const string ClientId = "17245";

        public const string ClientSecret = "18928d12c615e97bc7b8a450b86da1143d50fe81";
         
        public static string PublicAccessToken
        {
            get { return "a9231b47b519c861a61d03ead814de940e9c9d21"; }
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
