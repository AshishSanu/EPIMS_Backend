using System;
using System.Collections.Generic;

namespace EPIMS.Data.Models
{
    public partial class Userrole
    {
        public Userrole()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string UserCode { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
