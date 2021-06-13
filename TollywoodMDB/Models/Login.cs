using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class Logins
    {
        [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage ="Mandatory field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="invalid Email")]
        public String EmailId { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Password { get; set; }
        public bool NewsLetter { get; set; }
        public string Role { get; set; }

    }
}