using Challenge.Models.AGLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Models
{

    public class GroupedPets
    {
        public GroupedPets()
        {
            Records = new HashSet<Pets>();
        }
        public string Heading { get; set; }

        public ICollection<Pets> Records { get; set; }
    }
}
