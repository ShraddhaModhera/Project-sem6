using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("StatusTbl")]
    public class Status
    {
        [Key]
        public int Status_id { get; set; }
        public string Status_name { get; set; }
    }
}