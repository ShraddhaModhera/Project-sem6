using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    [Table("CustomerTbl")]
    public class Customer : BaseEntity
    {
        [Key]
        public int Customer_id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is Required!")]
        public string First_name { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "LastName is Required!")]
        public string Last_name { get; set; }
        
        //[Required(AllowEmptyStrings = false, ErrorMessage = "UserName is Required!")]
        public string Username { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email Required!")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Password Required !")]
        //[DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Minimum 6 Characters required!")]
        public string Password { get; set; }

        [NotMapped]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Password does not matched!")]
        public string ConfirmPassword { get; set; }

        //[MinLength(10, ErrorMessage = "Enter 10 digit Mobile Number!")]
        //[MaxLength(10, ErrorMessage = "Enter 10 digit Mobile Number!")]
        public string Mobile { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Enter Address!")]
        public string Address { get; set; }

        public string ResetPasswordCode { get; set; }
        public Nullable<bool> Mail_status { get; set; }
        public Nullable<int> Customer_group_id { get; set; }
        
        public int Is_active { get; set; }
       
        public Nullable<bool> IsEmailVerified { get; set; }

        public Nullable<System.Guid> ActivationCode { get; set; }

        [NotMapped]
        public List<CustomerGroup> CGroupSelect { get; set; }

        [NotMapped]
        public List<Status> StatusSelect { get; set; }

        public virtual CustomerGroup CustomerGroup { get; set; }
        public class BaseEntity
        {
            public Nullable<DateTime> Created_date { get; set; }
            public Nullable<DateTime> Modified_date { get; set; }
        }
    }
}