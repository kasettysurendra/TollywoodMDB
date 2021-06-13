using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TollywoodMDB.Models;
using TollywoodMDB.Models.ViewModel;

namespace TollywoodMDB.Models
{
    public class MovieAndImagesDetails
    {
        public List<Movies> Movies { get; set; }
        public List<MovieImages> MovieImages { get; set; }
        public List<MovieReviews> MovieReviews { get; set; }
        public List<ReviewReplys> ReviewReplys { get; set; }
        public List<Actors> Actors { get; set; }
        public List<Songs> Songs { get; set; }
        public List<MovieVideos> MovieVideos { get; set; }
        public List<UserFollowings> UserFollowings { get; set; }
        public Dictionary<int,string> DictionaryValues { get; set; }
        public List<IdNameStatus> IdNameStatus { get; set; }
    }
}