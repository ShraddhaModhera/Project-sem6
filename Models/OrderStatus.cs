using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Order_StatusTbl")]
    public class OrderStatus : BaseEntity
    {
        [Key]
        public int Order_status_id { get; set; }
        //[Required]
        public string O_name { get; set; }
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