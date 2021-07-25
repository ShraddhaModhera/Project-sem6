using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    [Table("CancelTbl")]
    public class CancelOrder : BaseEntity
    {
        [Key]
        public int Cancel_id { get; set; }
        public int Order_id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Total { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }

    }
}