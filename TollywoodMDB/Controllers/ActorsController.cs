using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;
using TollywoodMDB.Models.ViewModel;

namespace TollywoodMDB.Controllers
{
    public class ActorsController : Controller
    {
        // GET: Actors
        [HttpGet]
        public ActionResult AddActor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddActor(ActorAndActorFilesViewModel ActorAndActorFiles)
        {
            if (ModelState.IsValid)
            {
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                Actors actors = new Actors();
                actors.Actor_Name = ActorAndActorFiles.Actors.Actor_Name;
                actors.Date_Of_Birth = ActorAndActorFiles.Actors.Date_Of_Birth;
                actors.Actor_Gender = ActorAndActorFiles.Actors.Actor_Gender;
                actors.Actor_Twitter_Id = ActorAndActorFiles.Actors.Actor_Twitter_Id;
                actors.Actor_Facebook_Id = ActorAndActorFiles.Actors.Actor_Facebook_Id;
                actors.Actor_Address = ActorAndActorFiles.Actors.Actor_Address;
                objContext.Actors.Add(ActorAndActorFiles.Actors);
                objContext.SaveChanges();
                if (ActorAndActorFiles.ActorFilesViewModel.ActorProfilePicture != null) {
                    Actors currentActor = (from a in objContext.Actors where a.Actor_Name == actors.Actor_Name select a).FirstOrDefault();
                    ActorFiles Af = new ActorFiles();
                    Af.Actor_Id = currentActor.Actor_Id;
                    byte[] bytes = new byte[ActorAndActorFiles.ActorFilesViewModel.ActorProfilePicture.InputStream.Length];
                    ActorAndActorFiles.ActorFilesViewModel.ActorProfilePicture.InputStream.Read(bytes, 0, bytes.Length);
                    Af.ActorProfilePic = bytes;
                    objContext.ActorFiles.Add(Af);
                    objContext.SaveChanges();
                }
                return View();
            }
            else {
                ModelState.AddModelError("ActorDetailsError","Actor Details Are Invalid");
                return View();
            }
        }

        public ActionResult ActorDetails(string ActorName)
        {
            if (string.IsNullOrEmpty(ActorName))
            {
                return View("No Results found");
            }
            else
            {
                int userId = Convert.ToInt32(Session["UserId"]as string);
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                Actors actor = objContext.Actors.Where(a => a.Actor_Name == ActorName).FirstOrDefault();
                ActorAndActorFilesViewModel ActorAndActorFiles = new ActorAndActorFilesViewModel();
                ActorAndActorFiles.Actors = actor;
                var moviesDone = from md in objContext.Movies where md.Movie_Cast.Contains(ActorName) select md;
                ViewBag.MoviesCount = moviesDone.Count();
                ViewBag.FollowersCount = (from uf in objContext.UserFollowings where uf.Actor_Id == actor.Actor_Id select uf).Count();
                var Followcheck = (from uf in objContext.UserFollowings where (uf.Actor_Id == actor.Actor_Id && uf.LoginId == userId) select uf).FirstOrDefault();
                if (Followcheck != null)
                    ViewBag.FollowStatus = true;
                else
                    ViewBag.FollowStatus = false;

                return View(ActorAndActorFiles);
            }
        }

        public ActionResult GetImage(int ActorId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            byte[] ProfilePicture;
            if (((from af in objContext.ActorFiles select af.Actor_Id).ToArray().Contains(ActorId)))
            {
                ProfilePicture = objContext.ActorFiles.Where(af => af.Actor_Id == ActorId).FirstOrDefault().ActorProfilePic;
                return File(ProfilePicture, "image/jpeg");
            }
            else
            {
                ProfilePicture = objContext.LoginFiles.Where(af => af.LoginId == 2).FirstOrDefault().ProfilePicture;
                return File(ProfilePicture, "image/jpeg");
            }

        }

