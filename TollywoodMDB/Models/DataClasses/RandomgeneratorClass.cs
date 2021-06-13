using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models.DataClasses
{
    public class RandomgeneratorClass
    {
        public string RandomPasswordGenerator()
        {
            Random rdm = new Random();
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXY0123456789abcdefghijklmnopqrstuvwxyz";
            string randomPassword = "";
           for (int i = 0; i <= 7; i++)
            {

                randomPassword += str[rdm.Next(str.Length)];

            }
            return randomPassword;
        } 
    }
}