using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("Email_TemplateTbl")]
    public class Email
    {
        [Key]
        public int Eid { get; set; }
        //[Required]
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Nullable<int> Is_active { get; set; }

        [NotMapped]
        public List<Status> StatusSelect { get; set; }

    }
}