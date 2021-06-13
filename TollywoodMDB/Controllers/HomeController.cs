using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;

namespace TollywoodMDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movies = (from m in objContext.Movies orderby m.Movie_Release_Date descending select m).Take(15);
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies = movies.ToList();
            var movieIdArr = (from id in objContext.Songs select id.MovieId).Distinct().Take(18).ToArray();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (var id in movieIdArr)
            {
                var movie = objContext.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                string value = string.Format("{0} - ({1})", movie.Movie_Name, movie.Movie_Release_Date.Year);
                dictionary.Add(id, value);
                maid.DictionaryValues = dictionary;
            }
            
            return View(maid);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}