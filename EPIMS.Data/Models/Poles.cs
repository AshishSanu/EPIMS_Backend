using System;
using System.Collections.Generic;

namespace EPIMS.Data.Models
{
    public partial class Poles
    {
        public Poles()
        {
            PolesCountByWork = new HashSet<PolesCountByWork>();
        }

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Poletype { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<PolesCountByWork> PolesCountByWork { get; set; }
    }
}
