using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        public int MovieId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public string SongSingers { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
       
    }
}