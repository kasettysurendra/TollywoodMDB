using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public enum MovieGenre { Select,Action, Adventure, Animation, Biopics, Comedy, Drama, Documentary, Thriller, Romantic, ScienceFiction }

   

    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [StringLength(100)]
        public string Movie_Name { get; set; }
        [StringLength(50)]
        public string Movie_Language { get; set; }
        public string Movie_Cast { get; set; }
        public string Movie_decription { get; set; }
        public string MovieDirector { get; set; }
        public string MusicDirector { get; set; }
        public float Movie_ratings { get; set; }
        public DateTime Movie_Release_Date { get; set; }
        public MovieGenre Movie_Genre { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public float Rating { get; set; }
        public int Votes { get; set; }
    }
}   