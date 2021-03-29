using System;
using System.Collections.Generic;

#nullable disable

namespace KickballCats.Models
{
    public partial class Stats
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public string Name { get; set; }
        public int? Runs { get; set; }
        public int? Kicks { get; set; }
        public int? TeamLetDowns { get; set; }
        public int? TeamSaver { get; set; }
        public int? Injuries { get; set; }
        public int? Drinks { get; set; }

        public virtual GameStats Game { get; set; }
    }
}
