using BetEasy.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BetEasy.Core.Services.DataReader
{
    public class DataReaderFactory : IDataReaderFactory
    {
        /// <summary>
        /// Get the correct reader for reading file based on extension.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private RaceDataResponse ReadData(string filename)
        {
            var extension = Path.GetExtension(filename);
            try
            {
                string message;
                switch (extension)
                {
                    case ".json":
                        return new JsonDataReader().GetRaceData(filename);

                    case ".xml":
                        return new XMLDataReader().GetRaceData(filename);
                }
                return new RaceDataResponse
                {
                    Message = "Unable to find the correct reader"
                };
            }
            catch
            {
                return new RaceDataResponse
                {
                    Message = "Unable to find the correct reader"
                };
            }
        }

        public RaceDataResponse GetRaceData(List<string> fileList)
        {
            var response = new RaceDataResponse();
            var sb = new StringBuilder();
            foreach (var file in fileList)
            {
                var result = ReadData(file);
                if (string.IsNullOrEmpty(response.Message))
                    response.HorsePrice.AddRange(result.HorsePrice);
                else
                    sb.Append(result.Message);
            }

            response.HorsePrice = response.HorsePrice.OrderByDescending(x => x.Price).ToList();

            response.Message = string.IsNullOrEmpty(sb.ToString()) ? "" : sb.ToString();
            return response;
        }
    }
}