using KickballCats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KickballCats.Controllers
{
    public class HomeController : Controller
    {
        WeatherDAL wdal = new WeatherDAL();
        private readonly kickballContext _context;

        public HomeController(kickballContext context)
        {
            _context = context;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public IActionResult Index()
        {
            Rootobject w = new Rootobject();
            w = wdal.SomeWeather();
            UnixTimeStampToDateTime(w.hourly[1].dt).ToString();
            return View(w);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
