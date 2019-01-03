using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Models.AGLModels
{
    public class People
    {
        public People()
        {
            Pets = new List<Pets>();
        }
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public ICollection<Pets> Pets { get; set; }
    }
}
