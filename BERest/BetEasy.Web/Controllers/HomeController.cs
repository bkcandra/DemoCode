using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetEasy.Web.Models;
using Microsoft.AspNetCore.Hosting;
using BetEasy.Core.Services.DataReader;
using BetEasy.Common;
using System.IO;

namespace BetEasy.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Fields
        private readonly IHostingEnvironment _hostingEnvironment;
        private IDataReaderFactory _dataReaderManager;

        #endregion

        #region Ctor

        public HomeController(IDataReaderFactory dataReaderManager, IHostingEnvironment hostingEnvironment)
        {
            _dataReaderManager = dataReaderManager;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        public IActionResult Index()
        {
            // Just for demo purposes. in production, racing services has the responsibility in reading race data from various external api and datareader manager has the responsibility 
            // in reading and return list of races.
            var dir = Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath,SystemConstants.FeedDataUri));

            var raceData = _dataReaderManager.GetRaceData(dir.ToList());
            return View(raceData);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
