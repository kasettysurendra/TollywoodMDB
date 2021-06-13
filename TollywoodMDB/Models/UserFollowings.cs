using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TollywoodMDB.Models
{
    public class UserFollowings
    {
        [Key]
        //public int FollowId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoginId { get; set; }
        [Required]
        public int Actor_Id { get; set; }
        [Required]
        public DateTime FollowStartDate { get; set; }

    }
}