using System;
using System.Collections.Generic;
using System.Text;

namespace BetEasy.Core.Models
{
    public class RaceDataResponse
    {
        public RaceDataResponse()
        {
            HorsePrice = new List<HorsePrice>();
        }

        public string Message { get; set; }
        public List<HorsePrice> HorsePrice { get; set; }
    }

    public class HorsePrice
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
