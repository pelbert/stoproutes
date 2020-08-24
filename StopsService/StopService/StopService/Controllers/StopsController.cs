using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StopService.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StopService.Controllers
{
    public class StopsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/stops")]
        public IEnumerable<StopRoutes> Get([FromQuery(Name = "stop")] string stop)
        {
            // var name = Request.QueryString["name"];

            IEnumerable<StopRoutes> data = DataManager.GetData(Int32.Parse(stop));
             
            return data; 
        }
    }
}
