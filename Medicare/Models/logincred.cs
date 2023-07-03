using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicare.Models
{
    public class logincred
    {
        [Display(Name = "UserName")]
        [Required]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}