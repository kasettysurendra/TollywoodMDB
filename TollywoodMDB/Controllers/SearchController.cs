using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;

namespace TollywoodMDB.Controllers
{
    public class SearchController : Controller
    {
        TollywoodMDBcontext objContext = new TollywoodMDBcontext();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SearchTemplete(Search search)
        {
            return PartialView("_SearchTemplete", search);
        }

        [HttpPost]
        public JsonResult AutoComplete(string searchText)
        {
            var movieNames = from m in objContext.Movies where m.Movie_Name.Contains(searchText) select m;
            
            return Json(movieNames.ToArray(),JsonRequestBehavior.AllowGet);
        }

        [Route("Search/SearchMovie")]
        [HttpPost]
        public ActionResult SearchMovie(Search search)
        {
            IEnumerable<Movies> allMovies=null;
            if (!string.IsNullOrEmpty(search.SearchText) && search.genre.ToString()!="Select" && search.sortBy.ToString()!="Select")
            {
                allMovies = from movie in objContext.Movies
                            where (movie.Movie_Name.Contains(search.SearchText) && movie.Movie_Genre.ToString().Contains(search.genre.ToString())
                                  )
                            orderby search.sortBy.ToString()=="Name"?movie.Movie_Name:movie.Movie_Release_Date.ToString()
                            select movie;
            }
            else if (!string.IsNullOrEmpty(search.SearchText) && search.genre.ToString() != "Select" && search.sortBy.ToString() == "Select")
            {
                allMovies = from m in objContext.Movies
                            where (m.Movie_Name.Contains(search.SearchText)&&m.Movie_Genre.ToString().Contains(search.genre.ToString()))
                            select m;
            }
            else if (!string.IsNullOrEmpty(search.SearchText) && search.genre.ToString() == "Select" && search.sortBy.ToString() != "Select")
            {
                allMovies = from m in objContext.Movies
                            where m.Movie_Name.Contains(search.SearchText)
                            orderby search.sortBy.ToString() == "Name" ? m.Movie_Name : m.Movie_Release_Date.ToString()
                            select m;
            }
            else if (!string.IsNullOrEmpty(search.SearchText) && search.genre.ToString() == "Select" && search.sortBy.ToString() == "Select")
            {
                allMovies = from m in objContext.Movies
                            where m.Movie_Name.Contains(search.SearchText)
                            select m;
            }
            else if (string.IsNullOrEmpty(search.SearchText)&& search.genre.ToString() != "Select" && search.sortBy.ToString() != "Select")
            {
                allMovies = from m in objContext.Movies
                            where m.Movie_Genre.ToString().Contains(search.genre.ToString())
                            orderby search.sortBy.ToString() == "Name" ? m.Movie_Name : m.Movie_Release_Date.ToString()
                            select m;
            }
            else if (string.IsNullOrEmpty(search.SearchText) && search.genre.ToString() != "Select" && search.sortBy.ToString() == "Select")
            {
                allMovies = from m in objContext.Movies
                            where m.Movie_Genre.ToString().Contains(search.genre.ToString())
                            select m;
            }
            else if (string.IsNullOrEmpty(search.SearchText) && search.genre.ToString() == "Select" && search.sortBy.ToString() != "Select")
            {
                allMovies = from m in objContext.Movies
                            orderby search.sortBy.ToString() == "Name" ? m.Movie_Name : m.Movie_Release_Date.ToString()
                            select m;
            }
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies = allMovies.ToList();
            return View(maid);
        }

        public ActionResult MenuSearchMovie( string searchText)
        {
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies = (from m in objContext.Movies where m.Movie_Name.Contains(searchText) select m).ToList();
            return View(maid);
        }

        [ChildActionOnly]
        public PartialViewResult MovieCategory()
        {
            ViewBag.Action = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Action") select m).Count();
            ViewBag.Adventure = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Adventure") select m).Count();
            ViewBag.Animation = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Animation") select m).Count();
            ViewBag.Biopics = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Biopics") select m).Count();
            ViewBag.Comedy = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Comedy") select m).Count();
            ViewBag.Drama = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Drama") select m).Count();
            ViewBag.Documentary = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Documentary") select m).Count();
            ViewBag.Thriller = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Thriller") select m).Count();
            ViewBag.Romantic = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("Romantic") select m).Count();
            ViewBag.ScienceFiction = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains("ScienceFiction") select m).Count();
            return PartialView("_MovieCategory");
        }

        public ActionResult MovieCategoryFilter(string FilterBy )
        {
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies = (from m in objContext.Movies where m.Movie_Genre.ToString().Contains(FilterBy) select m).ToList();
            return View(maid);
        }
        
    }
}