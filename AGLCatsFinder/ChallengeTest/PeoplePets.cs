using Challenge.Core.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.Test
{
    [TestClass]
    public class PeoplePetsTest
    {
 
        [TestMethod]
        public void Getpets()
        {
            var tResult = new PeoplePetsFunctions().GetPetsAsync().Result;
            Assert.IsNotNull(tResult);
        }

        [TestMethod]
        public void GetGroupedPetsAsync()
        {
            var pf = new PeoplePetsFunctions();

            var tResult = pf.GetGroupedPetsAsync().Result;
            Assert.IsNotNull(tResult, null);

            // filtering must work here
            tResult = pf.GetGroupedPetsAsync("cat", "").Result;
            Assert.IsNotNull(tResult.FirstOrDefault(), null);
            var petType = tResult.FirstOrDefault().Records.FirstOrDefault().Type.ToLowerInvariant();
            Assert.AreEqual("cat", petType);
            petType = tResult.LastOrDefault().Records.FirstOrDefault().Type.ToLowerInvariant();
            Assert.AreEqual("cat", petType);

            // invalid sort or filter must not return null
            tResult = pf.GetGroupedPetsAsync("will", "not found").Result;
            int actualcount = tResult.FirstOrDefault().Records.Count;
            Assert.AreEqual(0, actualcount);
            actualcount = tResult.LastOrDefault().Records.Count;
            Assert.AreEqual(0, actualcount);
        }
    }
}
