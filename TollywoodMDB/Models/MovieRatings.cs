using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TollywoodMDB.Models
{
    public class MovieRatings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int LoginId { get; set; }
        public DateTime RatedDate { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}