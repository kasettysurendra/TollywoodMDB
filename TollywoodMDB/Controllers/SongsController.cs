using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;
using TollywoodMDB.Models.ViewModel;

namespace TollywoodMDB.Controllers
{
    public class SongsController : Controller
    {
        // GET: Songs
        [HttpGet]
        public ActionResult Index()
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movieIdArr = (from id in objContext.Songs orderby id.ReleaseDate select id.MovieId).Distinct().ToArray();
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            Dictionary<int, string> dictionary=new Dictionary<int, string>();
            foreach (var id in movieIdArr)
            {
                var movie = objContext.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                string value = string.Format("{0} - ({1})", movie.Movie_Name, movie.Movie_Release_Date.Year);
                dictionary.Add(id, value);
            }
            maid.DictionaryValues = dictionary;
            return View(maid);
        }

        [HttpGet]
        public ActionResult AddSongs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSongs(Songs song)
        {
            if (ModelState.IsValid)
            {
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                objContext.Songs.Add(song);
                objContext.SaveChanges();
                return View();
            }
            else {
                ModelState.AddModelError("error", "invalid data entered");
                return View();
            }
        }

        public ActionResult SongsView(int movieId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var songs = from s in objContext.Songs where s.MovieId == movieId select s;
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Songs = songs.ToList();
            return PartialView("_Songs", maid);
        }

        [HttpGet]
        public ActionResult UploadAudio()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult UploadAudio(SongAudioFilesViewModel savm)
        {
            if (ModelState.IsValid)
            {
                SongAudios songAudios = new SongAudios();
                songAudios.SongId = savm.SongId;
                byte[] convertAudioToBytes = new byte[savm.AudioFile.InputStream.Length];
                savm.AudioFile.InputStream.Read(convertAudioToBytes, 0, convertAudioToBytes.Length);
                songAudios.AudioFile = convertAudioToBytes;
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                objContext.SongAudios.Add(songAudios);
                objContext.SaveChanges();
                return View();
            }
            else {
                ModelState.AddModelError("UploadAudio","please enter valid data");
                return View();
            }
        }

        public FileResult GetAudio(int SongId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext(); 
            SongAudios audio = objContext.SongAudios.Where(a => a.SongId == SongId).FirstOrDefault();
            return  File(audio.AudioFile,"audio/mp3");
        }

        [HttpGet]
        public ActionResult MovieSongs(int id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movie = objContext.Movies.Where(m => m.MovieId == id).FirstOrDefault();

            return View(movie);
        }
    }
}