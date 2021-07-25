using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("CountryTbl")]
    public class Country
    {
        [Key]
        public int Country_id { get; set; }
        //[Required]
        public string Country_name { get; set; }
        public string Iso_code_1 { get; set; }
        public string Iso_code_2 { get; set; }
        public Nullable<int> Postcode_required { get; set; }        
        public Nullable<int> Is_active { get; set; }

        [NotMapped]
        public List<Status> StatusSelect { get; set; }

    }
}