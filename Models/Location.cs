using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Delivery_LocationTbl")]   
    public class Location : BaseEntity
    {
        [Key]
        public int Location_id { get; set; }
        //[Required]
        public string Lname { get; set; }
        public Nullable<int> Pincode { get; set; }
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