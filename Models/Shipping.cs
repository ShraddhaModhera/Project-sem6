using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("ShipTbl")]
    public class Shipping
    {
        [Key]
        public Byte Shipping_id { get; set; }
        public string Value { get; set; }
    }
}