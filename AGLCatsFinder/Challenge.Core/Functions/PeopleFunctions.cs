using Challenge.Core.WebServices;
using Challenge.Models;
using Challenge.Models.AGLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Functions
{
    public class PeopleFunctions
    {
        public async Task<List<People>> GetAsync()
        {
            var ppl = await new AGLApis().GetPeopleAsync();
            if (ppl != null)
                return ppl;
            return new List<People>();
        }

        /// <summary>
        /// Can be further extended by accepting a parameter 'groupBy'
        /// </summary>
        /// <param name="Key">Grouping Key</param>
        /// <returns></returns>
        public async Task<List<GroupedPeople>> GetGroupedPeople()
        {
            var ppl = await GetAsync();

            var groupedppl = ppl
                .GroupBy(x => x.Gender)
                .Select(y => new GroupedPeople
                {
                    Heading = y.Key,
                    Records = y.OrderBy(x => x.Name).ToList()
                }).ToList();

            return groupedppl;
        }

    }
}
