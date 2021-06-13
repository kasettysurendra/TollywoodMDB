using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace TollywoodMDB.Models
{
    public class MovieImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        public byte[] Movie_Icon { get; set; }
        public byte[] Movie_Background { get; set; }
    }
}