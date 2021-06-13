using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TollywoodMDB.Models
{
    public class ActorFiles
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ActorFileID { get; set; }
        [Required(ErrorMessage ="Please enter valid Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Actor_Id { get; set; } 
        [Required(ErrorMessage ="Please select atleast one file")]
        public byte[] ActorProfilePic { get; set; }
    }
}