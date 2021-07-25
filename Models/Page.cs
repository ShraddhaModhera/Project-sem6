using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("PageTbl")]
    public class Page : BaseEntity
    {
        [Key]
        public int Page_id { get; set; }
        //[Required]
        public string Title { get; set; }
        //[Required]
        public string Intro { get; set; }
        //[Required]
        public Nullable<int> Page_group_id { get; set; }
        public Nullable<int> Sort_order { get; set; }
        
        public string Meta_tag_title { get; set; }
        public string Meta_tag_description { get; set; }
        public string Meta_tag_keywords { get; set; }
        public Nullable<int> Is_active { get; set; }
       
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        [NotMapped]
        public List<PageGroup> GroupSelect { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}