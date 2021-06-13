using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models
{
    public enum SortBy { Select, Name, ReleaseDate }
    public class Search
    {
        SortBy objSortBy;
        MovieGenre objGenre;
        public string SearchText { get; set; }
        public MovieGenre genre
        {
            get { return objGenre; }
            set { objGenre = value; }
        }
        public SortBy sortBy
        {
            get { return objSortBy; }
            set { objSortBy = value; }
        }
    }
}