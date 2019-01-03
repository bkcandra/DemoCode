using BetEasy.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BetEasy.Core.Services.DataReader
{
    public class XMLDataReader : IDataReader
    {
        public RaceDataResponse GetRaceData(string filename)
        {
            var response = new RaceDataResponse();
            if (!File.Exists(filename))
            {
                response.Message = "file not found.";
            }
            var xmlData = new XmlRaceData();
            try
            {
                xmlData = DeSerializer(ReadXmlElement(filename));
                var data = new List<HorsePrice>();
                foreach (var horse in xmlData.Races.Race.Horses.Horse)
                {
                    var horsePrices = xmlData.Races.Race.Prices.Price.Horses.Horse;
                    var horsePrice = horsePrices.FirstOrDefault(x => x._Number.ToLower().Equals(horse.Number.ToLower()));
                    if (horsePrice != null)
                    {
                        double price = 0;
                        if (double.TryParse(horsePrice.Price, out price))
                        {
                            data.Add(new HorsePrice
                            {
                                Name = horse.Name,
                                Price = price
                            });
                        }
                    }
                }
                response.HorsePrice = data;
            }
            catch (Exception ex)
            {
                response.Message = "Cannot serialize data.";
            }

            return response;
        }

        private XElement ReadXmlElement(string inputUrl)
        {
            using (XmlReader reader = XmlReader.Create(inputUrl))
            {
                if (reader.MoveToContent() == XmlNodeType.Element)
                {
                    if (reader.Name == "meeting")
                    {
                        XElement el = XNode.ReadFrom(reader) as XElement;
                        if (el != null)
                        {
                            return el;
                        }
                    }
                }
                return null;
            }
        }

        static XmlRaceData DeSerializer(XElement element)
        {
            var serializer = new XmlSerializer(typeof(XmlRaceData));
            return (XmlRaceData)serializer.Deserialize(element.CreateReader());
        }
    }
}