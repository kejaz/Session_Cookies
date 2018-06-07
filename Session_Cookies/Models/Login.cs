using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Session_Cookies.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage ="User Id is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}