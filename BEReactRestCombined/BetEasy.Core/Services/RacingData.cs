using BetEasy.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BetEasy.Core.Models;

namespace BetEasy.Core.Services
{
    public class RacingData
    {
        static HttpClient client = new HttpClient();

        public static async Task<NextJump> GetNextJumpAsync()
        {
            HttpResponseMessage response = await client.GetAsync(SystemConstants.RacingApiUri);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<NextJump>(resp);
                return data;
            }
            return null;
        }

        public static async Task<NextJump> GetRaceList()
        {
            HttpResponseMessage response = await client.GetAsync(SystemConstants.RacingApiUri);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<NextJump>(resp);
                return data;
            }
            return null;
        }

    }
}
