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

        public async Task<String> get(String url)
        {
            Uri uri = new Uri(url);
            String json = null;

            try
            {
                HttpResponseMessage response = await this.client.GetAsync(uri);
                json = await response.Content.ReadAsStringAsync();
            } catch(Exception error)
            {
                Debug.WriteLine(@"\tERROR {0}", error.Message);
            }

            return json;
        }

        public async Task<String> post(String url, String json)
        {
            Uri uri = new Uri(url);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            String jsonResponse = null;

            try
            {
                HttpResponseMessage response = await this.client.PostAsync(uri, content);
                jsonResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(@"\t Post result!!! {0}", jsonResponse);
            }
            catch (Exception error)
            {
                Debug.WriteLine(@"\tERROR {0}", error.Message);
            }

            return jsonResponse;
        }

        public async Task<String> put(String url, String json)
        {
            Uri uri = new Uri(url);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            String jsonResponse = null;

            try
            {
                HttpResponseMessage response = await this.client.PutAsync(uri, content);
                jsonResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(@"\t Put result!!! {0}", jsonResponse);
            }
            catch (Exception error)
            {
                Debug.WriteLine(@"\tERROR {0}", error.Message);
            }

            return jsonResponse;
        }
    }
}
