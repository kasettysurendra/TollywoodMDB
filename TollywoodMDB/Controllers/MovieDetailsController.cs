using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;

namespace TollywoodMDB.Controllers
{
    public class MovieDetailsController : Controller
    {
        // GET: MovieDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Reviews(int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            var allMovieReviews = from r in objContext.MovieReviews where r.MovieId == id select r;  
            maid.MovieReviews = allMovieReviews.ToList();
            var allcomments = from rr in objContext.ReviewReplys where rr.MovieId == id select rr;
            maid.ReviewReplys = allcomments.ToList();
            var allMovies = from m in objContext.Movies where m.MovieId == id select m;
            maid.Movies = allMovies.ToList();
            // To get all the user id's and to store them in a key value pair

            var allMovieReviewsUsers = (from r in objContext.MovieReviews where r.MovieId == id select r.UserId).Distinct().ToArray();
            Dictionary<int, string> UserIdNames = new Dictionary<int, string>();
            foreach (var userid in allMovieReviewsUsers)
            {
                var name = objContext.Logins.Where(l => l.LoginId == userid).FirstOrDefault();
                if(name!=null)
                UserIdNames.Add(name.LoginId, string.Format("{0} {1}", name.FirstName, name.LastName));
            }
            // To get all the user id's and to store them in a key value pair

            var allcommentsUsers = (from rr in objContext.ReviewReplys where rr.MovieId == id select rr.UserId).Distinct().ToArray(); ;
            foreach (var userid in allcommentsUsers)
            {
                if (userid != 0)
                {
                    if (!UserIdNames.Keys.Contains(userid))
                    {
                        var name = objContext.Logins.Where(l => l.LoginId == userid).First();
                        UserIdNames.Add(name.LoginId, string.Format("{0} {1}", name.FirstName, name.LastName));
                    }
                }
            }
            maid.DictionaryValues = UserIdNames;
            return PartialView("_Reviews",maid);
        }
        [HttpPost]
        public JsonResult ReplyUpdate(int commentId,string comment,int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            ReviewReplys rr = new ReviewReplys();
            rr.CommentId = commentId;
            rr.Reply = comment;
            rr.ReplyDate = DateTime.Now;
            rr.MovieId = id;
            if (string.IsNullOrEmpty(Session["UserEmail"] as string))
            {
                rr.UserId = 0;

            }
            else
            {
                var userEmail = Session["UserEmail"] as string;
                var UserId = objContext.Logins.Where(l => l.EmailId == userEmail).FirstOrDefault().LoginId;
                rr.UserId = UserId;
            }
            objContext.ReviewReplys.Add(rr);
            objContext.SaveChanges();
            return Json("comment submitted");
        }

        [HttpPost]
        public JsonResult ReviewUpdate(int id,string Comment)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            MovieReviews movieReviews = new MovieReviews();
            movieReviews.MovieId = id;
            if (string.IsNullOrEmpty(Session["UserEmail"] as string))
            {
                movieReviews.UserId = 0;

            }
            else {
                var userEmail = Session["UserEmail"] as string;
              var UserId=  objContext.Logins.Where(l => l.EmailId == userEmail).FirstOrDefault().LoginId;
                movieReviews.UserId = UserId;
            }
            movieReviews.Comment = Comment;
            movieReviews.CommentDate = DateTime.Now;
            objContext.MovieReviews.Add(movieReviews);
            objContext.SaveChanges();
            return Json("review Submitted");
        }

        [HttpPost]
        public JsonResult RateMovie(int movieId,int ratingValue)
        {
            var userEmail = Session["UserEmail"] as string;
           
            if (!string.IsNullOrEmpty(userEmail))
            {
                var userId = Convert.ToInt32(Session["UserId"] as string);
               TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                var isAlreadyRated = (from mr in objContext.MovieRatings where (mr.LoginId == userId && mr.MovieId == movieId) select mr).FirstOrDefault();
                if (isAlreadyRated==null)
                {
                    MovieRatings movieRatings = new MovieRatings();
                    movieRatings.MovieId = movieId;
                    movieRatings.LoginId = userId;
                    movieRatings.Rating = ratingValue;
                    movieRatings.RatedDate = DateTime.Now;
                    objContext.MovieRatings.Add(movieRatings);
                    objContext.SaveChanges();
                    var totalratings = (from mr in objContext.MovieRatings where mr.MovieId == movieId select mr.Rating).ToArray();
                    float finalRating=0;
                    foreach (var rating in totalratings)
                    {
                        finalRating += rating;
                    }
                    finalRating = finalRating / totalratings.Count();
                    Movies movie = (from m in objContext.Movies where m.MovieId == movieId select m).FirstOrDefault();
                    movie.Movie_ratings = finalRating;
                    objContext.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();
                    return Json("You have given " + ratingValue + " star(s)");
                }
                else
                {
                   return Json("You have already rated this movie");
                }
            }
            else {
               return Json("Please login to rate");
            }

        }
       
    }
}