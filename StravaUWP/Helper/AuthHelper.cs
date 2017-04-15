using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaUWP.Helper
{
    using SharedLibrary;
    using Windows.Security.Authentication.Web;
    using Windows.Web.Http;
    using Newtonsoft.Json;
    public class AuthHelper
    {
        public static async Task<Results> StravaSigninFlow()
        {
            Results res = new Results();
            res = await GetAuthorizationCode();
            if (res.result == ResultStatus.Successful)
            {
                res = await GetAccessToken(AuthSettings.AuthorizationCode);
            }
            return res;
        }

        public static async Task<Results> GetAuthorizationCode()
        {
            Results res = new Results();
            res.result = ResultStatus.Successful;
            //string authurl = URIHelper.AUTHORIZATION_CODE_URI + "?client_id=" + Settings.CLIENT_ID + "&response_type=code&scope=offline public rides.read profile rides.request&state=" + Settings.STATE;
            Uri StartUri = new Uri(StravaUri.AuthorizationUri);
            Uri EndUri = new Uri("http://ashishgangal.com/");
            WebAuthenticationResult WebAuthResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, StartUri, EndUri);
            if (WebAuthResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                string responsedata = WebAuthResult.ResponseData.ToString();
                string substring = responsedata.Substring(responsedata.IndexOf("code"));
                string[] keyValuePairs = substring.Split('&');
                string[] splits = keyValuePairs[0].Split('=');
                AuthSettings.AuthorizationCode = splits[1];
                res.data = splits[1];
            }            
            if (WebAuthResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {
                res.result = ResultStatus.Failed;
            }
            return res; 
        }

        public static async Task<Results> GetAccessToken(string authorization_code)
        {
            HttpClient httpClient = new HttpClient();
            Results res = new Results();
            try
            {
                string content = "?client_id=" + AuthSettings.ClientId  + "&client_secret=" + AuthSettings.ClientSecret + "&code=" + authorization_code;
                HttpStringContent stringcont = new HttpStringContent("");
                var httpresponseMessage = await httpClient.PostAsync(new Uri(StravaUri.TokenUri + content), stringcont);
                if (httpresponseMessage.IsSuccessStatusCode)
                {
                    string resp = await httpresponseMessage.Content.ReadAsStringAsync();
                    AuthTokenData obj = JsonConvert.DeserializeObject<AuthTokenData>(resp);
                    AuthSettings.ScopeAccessToken = obj.access_token;
                    Athlete athleteObj = obj.athlete;
                    string json = JsonConvert.SerializeObject(athleteObj);
                    await SharedLibrary.Helper.FileHelper.WriteFile(SharedLibrary.Constants.AppConstants.ProfileFile, json);
                    
                    res.result = ResultStatus.Successful;
                }
                else
                {
                    res.result = ResultStatus.Failed;
                }
            }
            catch (Exception ex)
            {
                res.data = ex.Message;
                res.result = ResultStatus.Failed;
            }
            return res;
            //return true;
        }
    }
}
