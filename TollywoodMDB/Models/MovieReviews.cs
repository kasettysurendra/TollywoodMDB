using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class MovieReviews
    {
        [Key]
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int MovieId { get; set; }
    }   
}   