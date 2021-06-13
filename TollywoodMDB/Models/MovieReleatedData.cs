using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TollywoodMDB.Models
{
   public enum MovieDataType {Tweet,News,Collections,Others}
    public class MovieReleatedData
    {
        [Key]
        public int DataId { get; set; }
        [Required]
       
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movies Movies { get; set; }

        public MovieDataType DataCategory { get; set; }
        public string DataSubCategory { get; set; }
        [AllowHtml]
        public string Data { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}