using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("ManufacturerTbl")]

    public class Manufacturer : BaseEntity
    {
        [Key]
        public int Manufacturer_id { get; set; }
        public string Name { get; set; }
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