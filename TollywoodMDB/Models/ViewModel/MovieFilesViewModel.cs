using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models.ViewModel
{
    public class MovieFilesViewModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "please enter a valid id")]
        public int Movie_id { get; set; }
        [Required(ErrorMessage ="please select atleast one file")]
        public HttpPostedFileBase[] icon_file { get; set; }
    }
}