using System;
using System.Collections.Generic;

namespace EPIMS.Data.Models
{
    public partial class WorkDetails
    {
        public WorkDetails()
        {
            PolesCountByWork = new HashSet<PolesCountByWork>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Lat { get; set; }
        public string Lang { get; set; }
        public DateTime? Date { get; set; }
        public string Zone { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<PolesCountByWork> PolesCountByWork { get; set; }
    }
}
