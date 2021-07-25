using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("SettingTbl")]
    public class Setting : BaseEntity
    {
        [Key]
        public int Settings_id { get; set; }
        //[Required]
        public string Meta_tag_title { get; set; }
        public string Meta_tag_description { get; set; }
        public string Meta_tag_keywords { get; set; }
        //[Required]
        public string Store_name { get; set; }
        //[Required]
        public string Store_owner { get; set; }
        public string Store_address { get; set; }
        public string Store_email { get; set; }
        public string Store_telephone { get; set; }
        public string Store_logo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<int> Zone_id { get; set; }
        public Nullable<int> Country_id { get; set; }
        public Nullable<int> Lang_id { get; set; }
        public Nullable<int> Currency_id { get; set; }
        public string Maintenance_mode { get; set; }
        public string Google { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public int Order_status_id { get; set; }
        public string Invoice_prefix { get; set; }
        public Nullable<int> Items_per_page { get; set; }
        public string Category_product_count { get; set; }
        public Nullable<int> Status_id { get; set; }
      
        [NotMapped]
        public List<Zone> ZoneSelect { get; set; }

        [NotMapped]
        public List<Country> CountriesSelect { get; set; }

        [NotMapped]
        public List<Language> LangSelect { get; set; }

        [NotMapped]
        public List<Currency> CurSelect { get; set; }

        [NotMapped]
        public List<OrderStatus> OStatusSelect { get; set; }

        [NotMapped]
        public List<Status> StatusSelect { get; set; }
        public virtual Country Country { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Status Status { get; set; }

        public virtual Language Language { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}