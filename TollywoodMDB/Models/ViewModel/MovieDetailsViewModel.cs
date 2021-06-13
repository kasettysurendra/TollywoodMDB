using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models.ViewModel
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsViewModel() {
            this.MovieReleatedData = new List<Models.MovieReleatedData>();
        }
        public Movies Movies { get; set; }
        public List<MovieReleatedData> MovieReleatedData { get; set; }
    }
}