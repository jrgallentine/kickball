using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KickballCats.Models
{
    public class PokeDAL
    {
        public string GetData(int Id)
        {

            string url = $"https://pokeapi.co/api/v2/pokemon/{Id}";

            //Web Requests sometimes need Headers/User Agent prop
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }
        public Pokemon SomePokemon(int Id)
        {
            string json = GetData(Id);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(json);
            return p;
        }
    }
}
