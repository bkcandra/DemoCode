using BetEasy.Core.Models;
using System.Collections.Generic;

namespace BetEasy.Core.Services.DataReader
{
    public interface IDataReaderFactory
    {
        RaceDataResponse GetRaceData(List<string> fileList);
    }
}
