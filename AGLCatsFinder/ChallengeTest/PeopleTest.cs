using Challenge.Core.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Challenge.Test
{
    [TestClass]
    public class PeopleTest
    {
        [TestMethod]
        public void IsPeopleAPIWorking()
        {
            var tResult = new PeopleFunctions().GetAsync();
            Assert.IsNotNull(tResult);
        }

        /// <summary>
        ///  in the future this should be testing grouping key as well
        /// </summary>
        [TestMethod]
        public void GetGroupedPeople()
        {
            var tResult = new PeopleFunctions().GetGroupedPeople().Result;
            Assert.IsNotNull(tResult, null);
        }

       
    }
}
