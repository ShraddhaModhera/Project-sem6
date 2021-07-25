using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Stock_StatusTbl")]
    public class StockStatus : BaseEntity
    {
        [Key]
        public int Stock_status_id { get; set; }
        public string SS_name { get; set; }
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