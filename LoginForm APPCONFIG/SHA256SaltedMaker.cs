using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;

namespace LoginForm_APPCONFIG
{
    
    public class SHA256SaltedMaker
    {

        public string plaintext;
        public string hash;
        

        public SHA256SaltedMaker (string p)
        {
            plaintext = p;
            hash = makeHash(plaintext);
        }

        
        public string makeHash(string plaintext)
        {

            string salt = PrintSalt();

            byte[] bytes = Encoding.Unicode.GetBytes(plaintext + salt);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
        }

        public static void UpdateSalt (string salt)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["salt"].Value = salt;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
            
        }

        public static string PrintSalt()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string salt = appSettings["salt"];

            return salt;
        }

        public override string ToString()
        {
            return hash;
        }


    }
}
