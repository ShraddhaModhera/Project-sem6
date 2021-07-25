using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Customer_GroupTbl")]
    public class CustomerGroup : BaseEntity
    {
        [Key]
        public int Customer_group_id { get; set; }
        //[Required]
        public string Group_name { get; set; }
        //[Required]
        public string Description { get; set; }
        //[Required]
        public string Color_code { get; set; }
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