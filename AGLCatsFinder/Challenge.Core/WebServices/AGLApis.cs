using Challenge.Core.Constants;
using Challenge.Models.AGLModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.WebServices
{
    public class AGLApis
    {
        static HttpClient client = new HttpClient();

        public async Task<List<People>> GetPeopleAsync()
        {
            HttpResponseMessage response = await client.GetAsync(SystemConstants.AGLJsonUri);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<People>>(resp);
            }
            return null;
        }
    }
}
