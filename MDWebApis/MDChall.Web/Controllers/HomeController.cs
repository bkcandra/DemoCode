using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDChall.Web.Models;
using MDChall.Core.Functions;
using MDChall.Core;
using Microsoft.AspNetCore.Http;
using System.IO;
using MDChall.Models.ApplicationModels;
using System.Text;
using MDChall.Core.WebServices;

namespace MDChall.Web.Controllers
{
    public class HomeController : Controller
    {
        private PassengerProcessor pp = new PassengerProcessor();
        private PassengerList pl = new PassengerList();
        private PassengerSearch ps = new PassengerSearch();

        public async Task<IActionResult> Index()
        {
            return View(await MdApi.GetDictionaryAsync());
        }

        [HttpPost]
        public async Task<IActionResult> UploadAndProcess(IFormFile file)
        {
            var content = new List<String>();

            if (file != null && file.Length > 0)
            {
                if (SystemConstants.AcceptedExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant()))
                {
                    using (var Reader = new System.IO.StreamReader(file.OpenReadStream()))
                    {
                        string inputLine = "";
                        while ((inputLine = await Reader.ReadLineAsync()) != null)
                            content.Add(inputLine);
                        Reader.Close();
                    }
                    //Upload 
                    var res = await MdApi.PostPNLAsync(content);
                    return PartialView("_PartialPassengerList", res);
                }
                else
                    return BadRequest(new { Result = false, Message = "please upload txt only" });
            }
            return BadRequest(new { Result = false, Message = "Empty file" });
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(PassengerRecord record)
        {
            if (string.IsNullOrEmpty(record.Key) || string.IsNullOrEmpty(record.LastName))
                return BadRequest(new { Result = false, Message = "Key & last name must not empty" });

            if (record.Key.Length != 6)
                return BadRequest(new { Result = false, Message = "key length must be 6 letters" });


            var res = await MdApi.AddRecord(record);
            return PartialView("_PartialPassengerList", res);
        }

        [HttpPost]
        public async Task<IActionResult> Search(String query)
        {
            var dict = await ps.SearchPNLAsync(string.IsNullOrEmpty(query) ? "" : query);
            return PartialView("_PartialPassengerList", dict);
        }

        public async Task<IActionResult> Export(String query)
        {
            return File(Encoding.UTF8.GetBytes(await pp.ExportToStringAsync(query.Trim())), "text/txt", "pnl.txt");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
