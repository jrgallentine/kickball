using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KickballCats.Models
{
    public class xDAL
    {
        public string GetData(int num)
        {

            string url = $"https://xkcd.com/{num}/info.0.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }
        public xkcd SomeX(int num)
        {
            string json = GetData(num);
            xkcd x = JsonConvert.DeserializeObject<xkcd>(json);
            return x;
        }
    }
}
