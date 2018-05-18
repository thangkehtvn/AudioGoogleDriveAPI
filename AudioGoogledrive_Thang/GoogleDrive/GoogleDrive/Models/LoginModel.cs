using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoogleDrive.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Error username")]
        public String username { set; get; }
        [Required(ErrorMessage = "Error password")]
        public String password { set; get; }
    }
}