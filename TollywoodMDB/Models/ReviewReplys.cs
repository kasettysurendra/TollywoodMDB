using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public class ReviewReplys
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        public string Reply { get; set; }
        
        public DateTime ReplyDate { get; set; }

        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}