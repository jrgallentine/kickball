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
        private readonly kickballContext _kbContext;
        PokeDAL pdal = new PokeDAL();


        public HomeController(kickballContext context)
        {
            _kbContext = context;
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

            Home h = new Home();
            h.currentTemp = Math.Round(w.current.temp);
            foreach(Weather weather in w.current.weather)
            {
                h.weather = weather.description;
            }
            string hmm = h.currentTemp.ToString();
            int.TryParse(hmm, out int hm2);
            h.dt = UnixTimeStampToDateTime(w.current.dt);
            Pokemon p = new Pokemon();
            p = pdal.SomePokemon(hm2);

            h.PokeId = hm2;
            h.PokeName = p.name;

            return View(h);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
