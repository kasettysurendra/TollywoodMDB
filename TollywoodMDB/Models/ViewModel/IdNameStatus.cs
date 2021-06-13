using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models.ViewModel
{
    public class IdNameStatus
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string FlollowStatus { get; set; }
        public string ReadStatus { get; set; }
        public DateTime StatusDate { get; set; }
    }
}