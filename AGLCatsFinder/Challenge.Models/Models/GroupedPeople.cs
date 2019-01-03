using Challenge.Models.AGLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Models
{

    public class GroupedPeople
    {
        public GroupedPeople()
        {
            Records = new HashSet<People>();
        }
        public string Heading { get; set; }

        public ICollection<People> Records { get; set; }
    }

    
}
