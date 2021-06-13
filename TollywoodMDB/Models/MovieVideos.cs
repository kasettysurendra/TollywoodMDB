using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class MovieVideos
    {
        [Key]
        public int MovieVideoId { get; set; }
        public int MovieId { get; set; }
        [StringLength(100)]
        [Required]
        public string VideoTitle { get; set; }
        [Required]
        public string VideoEmbedURl { get; set; }
    }
}