using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("ProductTbl")]
    public class Product : BaseEntity
    {
        [Key]
        public int Product_id { get; set; }
        public string SKU { get; set; }
        public string UPC { get; set; }
        public Nullable<int> Quantity { get; set; }
        public int Stock_status_id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }

        public Nullable<int> Category_id { get; set; }
        public Nullable<Byte> Shipping { get; set; }
        public Nullable<DateTime> Date_available { get; set; }
        public string Meta_tag_title { get; set; }
        public string Meta_tag_description { get; set; }
        public string Meta_tag_keyword { get; set; }        
        public int Variant_id { get; set; }
        public Nullable<int> Today_deals { get; set; }
        public Nullable<int> Is_feature { get; set; }
        public Nullable<int> Sort_Order { get; set; }
        public int Manufacturer_id { get; set; }
        public Nullable<int> Is_active { get; set; }

        public virtual Category Category { get; set; }
  
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        [NotMapped]
        public List<StockStatus> StockSelect { get; set; }

        [NotMapped]
        public List<Variant> VarSelect { get; set; }

        [NotMapped]
        public List<Manufacturer> ManuSelect { get; set; }

        [NotMapped]
        public List<Shipping> ShipSelect { get; set; }

        [NotMapped]
        public List<Category> CatSelect { get; set; }
        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}