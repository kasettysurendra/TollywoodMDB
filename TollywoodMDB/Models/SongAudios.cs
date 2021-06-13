using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class SongAudios
    {
        [Key]
        public int AudioId { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public byte[] AudioFile { get; set; }
    }
}