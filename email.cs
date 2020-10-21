using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;
using System.CodeDom.Compiler;

namespace ScorpioJelszoMenedzser
{
    class email
    {
        public static string GeneratedCode;
        public static void sendEmail(string text, string clientEmail, string felhasznalo)
        {
            var fromAddress = new MailAddress("******", "*****");
            var toAddress = new MailAddress("*******", felhasznalo);
            const string fromPassword = "*****";
            const string subject = "Visszajelzés";
            string body = text + "\nFelhasználó email címe: -> " + clientEmail + "\nFelhasználó: " + felhasznalo;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                MessageBox.Show("Visszajelzés sikeresen elküldve!");
            }
        }
        public static string generateAuthenticationCode()
        {
            Random rnd = new Random();
            string rndCode = "";
            for (int i = 0; i < 6; i++)
            {
                rndCode += rnd.Next(0, 6);
            }
            return rndCode;
        }
        public static void passwordRecovery(string felhasznalo, string email)
        {
            var fromAddress = new MailAddress("*****", "****");
            var toAddress = new MailAddress(email, felhasznalo);
            const string fromPassword = "*****";
            const string subject = "Visszajelzés";
            GeneratedCode = generateAuthenticationCode().ToString();
            string body = "A generált kód:\n" + GeneratedCode;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                MessageBox.Show("Kód sikeresen elküldve!");
            }
        }

    }
}
