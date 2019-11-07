using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TopNotchGlobal.Models
{
    public class RegistrationModel
    {
        public string Message { get; set; }
        [Required]//here we are using data annotations to limit and constraint certain things in our project
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(Constants.MaxUserNameLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = Constants.MinUserNameLength )]
        //[DataType(DataType.Text)]
       // [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        //[StringLength(Constants.MaxPasswordLength, ErrorMessage = "The Password must be between {0} and {1} characters long.", MinimumLength = Constants.MinPasswordLength)]
        //[RegularExpression(Constants.PasswordRequirements, ErrorMessage = Constants.PasswordRequirementsMessage)]
        //[DataType(DataType.Password)]
  
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
         public string Hash { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Re-Enter Password")]
        public string PasswordAgain { get; set; }
        public string ReturnURL { get; set; }
        
    }

}