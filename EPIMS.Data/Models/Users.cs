using System;
using System.Collections.Generic;

namespace EPIMS.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            WorkDetails = new HashSet<WorkDetails>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public int? UserRoleId { get; set; }
        public long? Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public string Password { get; set; }

        public virtual Userrole UserRole { get; set; }
        public virtual ICollection<WorkDetails> WorkDetails { get; set; }
    }
}
