using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ScholarshipApp.Utilities
{
    public class EmailUtility
    {
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailUtility()
        {
            _senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"];
            _senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"];
        }
        public bool SendEmail(string email, int status)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_senderEmail);
                    mail.To.Add(email);
                    mail.Subject = "Scholarship Application Response";
                    mail.Body = status == 1 ?
                        System.Configuration.ConfigurationManager.AppSettings["AcceptanceEmail"] :
                        System.Configuration.ConfigurationManager.AppSettings["RejectionEmail"] ;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return true;

            }
            catch (Exception e)
            {
                return false;

            }

        }
    }
}