using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models.ViewModel
{
    public class ActorFilesViewModel
    {
        [Required(ErrorMessage = "Please enter valid Id")]
        public int ActorId { get; set; }
        [Required(ErrorMessage = "Please select atleast one file")]
        public HttpPostedFileBase ActorProfilePicture { get; set; }
    }
}