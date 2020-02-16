using System;
using System.Collections.Generic;

namespace EPIMS.Data.Models
{
    public partial class PolesCountByWork
    {
        public int Id { get; set; }
        public int? PoleId { get; set; }
        public int? Quantity { get; set; }
        public int? WorkId { get; set; }

        public virtual Poles Pole { get; set; }
        public virtual WorkDetails Work { get; set; }
    }
}
