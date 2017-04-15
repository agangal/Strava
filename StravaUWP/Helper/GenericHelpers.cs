using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaUWP.Helper
{
    using RestSharp;
    using SharedLibrary;
    using Windows.Storage;
    using System.Net.Http;
    public class GenericHelpers
    {

        public static async Task<string> UploadActivity(string filePath, string filename)
        {
            FileInfo info = new FileInfo(filePath);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", AuthSettings.ScopeAccessToken));
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(File.ReadAllBytes(info.FullName)), "file", info.Name);
            HttpResponseMessage result = await client.PostAsync(
                string.Format("https://www.strava.com/api/v3/uploads?data_type={0}&activity_type={1}&commute={2}",
                "gpx", "ride", "false"),
                content);
            string json = await result.Content.ReadAsStringAsync();
            return json;
        }
    }
}
