using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("BannerTbl")]
    public class Banner : BaseEntity
    {
        [Key]
        public int Banner_id { get; set; }
        //[Required]
        public string B_title { get; set; }
        //[Required]
        public string B_content { get; set; }
        //[Required]
        public string Link { get; set; }
        public Nullable<int> Position { get; set; }        

        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<int> Is_active { get; set; }

        [NotMapped]
        public List<Status> StatusSelect { get; set; }

    }

    public class BaseEntity
    {
        public Nullable<DateTime> Created_date { get; set; }
        public Nullable<DateTime> Modified_date { get; set; }
      
    }
}