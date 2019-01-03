using MDChall.Core;
using MDChall.Core.Functions;
using MDChall.Models.ApplicationModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MDChall.Test
{
    [TestClass]
    public class APITest
    {
        private PassengerList pl = new PassengerList();

        [TestMethod]
        public void PassengerProcessor()
        {
            var np = new PassengerProcessor();
            var res = np.ProcessPNL(SystemConstants.GetTestPNL());

            Assert.AreEqual(res.Count, 3);
            Assert.AreEqual(res["LVGVUP"].Count, 2);
            Assert.AreEqual(res["LVK6HA"].Count, 1);
        }

        [TestMethod]
        public void WebApiPUTGET()
        {
            var value = new PassengerRecord
            {
                Key = "TESTAB",
                LastName = "Doe",
                Gender = "MR",
                FirstName = "John"
            };
            if (pl.Add(value))
            {
                var res = pl.GetList();
                Assert.AreEqual(res.Count, 4);
                Assert.AreEqual(res["LVGVUP"].Count, 2);
                Assert.AreEqual(res["TESTAB"].Count, 1);
                Assert.AreEqual((res["TESTAB"][0]), "JOHN/DOEMR");
            }
            
        }
        
    }
}
