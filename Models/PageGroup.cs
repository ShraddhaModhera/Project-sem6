using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Page_GroupTbl")]
    public class PageGroup : BaseEntity
    {
        [Key]
        public int Page_group_id { get; set; }
        public string Group_name { get; set; }
        public Nullable<int> Is_active { get; set; }
     
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}