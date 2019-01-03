using BetEasy.Common;
using BetEasy.Core.Services;
using BetEasy.Core.Services.DataReaderManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public async Task NextJump()
        {
            var raceData = await RacingData.GetNextJumpAsync();
            Assert.IsNotNull(raceData);

            Assert.IsTrue(raceData.success);

            if (raceData.result.Any())
            {
                var testData = raceData.result.FirstOrDefault();
                // this is required
                Assert.IsNotNull(testData.EventID);
                Assert.IsNotNull(testData.EventType.EventTypeID);
                Assert.IsNotNull(testData.AdvertisedStartTime);
            }

        }

        [TestMethod]
        public async Task GetRaceData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + SystemConstants.TestDataUri;
            var dir = Directory.GetFiles(path);
            var raceData = _dataReaderFactory.GetRaceData(dir.ToList());

            Assert.IsNotNull(raceData);
            Assert.AreEqual(raceData.Message, string.Empty);
            Assert.AreEqual(raceData.HorsePrice.Count, 2);
            
            
        }
    }
}

