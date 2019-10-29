using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopNotchGlobal.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
       [Display(Name = "Password")] public string Hash { get; set; }
        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}