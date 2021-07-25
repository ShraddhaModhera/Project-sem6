using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    [Table("PaymentTbl")]
    public class Payment: BaseEntity
    {
        [Key]
        public int Payment_id { get; set; }
        public int Order_id { get; set; }
        public int Customer_id { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Payment_Method { get; set; }

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