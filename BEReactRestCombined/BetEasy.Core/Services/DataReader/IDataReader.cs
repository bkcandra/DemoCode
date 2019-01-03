using BetEasy.Core.Models;

namespace BetEasy.Core.Services.DataReader
{
    public interface IDataReader
    {
        RaceDataResponse GetRaceData(string filename);
    }
}