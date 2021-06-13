using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TollywoodMDB.Models.DataClasses
{
    public class Emails
    {
        public int SendRegisterEmail(string toEmail, string fname, string lname)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mail = new MailMessage("surendra.chinna.k@gmail.com", toEmail);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("surendra.chinna.k@gmail.com", "surichinna3275464");
                mail.Subject = "TollywoodMDB.com";
                mail.IsBodyHtml = true;
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                string content = objContext.EmailsTable.Where(e => e.EmailID == 2).FirstOrDefault().EmailContent;
                mail.Body = "Dear " + fname + " " + lname +"<br/>"+ content;
                try { smtp.Send(mail); return 1; }
                catch (Exception em) { return 0; }

            }
            catch
            {
                return 0;
            }
        }

        public int ForgotPasswordEmail(string toEmail)
        {
            TollywoodMDBcontext objContext = new TollywoodMDBcontext();
            var login = (from l in objContext.Logins where l.EmailId == toEmail select l).FirstOrDefault();
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mail = new MailMessage("surendra.chinna.k@gmail.com", toEmail);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("surendra.chinna.k@gmail.com", "surichinna3275464");
                mail.Subject = "TollywoodMDB.com";
                mail.IsBodyHtml = true;
                string content = objContext.EmailsTable.Where(e => e.EmailID == 2).FirstOrDefault().EmailContent;
                RandomgeneratorClass rgc = new RandomgeneratorClass();
                string password = rgc.RandomPasswordGenerator();
;                mail.Body = "Dear " + login.FirstName + " " + login.LastName + "<br/>" +
                             "please use the below password for login to TollywoodMDB.com<br/><br/><b>Password:<b/><span style="+"color:blue;"+">"+
                             password +"<span/><br/><br/>Team,<br/>TollywoodMDB.com";
                try
                {
                    smtp.Send(mail);
                    AesEncDec enc = new AesEncDec();
                    login.Password = enc.AesEnc(password);
                    objContext.Entry(login).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();
                    return 1;
                }
                catch (Exception em)
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}