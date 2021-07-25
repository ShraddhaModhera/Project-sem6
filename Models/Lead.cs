using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("LeadTb")]
    public class Lead
    {
        [Key]
        public int Lead_id { get; set; }
        public string L_name { get; set; }
        public string Email { get; set; }
        public string Mobile_no { get; set; }

    }
}