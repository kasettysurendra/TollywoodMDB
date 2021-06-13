using System;
using System.Drawing;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;
using TollywoodMDB.Models.ViewModel;
namespace TollywoodMDB.Controllers
{
    public class MoviesController : Controller
    {
        TollywoodMDBcontext objContext = new TollywoodMDBcontext();
        // GET: Movies
        [CustomAuthFilter]  
        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult AddMovie(Movies movie)
        {
                movie.Movie_Genre.ToString();
                objContext.Movies.Add(movie);
                objContext.SaveChanges();
                return RedirectToAction("MovieImage",new { id=movie.MovieId});
        }

        public ActionResult Index()
        {
            ViewBag.pageIndex = 1;
            ViewBag.startPageIndex = 1;
            int count = 0;
            var movies = (from m in objContext.Movies orderby m.Movie_Release_Date descending select m).Skip(count).Take(5);
            Models.MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies=movies.ToList();
            ViewBag.movieCount = count+5;
            return View(maid);
        }

        [Route("Movies/Index/{count}/{pageIndex}")]
        public ActionResult Index(int count,int pageIndex)
            {
            if (pageIndex % 5 == 0)
            {
                ViewBag.pageIndexCss = pageIndex + 1;
            }
            else {
                ViewBag.pageIndexCss = pageIndex;
            }
            ViewBag.startPageIndex = 1;
            int totalMovies = (from m in objContext.Movies select m).Count();
            if ((count-5) <= totalMovies)
            {

                for (int i = 1; i <= pageIndex; i++)
                {
                    if ((i % 5) == 0)
                    {
                        ViewBag.startPageIndex = i + 1;
                    }                  
                }
                var movies = (from m in objContext.Movies orderby m.Movie_Release_Date descending select m).Skip(count-5).Take(5);
                Models.MovieAndImagesDetails maid = new MovieAndImagesDetails();
                ViewBag.movieCount = count + 5;
                maid.Movies = movies.ToList();
                return View(maid);
            }
            else
            {
                return RedirectToAction("Index",new { count=5, pageIndex =1});
            }
        }

        public ActionResult MovieDetails(int? Id)
        {
            if (Id == 0)
                Id = 1;
            var movie= objContext.Movies.Where(m => m.MovieId == Id).FirstOrDefault();
            movie.Views += 1;
            var Comments = from mr in objContext.MovieReviews where (mr.MovieId == Id) select mr;
            ViewBag.commentsCount = Comments.Count();
            ViewBag.TotalRateCount = (from rates in objContext.MovieRatings where rates.MovieId == Id select rates).Count();
            objContext.SaveChanges();
            var data = from mrdata in objContext.MovieReleatedData where mrdata.MovieId == movie.MovieId select mrdata;
            MovieDetailsViewModel mdvm = new MovieDetailsViewModel();
            mdvm.Movies = movie;
            foreach (var datarow in data)
            {
                mdvm.MovieReleatedData.Add(datarow);
            }
            return View(mdvm);
        }

        public ActionResult GetImage(int? Id)
        {
            if (Id == 0)
                Id = 1;
            MovieImages movie = objContext.MovieImages.Where(m => m.MovieId == Id).FirstOrDefault();
            return File(movie.Movie_Icon, "image/jpeg");
        }

        public ActionResult GetImageBackground(int? Id)
        {
            if (Id == 0)
                Id = 1;
            MovieImages movie = objContext.MovieImages.Where(m => m.MovieId == Id).FirstOrDefault();
            return File(movie.Movie_Background, "image/jpeg");
        }

        [HttpGet]
        public ActionResult MovieImage(int id)
        {

            MovieFilesViewModel mfvm = new MovieFilesViewModel();
            mfvm.Movie_id = id;
            return View(mfvm);

        }

        [HttpPost]
        public ActionResult MovieImage(MovieFilesViewModel moviefileviewmodel)
        {
            
            MovieImages mis = new MovieImages();
            mis.MovieId = moviefileviewmodel.Movie_id;
            byte[] file1 = new byte[moviefileviewmodel.icon_file[0].InputStream.Length];
            moviefileviewmodel.icon_file[0].InputStream.Read(file1, 0, file1.Length);
            byte[] file2 = new byte[moviefileviewmodel.icon_file[1].InputStream.Length];
            moviefileviewmodel.icon_file[1].InputStream.Read(file2, 0, file2.Length);
            MovieImages mi = new MovieImages {
                Movie_Icon = file1,
                Movie_Background = file2,
                MovieId = moviefileviewmodel.Movie_id };
            objContext.MovieImages.Add(mi);
            objContext.SaveChanges();
            return View(moviefileviewmodel);
        
        }

        [HttpPost]
        public JsonResult MovieLiked(int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movie = objContext.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            movie.Likes += 1;
            objContext.SaveChanges();
            return Json(string.Format("you liked the movie {0}", movie.Movie_Name),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MovieDisLiked(int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movie = objContext.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            movie.DisLikes += 1;
            objContext.SaveChanges();
            return Json(string.Format("you disliked the movie {0}", movie.Movie_Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MovieRelatedData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MovieRelatedData( MovieReleatedData movieData)
        {
            //movieData.Data = Request.Unvalidated.Form["Data"];
            objContext.MovieReleatedData.Add(movieData);
            objContext.SaveChanges();
            return Content("success");
        }
    }
}