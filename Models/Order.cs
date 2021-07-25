using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("OrderTb")]
    public class Order : BaseEntity
    {
        [Key]
        public int Order_id { get; set; }
        public int Customer_id { get; set; }
        public Nullable<int> Total { get; set; }

        [NotMapped]
        public List<Customer> CustSelect { get; set; }

        public virtual Customer Customer { get; set; }

        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }

    }
}