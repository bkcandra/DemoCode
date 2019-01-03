using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MDChall.Models.ApplicationModels;

namespace MDChall.Core.WebServices
{
    public class MdApi
    {
        static HttpClient client = new HttpClient();

        public static async Task<Dictionary<string,List<String>>> PostPNLAsync(List<String> Pnl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SystemConstants.MDApiPostProcessAddress);

                var content = new StringContent(JsonConvert.SerializeObject(Pnl), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri(SystemConstants.MDApiPostProcessAddress), content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, List<String>>>(result);
                    return dict;
                }
                
                return null;
            }
        }

        public static async Task<Dictionary<string, List<String>>> AddRecord(PassengerRecord record)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(new Uri(SystemConstants.MDApiListAddress), content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, List<String>>>(result);
                    return dict;
                }

                return null;
            }
        }

        public static async Task<Dictionary<string, List<String>>> GetDictionaryAsync()
        {
            HttpResponseMessage response = await client.GetAsync(SystemConstants.MDApiListAddress);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var dict = JsonConvert.DeserializeObject<Dictionary<string, List<String>>>(resp);
                return dict;
            }
            return null;
        }
    }
}
