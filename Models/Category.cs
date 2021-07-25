using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("CategoryTb")]
    public class Category : BaseEntity
    {
        [Key]
        public int Category_id { get; set; }
        //[Required]
        public string Name { get; set; }
       
       
        //[Required]
        public Nullable<int> Sort_order { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string Meta_tag_title { get; set; }
        public string Meta_tag_description { get; set; }
        public string Meta_tag_keyword { get; set; }
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