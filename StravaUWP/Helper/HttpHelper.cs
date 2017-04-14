using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaUWP.Helper
{
    using RestSharp;
    using SharedLibrary;
    public class HttpHelper
    {
        public static Task<string> GetRequest(string api, string resource)
        {
            RestClient client = new RestClient(api);
            RestRequest request = new RestRequest(resource, Method.GET);
            request.AddParameter("access_token", AuthSettings.ScopeAccessToken);
            string res = string.Empty ;
            var tcs = new TaskCompletionSource<string>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response.Content);
                
            });
            return tcs.Task;
        }

        private static void callback(IRestResponse arg1, RestRequestAsyncHandle arg2)
        {
            throw new NotImplementedException();
        }
    }
}
