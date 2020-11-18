using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace vino.models
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            this.client = new HttpClient();
        }

        public async Task<String> get(String url)
        {
            Uri uri = new Uri(url);
            String json = null;

            try
            {
                HttpResponseMessage response = await this.client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(@"\t yooooo!! {0}", json);
            } catch(Exception error)
            {
                Debug.WriteLine(@"\tERROR {0}", error.Message);
            }

            return json;
        }
    }
}
