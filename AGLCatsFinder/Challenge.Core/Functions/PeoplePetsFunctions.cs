using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Challenge.Core.WebServices;
using Challenge.Models.AGLModels;
using System.Linq;
using System.Linq.Expressions;

namespace Challenge.Core.Functions
{
    public class PeoplePetsFunctions
    {
        public async Task<List<Pets>> GetPetsAsync()
        {
            var ppl = await new PeopleFunctions().GetAsync();
            var pplPets = ppl.Where(x => x.Pets != null).SelectMany(x => x.Pets).ToList();

            return pplPets;
        }

        public async Task<List<GroupedPets>> GetGroupedPetsAsync(string filter = "", string order = "", bool desc = false)
        {
            var groupedPeople = await new PeopleFunctions().GetGroupedPeople();
            var groupedPets = new List<GroupedPets>();

            foreach (var people in groupedPeople)
            {
                var pplwPets = people.Records.Where(x => x.Pets != null).SelectMany(x => x.Pets);

                if (!string.IsNullOrEmpty(filter))
                    pplwPets = pplwPets.Where(x => x.Type.ToLowerInvariant() == filter.ToLowerInvariant());

                groupedPets.Add(new GroupedPets
                {
                    Heading = people.Heading,
                    Records = GetSortedData(pplwPets, order, desc).ToList()
                });
            }

            return groupedPets;
        }

        private IEnumerable<Pets> GetSortedData(IEnumerable<Pets> result, String orderby, bool desc)
        {
            switch (orderby.ToLowerInvariant())
            {
                case "type": return desc ? result.OrderByDescending(c => c.Type) : result.OrderBy(c => c.Type);
                default: return desc ? result.OrderByDescending(c => c.Name) : result.OrderBy(c => c.Name);
            }
        }

    }


}
