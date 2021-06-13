using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;

namespace TollywoodMDB.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        [CustomAuthFilter]
        public ActionResult AddVideos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVideos(MovieVideos movieVideos)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            objContext.MovieVideos.Add(movieVideos);
            objContext.SaveChanges();
            return View();
        }
        [HttpPost]
        public PartialViewResult VideosView(int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movieVideos = from mv in objContext.MovieVideos where mv.MovieId==id select mv;
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.MovieVideos = movieVideos.ToList();
            return PartialView("_videos", maid);
        }
    }
}