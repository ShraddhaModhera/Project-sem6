using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("CoupenTbl")]
    public class Coupon : BaseEntity
    {
        [Key]
        public int Coupon_id { get; set; }
        public string Coupon_code { get; set; }
        //[Required]
        public string Name { get; set; }       
        //[Required]
        public int Discount_value { get; set; }
        public Nullable<DateTime> Start_date { get; set; }
        public Nullable<DateTime> End_date { get; set; }
        public Nullable<int> Day_left { get; set; }
        public Nullable<int> Product_id { get; set; }
        public Nullable<int> Is_active { get; set; }
        
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        [NotMapped]
        public List<Product> ProductSelect { get; set; }
       
        public virtual Product Product { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}