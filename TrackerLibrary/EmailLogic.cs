using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TrackerLibrary
{
    public class EmailLogic
    {
        public static void sendEmail(string to, string subject, string body)
        {
            
        }
        public static void sendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage mail = new MailMessage();
            foreach (string email in to)
            {
                mail.To.Add(email);
            }
            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }
            mail.From = fromAddress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }
    }
}
