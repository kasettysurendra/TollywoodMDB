using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TollywoodMDB.Models;
using TollywoodMDB.Models.DataClasses;
using TollywoodMDB.Models.ViewModel;

namespace TollywoodMDB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Logins login)
        {
            if (ModelState.IsValid)
            {
                TollywoodMDBcontext objConext = new TollywoodMDBcontext();
                if (objConext.Logins.Where(u => u.EmailId == login.EmailId).FirstOrDefault() == null)
                {
                    login.Role = "user";
                    AesEncDec encrypt = new AesEncDec();
                    login.Password = encrypt.AesEnc(login.Password);
                    objConext.Logins.Add(login);
                    objConext.SaveChanges();
                    Session["UserEmail"] = login.EmailId;
                    Session["UserId"] = (from l in objConext.Logins where l.EmailId == login.EmailId select l).FirstOrDefault().LoginId.ToString();
                    Emails email = new Emails();
                    email.SendRegisterEmail(login.EmailId, login.FirstName, login.LastName);
                    int UserId = (from l in objConext.Logins where l.EmailId == login.EmailId select l).FirstOrDefault().LoginId;
                    ViewBag.PopUpStatus = "Registration successfull";
                    //ViewBag.OkayStatus = @"\Movies\Index";
                    return RedirectToAction("Index","Movies");
                }
                else
                {
                    ViewBag.PopUpStatus = "Email id already exists,please use login";
                    return View("Register");
                }
            }
            else
            {
                return View("Register");
            }
        }
        [HttpGet]
        public ActionResult LoginTemplete()
        {
            return PartialView("_LoginTemplete");
        }
        [HttpPost]
        public ActionResult LoginTemplete(string id, string Password,bool Remember)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(Password))
            {
                return Json("Please Enter valid credentials.");
            }
            else
            {
                TollywoodMDBcontext objConext = new TollywoodMDBcontext();
                var user = objConext.Logins.Where(u => u.EmailId == id).FirstOrDefault();
                if (user == null)
                {
                    return Json("Please Enter valid credentials.");
                }
                else
                {
                    AesEncDec encrypt = new AesEncDec();
                    string encPassword = encrypt.AesEnc(Password);
                    if (user.Password == encPassword)
                    {
                        Session["UserEmail"] = user.EmailId;
                        Session["UserId"] = user.LoginId.ToString();
                        //FormsAuthentication.SetAuthCookie(user.EmailId, Remember);
                        //var authTicket = new FormsAuthenticationTicket(1, user.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                        //var encryptticket = FormsAuthentication.Encrypt(authTicket);
                        //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptticket);
                        //HttpContext.Response.Cookies.Add(cookie);
                        //var roles = authTicket.UserData.Split(',');
                        //System.Web.HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                        return Json("Login Successfull");
                    }

                    else
                        return Json("Please Enter valid credentials.");
                }
            }

        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return Content("LoggedOut");
        }
        [HttpGet]
        public ActionResult uploadProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadProfile(LoginfilesViewModel ObjViewModel)
        {
            LoginFiles lf = new LoginFiles();
            lf.LoginId = ObjViewModel.id;
            lf.UploadedDate = DateTime.Now;
            var bytes = new byte[ObjViewModel.ProfilePicture.InputStream.Length];
            ObjViewModel.ProfilePicture.InputStream.Read(bytes, 0, bytes.Length);
            lf.ProfilePicture = bytes;
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            objContext.LoginFiles.Add(lf);
            objContext.SaveChanges();
            return View();
        }

        public ActionResult GetImage(int Id)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            byte[] ProfilePicture;
            if (((from lf in objContext.LoginFiles select lf.LoginId).ToArray().Contains(Id)))
            {
                 ProfilePicture = objContext.LoginFiles.Where(lf => lf.LoginId == Id).FirstOrDefault().ProfilePicture;
                return File(ProfilePicture, "image/jpeg");
            }
            else
            {
                ProfilePicture= objContext.LoginFiles.Where(lf => lf.LoginId == 2).FirstOrDefault().ProfilePicture;
                return File(ProfilePicture, "image/jpeg");
            }
            
        }

        public JsonResult ForgotPassword(string emailId)
        {
            if (!string.IsNullOrEmpty(emailId))
            {
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                var login = (from l in objContext.Logins where l.EmailId == emailId select l).FirstOrDefault();
                if (login != null)
                {
                    Emails email = new Emails();
                    email.ForgotPasswordEmail(emailId);
                    return Json("Password is triggered to your email");
                }
                else
                {
                    return Json("Please Enter valid Email");
                }
            }
            else {
                return Json("Please enter your Email");
            }

        }

    }
}