        [HttpPost]
        public PartialViewResult AllMovies(string actorName)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var movies = from m in objContext.Movies where m.Movie_Cast.Contains(actorName) select m;
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.Movies = movies.ToList();
            return PartialView("_DisplayMovie",maid);
        }
        [HttpPost]
        public JsonResult Follow(int ActorId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            int userId= Convert.ToInt32(Session["UserId"]as string);
            if (userId != 0)
            {
                var Followcheck = (from uf in objContext.UserFollowings where (uf.Actor_Id == ActorId && uf.LoginId == userId) select uf).FirstOrDefault();
                if (Followcheck == null)
                {
                    UserFollowings uf = new UserFollowings();
                    uf.LoginId = userId;
                    uf.FollowStartDate = DateTime.Now;
                    uf.Actor_Id = ActorId;
                    objContext.UserFollowings.Add(uf);
                    objContext.SaveChanges();
                    return Json("1");
                }
                else
                {
                    return Json("You are already Following this actor");
                }
            }
            else {
                return Json("Please login to follow");
            }
            
        }

        public JsonResult Unfollow(int ActorId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            int userId = Convert.ToInt32(Session["UserId"] as string);
            var Followcheck = (from uf in objContext.UserFollowings where (uf.Actor_Id == ActorId && uf.LoginId == userId) select uf).FirstOrDefault();
            if (userId != 0)
            {
                objContext.UserFollowings.Remove(Followcheck);
                objContext.SaveChanges();
                return Json("you are not following this actor now");
            }
            else {
                return Json("Error Occured");
            }
        }
        [HttpGet]
        public ActionResult ActorImageUpload()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ActorImageUpload(ActorAndActorFilesViewModel aaaf)
        {
            if (ModelState.IsValid)
            {
                ActorFiles af = new ActorFiles();
                af.Actor_Id = aaaf.ActorFilesViewModel.ActorId;
                byte[] bytes = new byte[aaaf.ActorFilesViewModel.ActorProfilePicture.InputStream.Length];
                aaaf.ActorFilesViewModel.ActorProfilePicture.InputStream.Read(bytes, 0, bytes.Length);
                af.ActorProfilePic = bytes;
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                objContext.ActorFiles.Add(af);
                objContext.SaveChanges();
                ViewBag.PopUpStatus = "Update Successful";
                return View();
            }
            else {
                ModelState.AddModelError("error","Invalid Details");
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult TotalFollowers(int ActorId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var userid = Convert.ToInt32(Session["Userid"] as string);
            var totalFollowers = (from uf in objContext.UserFollowings where uf.Actor_Id == ActorId select uf).
                Except(from uf in objContext.UserFollowings where uf.LoginId == userid select uf).ToList();
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.IdNameStatus = new List<IdNameStatus>();
            foreach (var uf in totalFollowers)
            {
                IdNameStatus ids = new IdNameStatus();
                var user = (from l in objContext.Logins where l.LoginId == uf.LoginId select l).FirstOrDefault();
                ids.Username = string.Format("{0} {1}", user.FirstName, user.LastName);
                ids.id = user.LoginId;

                var followstatus = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == user.LoginId && uf1.LoginId == userid) select uf1).FirstOrDefault();
                if (followstatus != null)
                {

                    ids.FlollowStatus = followstatus.RequestStatus;
                }
                else
                {
                    ids.FlollowStatus = "N";
                }
                maid.IdNameStatus.Add(ids);
            }
            return PartialView("_TotalFollowers", maid);
        }

        [ChildActionOnly]
        public PartialViewResult ListOfActors()
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            ListOfActorsViewModel listOfActors = new ListOfActorsViewModel();

            var TopActors = (from a in objContext.Actors where 
                              ((a.Actor_Occupation==Occupation.Hero) || (a.Actor_Occupation==Occupation.Heroin))
                              select a);
            var alphaChars = (from ac in TopActors select ac.Actor_Name.Substring(0, 1)).Distinct().ToArray();

            listOfActors.AlphabetCategory = new string[alphaChars.Count()];
            listOfActors.AlphabetCategory = alphaChars;
            listOfActors.ActorNames = (from an in TopActors select an.Actor_Name).ToArray();
           
            return PartialView("_listOfActors",listOfActors);
        }
    }
}