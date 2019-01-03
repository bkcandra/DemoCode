using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge.Web.Models;
using Challenge.Core.Functions;
using Challenge.Models;

namespace Challenge.Web.Controllers
{
    public class HomeController : Controller
    {
        PeoplePetsFunctions pp = new PeoplePetsFunctions();
        [HttpGet]
        public async Task<IActionResult> Index(string sorting = "name", string filter = "cat")
        {
            // Get & Sort
            var model = await pp.GetGroupedPetsAsync(filter, sorting);
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
