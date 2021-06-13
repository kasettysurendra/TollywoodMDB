using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TollywoodMDB.Models
{
    public enum Gender {Male,Female,Others}
    public enum Occupation {Hero,Comedian,Heroin,CharacterArtist}
    public class Actors
    {
       
        [Key]
        public int Actor_Id { get; set; }
        [Required]
        public string Actor_Name { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public Gender Actor_Gender { get; set; }
        public string Actor_Address { get; set; }
        public string Actor_Twitter_Id { get; set; }
        public string Actor_Facebook_Id { get; set; }
        public Occupation Actor_Occupation { get; set; }
    }
}