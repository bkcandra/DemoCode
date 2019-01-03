using BetEasy.Core.Models;
using System.Collections.Generic;

namespace BetEasy.Core.Services.DataReaderManager
{
    public interface IDataReaderFactory
    {
        RaceDataResponse GetRaceData(List<string> fileList);
    }
}
