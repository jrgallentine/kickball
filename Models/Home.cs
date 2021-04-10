using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickballCats.Models
{
    public class Home
    {
        public DateTime dt { get; set; }
        public double currentTemp { get; set; }
        public string weather { get; set; }
        public int PokeId { get; set; }
        public string PokeName { get; set; }
        public int PokeWeight { get; set; }
        public string ComicImg { get; set; }
    }
}
