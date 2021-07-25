using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("EnquiryTbl")]
    public class Enquiry
    {
        [Key]
        public int Enq_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile_no { get; set; }
        public string Comments { get; set; }
        public Nullable<int> Is_active { get; set; }
        
        [NotMapped]
        public List<Status> StatusSelect { get; set; }

    }
}