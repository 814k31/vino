using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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

        public async Task get(String url)
        {
            Uri uri = new Uri(url);

            try
            {
                HttpResponseMessage response = await this.client.GetAsync(uri);
                String body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(@"Successfully retrieved {0}", body);
            } catch(Exception error)
            {
                Debug.WriteLine(@"\tERROR {0}", error.Message);
            }
        }
    }
}
