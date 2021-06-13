using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TollywoodMDB.Models;
using TollywoodMDB.Models.ViewModel;

namespace TollywoodMDB.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        TollywoodMDBcontext objContext = new TollywoodMDBcontext();

        public ActionResult Index()
        {
            bool loginStatus = string.IsNullOrEmpty(Session["UserEmail"] as string);
            if (loginStatus)
            {
                return RedirectToAction("Register", "Login");
            }
            else
            {
                string email = Session["UserEmail"].ToString();
                LoginandLoginFiles LoginandLoginFiles = new LoginandLoginFiles();
                Logins user = objContext.Logins.Where(u => u.EmailId == email).FirstOrDefault();
                LoginandLoginFiles.Login = user;
                ViewBag.RequestCount = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == user.LoginId && uf1.RequestStatus == "P") select uf1).Count();
                ViewBag.otherNotifications = (from uf1 in objContext.UserFollowers where (uf1.LoginId == user.LoginId && uf1.ReadStatus == "N") select uf1).Count();
                return View(LoginandLoginFiles);
            }
        }

        [HttpPost]
        public ActionResult Index(LoginandLoginFiles User)
        {
            string email = Session["UserEmail"].ToString();
            Logins login = objContext.Logins.Where(u => u.EmailId == email).FirstOrDefault();
            login.FirstName = User.Login.FirstName;
            login.LastName = User.Login.LastName;
            login.NewsLetter = User.Login.NewsLetter;
            objContext.Entry(login).State = System.Data.Entity.EntityState.Modified;
            if (User.LoginfilesViewModel.ProfilePicture != null)
            {
                if (objContext.LoginFiles.Where(u => u.LoginId == login.LoginId).FirstOrDefault() == null)
                {
                    LoginFiles lf = new LoginFiles();
                    lf.LoginId = login.LoginId;
                    lf.UploadedDate = DateTime.Now;
                    byte[] bytes = new byte[User.LoginfilesViewModel.ProfilePicture.InputStream.Length];
                    User.LoginfilesViewModel.ProfilePicture.InputStream.Read(bytes, 0, bytes.Length);
                    lf.ProfilePicture = bytes;
                    objContext.LoginFiles.Add(lf);
                }
                else
                {
                    LoginFiles loginfiles = objContext.LoginFiles.Where(u => u.LoginId == login.LoginId).FirstOrDefault();
                    byte[] bytes = new byte[User.LoginfilesViewModel.ProfilePicture.InputStream.Length];
                    User.LoginfilesViewModel.ProfilePicture.InputStream.Read(bytes, 0, bytes.Length);
                    loginfiles.ProfilePicture = bytes;
                    objContext.Entry(loginfiles).State = System.Data.Entity.EntityState.Modified;
                }
            }
            objContext.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult ChangePassword(LoginandLoginFiles User) {
            string email = Session["UserEmail"]as string;
            if (!string.IsNullOrEmpty(email))
            {
                Logins login = objContext.Logins.Where(u => u.EmailId == email).FirstOrDefault();
                //assign user to view ,if not view will throw object reference error
                User.Login = login;
                ViewBag.RequestCount = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == login.LoginId && uf1.RequestStatus == "P") select uf1).Count();
                ViewBag.otherNotifications = (from uf1 in objContext.UserFollowers where (uf1.LoginId == login.LoginId && uf1.ReadStatus == "N") select uf1).Count();
                AesEncDec dec = new AesEncDec();
                if (!string.IsNullOrEmpty(User.ChangePasswordModel.Password))
                {
                    string encPassword = dec.AesEnc(User.ChangePasswordModel.Password);
                    if (encPassword == login.Password)
                    {
                        string newPassword = dec.AesEnc(User.ChangePasswordModel.NewPassword);
                        if (!(newPassword == login.Password))
                        {
                            if ((User.ChangePasswordModel.NewPassword == User.ChangePasswordModel.ConfirmPassword) && (!string.IsNullOrEmpty(User.ChangePasswordModel.NewPassword)))
                            {
                                login.Password = newPassword;
                                objContext.Entry(login).State = System.Data.Entity.EntityState.Modified;
                                objContext.SaveChanges();
                                ViewBag.PopUpStatus = "Password changed successfully";
                                return View("Index", User);
                            }
                            else
                            {
                                ViewBag.PopUpStatus = "Passwords didn't match";
                                return View("Index", User);
                            }

                        }
                        else
                        {
                            ViewBag.PopUpStatus = "Current and new password cannot be same";
                            return View("Index", User);
                        }
                    }
                    else
                    {
                        ViewBag.PopUpStatus = "Current password entered wrong";
                        return View("Index", User);
                    }
                }
                else
                {
                    ViewBag.PopUpStatus = "Current password entered wrong";
                    return View("Index", User);
                }
            }
            else{
                return RedirectToAction("Index","User");
            }
        }

        [HttpPost]
        public JsonResult Follow(int Followerid)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            int userId = Convert.ToInt32(Session["UserId"] as string);

            if (userId != 0)
            {
                var check = (from uf1 in objContext.UserFollowers where (uf1.LoginId == userId && uf1.FollowerId==Followerid) select uf1).FirstOrDefault();
                if (check == null)
                {
                    UserFollowers uf = new UserFollowers();
                    uf.LoginId = userId;
                    uf.FollowerId = Followerid;
                    uf.RequestStatus = "P";
                    uf.SentDate = DateTime.Now;
                    objContext.UserFollowers.Add(uf);
                    objContext.SaveChanges();
                    return Json("Request Sent");
                }
                else
                {
                    check.RequestStatus = "P";
                    objContext.Entry(check).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();
                    return Json("Request sent");
                }
            }
            else
            {
                return Json("Please login to follow");
            }
        }

        [HttpPost]
        public PartialViewResult PendingRequests(int currentUserId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var totalFollowrequests = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == currentUserId && uf1.RequestStatus=="P") select uf1).ToList();
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.IdNameStatus = new List<IdNameStatus>();
            foreach (var tf in totalFollowrequests)
            {
                IdNameStatus ids = new IdNameStatus();
                ids.id = tf.LoginId;
                var user = (from l in objContext.Logins where l.LoginId == tf.LoginId select l).FirstOrDefault();
                ids.Username= string.Format("{0} {1}", user.FirstName, user.LastName);
                ids.FlollowStatus = tf.RequestStatus;
                maid.IdNameStatus.Add(ids);
            }
            return PartialView("_PendingRequests",maid);
        }

        [HttpPost]
        public  PartialViewResult otherRequests(int currentUserId)
        {
            IEnumerable<UserFollowers> otherrequests;
            using (TollywoodMDBcontext objContext = new TollywoodMDBcontext())
            {
                otherrequests = (from uf1 in objContext.UserFollowers where ( uf1.LoginId == currentUserId && uf1.ReadStatus == "N") select uf1).ToList();
            }
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.IdNameStatus = new List<IdNameStatus>();
            foreach (var tf in otherrequests)
            {
                using (TollywoodMDBcontext objContext1 = new TollywoodMDBcontext())
                {
                    IdNameStatus ids = new IdNameStatus();
                    ids.id = tf.FollowerId;
                    var user = (from l in objContext1.Logins where l.LoginId == tf.FollowerId select l).FirstOrDefault();
                    ids.Username = string.Format("{0} {1}", user.FirstName, user.LastName);
                    ids.FlollowStatus = tf.RequestStatus;
                    ids.StatusDate = DateTime.Now;
                    maid.IdNameStatus.Add(ids);
                    tf.ReadStatus = "Y";
                    objContext1.Entry(tf).State = System.Data.Entity.EntityState.Modified;
                    objContext1.SaveChanges();
                }
            }
            return PartialView("_otherRequests", maid);
        }

        [HttpPost]
        public JsonResult Accept( int FollowerId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            int userId = Convert.ToInt32(Session["UserId"] as string);
            var currentUser = (from l in objContext.Logins where l.LoginId == userId select l).FirstOrDefault();
            var followerRow = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == userId && uf1.LoginId == FollowerId) select uf1).FirstOrDefault();
            followerRow.RequestStatus = "Y";
            followerRow.ReadStatus = "N";
            followerRow.SentDate = DateTime.Now;
            objContext.Entry(followerRow).State = System.Data.Entity.EntityState.Modified;
            objContext.SaveChanges();
            return Json("1");
        }
        [HttpPost]
        public JsonResult Reject(int FollowerId)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            int userId = Convert.ToInt32(Session["UserId"] as string);
            var currentUser = (from l in objContext.Logins where l.LoginId == userId select l).FirstOrDefault();
            var followerRow = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == userId && uf1.LoginId == FollowerId) select uf1).FirstOrDefault();
            followerRow.RequestStatus = "R";
            followerRow.ReadStatus = "N";
            followerRow.SentDate = DateTime.Now;
            objContext.Entry(followerRow).State = System.Data.Entity.EntityState.Modified;
            objContext.SaveChanges();
            return Json("1");
        }

        [HttpPost]
        public PartialViewResult TotalUserFollowers(int CurrentUserID)
        {
            var userid = Convert.ToInt32(Session["Userid"] as string);
            var totalFollowers = (from uf1 in objContext.UserFollowers where uf1.FollowerId == CurrentUserID select uf1).ToArray();
            MovieAndImagesDetails maid = new MovieAndImagesDetails();
            maid.IdNameStatus = new List<IdNameStatus>();
            foreach (var uf in totalFollowers)
            {
                IdNameStatus ids = new IdNameStatus();
                var user = (from l in objContext.Logins where l.LoginId == uf.LoginId  select l).FirstOrDefault();
                ids.Username = string.Format("{0} {1}", user.FirstName, user.LastName);
                ids.id = user.LoginId;

                var followstatus = (from uf1 in objContext.UserFollowers where (uf1.FollowerId == CurrentUserID && uf1.LoginId == user.LoginId) select uf1).FirstOrDefault();
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
            return PartialView("_TotalUserFollowers", maid);
        }
    }
}