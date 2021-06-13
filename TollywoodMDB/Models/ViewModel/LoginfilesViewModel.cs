using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models.ViewModel
{
    public class LoginfilesViewModel
    {
        public int id { get; set; }
        public HttpPostedFileBase ProfilePicture { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}