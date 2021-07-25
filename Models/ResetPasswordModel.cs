using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    public class ResetPasswordModel
    {
        [Key]
        public int MyProperty { get; set; }
        [Required(ErrorMessage = "New Password required!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "New Password required!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password does not match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }
    }
}