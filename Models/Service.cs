using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("ServiceTbl")]
    public class Service : BaseEntity
    {
        [Key]
        public int Service_id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string S_title { get; set; }
        [Required(ErrorMessage = "Cost is Required")]
        public int Cost { get; set; }
        [Required]
        [RegularExpression(@"\+91[0-9]{10}", ErrorMessage = "It contains only 10 Numbers")]
        public string Phone_no { get; set; }        
        public int Is_active { get; set; }
        public string Product_des { get; set; }
      
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}