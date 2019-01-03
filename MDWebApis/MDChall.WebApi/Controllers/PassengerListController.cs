using MDChall.Models.ApplicationModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDChall.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PassengerListController : Controller
    {
        private PassengerList pl = new PassengerList();

        public Dictionary<String, List<String>> Put([FromBody]PassengerRecord value)
        {
            if (!string.IsNullOrEmpty(value.Key) && !string.IsNullOrEmpty(value.LastName))
            {
                if (pl.Add(value))
                    return pl.GetList();
            }

            var res = new Dictionary<String, List<String>>();
            res.Add("Error", new List<string> { "Invalid passenger record" });
            return res;
        }

        [HttpGet]
        public Dictionary<String, List<String>> Get()
        {
            return pl.GetList();
        }
    }
}
