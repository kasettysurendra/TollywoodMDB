using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TollywoodMDB.Models.ViewModel
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Password field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ConfirmPassword { get; set; }
    }
}