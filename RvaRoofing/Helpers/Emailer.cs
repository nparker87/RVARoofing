namespace RvaRoofing.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using System.Web.Configuration;

    public class Emailer
    {
        public static void SendMsg(string toAddress, string fromAddress, string fromName, string subject, string body, EmailList cc = null, EmailList bcc = null)
        {
            toAddress = String.IsNullOrWhiteSpace(toAddress) ? "rvaroofing.inc@gmail.com" : toAddress;

            // Error handling for addresses
            if (!IsValidEmail(toAddress)) return;

            var msg = new MailMessage
            {
                To = { new MailAddress(toAddress) },
                From = new MailAddress(fromAddress),
                Body = body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal,
                Subject = subject
            };

            // Add any cc'd
            if (cc != null)
                foreach (var email in cc.Emails)
                    if (IsValidEmail(email))
                        msg.CC.Add(new MailAddress(cc.ToString()));

            // Add any bcc'd
            if (bcc != null)
                foreach (var email in bcc.Emails)
                    if (IsValidEmail(email))
                        msg.CC.Add(new MailAddress(bcc.ToString()));

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["GmailUsername"], WebConfigurationManager.AppSettings["GmailPassword"]);

            smtp.Send(msg);
        }

        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
                return false;

            // checks to make sure e-mail is valid
            var reg = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b");
            return reg.IsMatch(email);
        }

        /// <summary>
        /// Used for a list of cc or bcc emails
        /// </summary>
        public class EmailList
        {
            public List<string> Emails { get; set; }
        }
    }
}