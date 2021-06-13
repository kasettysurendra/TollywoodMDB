using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TollywoodMDB.Models
{
    public class LoginFiles
    {
        [Key]
        //public int FileId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoginId { get; set; }
        [Required]
        public byte[] ProfilePicture { get; set; }
        public DateTime UploadedDate { get; set; }
    }
   
    
}