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
        public static Task<string> GetRequestAsync(string api, string resource = "")
        {
            RestClient client = new RestClient(api);
            RestRequest request = new RestRequest(resource, Method.GET);
            request.AddParameter("access_token", AuthSettings.ScopeAccessToken);
            
            var tcs = new TaskCompletionSource<string>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response.Content);
                
            });
            return tcs.Task;
        }    
        
        public static Task<string> PostRequestAsync(string api)
        {
            return null;
        }

        public static Task<string> PutRequestAsync(string api)
        {
            return null;
        }

        public static Task<string> DeleteRequestAsync(string api)
        {
            return null;
        }
        public static string GetRequest(string api)
        {
            return null;
        }

        public static string PutRequest(string api)
        {
            return null;
        }

        public static string PostRequest(string api)
        {
            return null;
        }
    }
}
