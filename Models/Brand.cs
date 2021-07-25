using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("BrandTbl")]
    public class Brand : BaseEntity
    {
        [Key]
        public int Brand_id { get; set; }
        //[Required]
        public string Name { get; set; }        
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<int> Sort_order { get; set; }
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