using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

using Microsoft.Win32;

namespace ScorpioJelszoMenedzser
{
    class RegClass
    {
        public static string createHash(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash.ToString();
        }
        public static bool validateHashCode(string password, string savedPassword)
        {
            if (createHash(password) == savedPassword) return true;
            else return false;
        }
        public static void saveCredentials(string user, string email, string pass)
        {
            // registry létrehozása ha nem létezik
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ScorpioPasswordManagerCredentials");
            key.Close();

            //mentés a registrybe
            Microsoft.Win32.RegistryKey rkey;
            rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ScorpioPasswordManagerCredentials");
            rkey.SetValue(user + "_Email", email);
            rkey.SetValue(user + "_Jelszo", pass);
            rkey.Close();
        }
        public static void updateCredentials(string user, string newPassword)
        {
            Microsoft.Win32.RegistryKey rkey;
            rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ScorpioPasswordManagerCredentials");
            rkey.SetValue(user + "_Jelszo", createHash(newPassword));
            rkey.Close();
        }
    }
}
