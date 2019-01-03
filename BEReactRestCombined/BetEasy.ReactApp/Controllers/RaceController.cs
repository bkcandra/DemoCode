using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEasy.Common;
using BetEasy.Core.Services.DataReaderManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BetEasy.ReactApp.Controllers
{
    public class RaceController : Controller
    {
        #region Fields
        private readonly IHostingEnvironment _hostingEnvironment;
        private IDataReaderFactory _dataReaderManager;

        #endregion

        #region Ctor

        public RaceController(IDataReaderFactory dataReaderManager, IHostingEnvironment hostingEnvironment)
        {
            _dataReaderManager = dataReaderManager;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        public IActionResult Index()
        {
            var dir = System.IO.Directory.GetFiles($"{_hostingEnvironment.ContentRootPath}{SystemConstants.FeedDataUri}");
            var raceData = _dataReaderManager.GetRaceData(dir.ToList());
            return View(raceData);
        }
    }
}