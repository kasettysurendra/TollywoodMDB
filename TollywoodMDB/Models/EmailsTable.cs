using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models
{
    public class EmailsTable
    {
        [Key]
        public int EmailID { get; set; }
        public string Description { get; set; }
        public string EmailContent { get; set; }
        public DateTime EntryDate { get; set; }
    }
}