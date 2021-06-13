using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models.ViewModel
{
    public class SongAudioFilesViewModel
    {
        
        public int AudioId { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public HttpPostedFileBase AudioFile { get; set; }
    }
}