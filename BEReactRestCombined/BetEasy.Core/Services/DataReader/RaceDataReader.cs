using BetEasy.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BetEasy.Core.Services.DataReader
{
    public class JsonDataReader : IDataReader
    {
        public RaceDataResponse GetRaceData(string filename)
        {
            var response = new RaceDataResponse();
            if (!File.Exists(filename))
            {
                response.Message = "file not found.";
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                string json = reader.ReadToEnd();
                JsonRaceData raceData = JsonConvert.DeserializeObject<JsonRaceData>(json);
                var data = new List<HorsePrice>();
                foreach (var horse in raceData.RawData.Participants)
                {
                    var selections = raceData.RawData.Markets.SelectMany(x => x.Selections);
                    var horseMarket = selections.FirstOrDefault(x => x.Tags.name.ToLower().Equals(horse.Name.ToLower()));
                    if (horseMarket != null)
                    {
                        data.Add(new HorsePrice
                        {
                            Name = horse.Name,
                            Price = horseMarket.Price
                        });
                    }
                }
                response.HorsePrice.AddRange(data);
            }
            return response;
        }
    }

    public class XMLDataReader : IDataReader
    {
        public RaceDataResponse GetRaceData(string filename)
        {
            var response = new RaceDataResponse();
            //
            // Plug in our xml reader here
            //

            return response;
        }
    }
}