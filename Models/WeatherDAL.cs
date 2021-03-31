using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KickballCats.Models
{
    public class WeatherDAL
    {
        public string GetData()
        {

            string url = $"https://api.openweathermap.org/data/2.5/onecall?lat=42.9784&lon=-85.6512&units=imperial&appid={Secret.ApiKey}"; // Movie Model

            //Web Requests sometimes need Headers/User Agent prop
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }
        public Rootobject SomeWeather()
        {
            string json = GetData();
            Rootobject r = JsonConvert.DeserializeObject<Rootobject>(json);
            return r;
        }
    }
}
