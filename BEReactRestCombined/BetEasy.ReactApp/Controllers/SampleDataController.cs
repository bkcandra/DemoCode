using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEasy.Core.Models;
using BetEasy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetEasy.ReactApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet("[action]")]
        public async Task<NextJump> RaceData()
        {
            var raceList = await RacingData.GetNextJumpAsync();
            return raceList;
        }
    }
}
