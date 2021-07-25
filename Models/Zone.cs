using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("ZoneTbl")]
    public class Zone : BaseEntity
    {
        [Key]
        public int Zone_id { get; set; }
        //[Required]
        public string Zone_name { get; set; }
        public string Code { get; set; }
        public int Country_id { get; set; }
        public Nullable<int> Is_active { get; set; }
    
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        [NotMapped]
        public List<Country> CountrySelect { get; set; }

        public virtual Country Country { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}