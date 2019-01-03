using BetEasy.Common;
using BetEasy.Core.Services.DataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BetEasy.Test
{
    [TestClass]
    public class BetEasyTester
    {
        private readonly DataReaderFactory _dataReaderFactory;

        public BetEasyTester()
        {
            _dataReaderFactory = new DataReaderFactory();
        }

        [TestMethod]
        public async Task GetRaceData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + SystemConstants.FeedDataUri;
            var dir = Directory.GetFiles(path);
            var raceData = _dataReaderFactory.GetRaceData(dir.ToList());

            Assert.IsNotNull(raceData);
            Assert.AreEqual(raceData.Message, string.Empty);
            Assert.AreNotEqual(raceData.HorsePrice.Count, 0);

            var isHigher = raceData.HorsePrice.FirstOrDefault().Price > raceData.HorsePrice.LastOrDefault().Price;
            Assert.IsTrue(isHigher);



        }
    }
}
