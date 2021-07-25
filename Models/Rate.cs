using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("RateTb")]
    public class Rate
    {
        [Key]
        public int Rate_id { get; set; }
        //[Required]
        public string Image { get; set; }
       
        public int Product_id { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Review { get; set; }
        public int Customer_id { get; set; }
        public Nullable<DateTime> Created_date { get; set; }
        public Nullable<int> Is_active { get; set; }
  
        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }
    }
}