using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TollywoodMDB.Models
{
    public class UserFollowers
    {
        [Key]
        public int FollowId { get; set; }
        [Required]
        public int LoginId { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int FollowerId { get; set; }
        [Required]
        [StringLength(1)]
        public string RequestStatus { get; set; }
        public DateTime SentDate { get; set; }
        [StringLength(1)]
        public string ReadStatus { get; set; }
    }
}