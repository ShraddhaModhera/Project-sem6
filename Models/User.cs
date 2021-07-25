using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("UserTbl")]
    public class User : BaseEntity
    {
        [Key]
        public int User_id { get; set; }
        //[Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role_id { get; set; }
        public Nullable<int> Is_active { get; set; }
      
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        [NotMapped]
        public List<Role> RoleSelect { get; set; }

        public virtual Role Role { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}