using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class StravaUri
    {
        public const string AuthorizationUri = "https://www.strava.com/oauth/authorize?" 
            + "client_id=" + AuthSettings.ClientId 
            + "&response_type=code" 
            + "&redirect_uri=" + AuthSettings.RedirectUri
            + "&scope=" + AuthSettings.Scope
            + "&state=329059"
            + "&approval_prompt=auto";

        public const string TokenUri = "https://www.strava.com/oauth/token";

        public const string LogoutUri = "https://www.strava.com/oauth/deauthorize";
    }
}
