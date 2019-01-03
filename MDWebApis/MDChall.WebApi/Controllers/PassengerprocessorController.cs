using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDChall.Core.Functions;
using MDChall.Models.ApplicationModels;
using Newtonsoft.Json;

namespace MDChall.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PassengerprocessorController : Controller
    {
        //POST api/values
        [HttpPost]
        public Dictionary<String, List<String>> Post([FromBody]List<String> value)
        {
            var res = new Dictionary<String, List<String>>();
            if (value == null || value.Count == 0)
                res.Add("Error", new List<string> { "Invalid value" });

            var result = new PassengerProcessor().ProcessPNL(value);
            return result;

        }
    }

   
}
