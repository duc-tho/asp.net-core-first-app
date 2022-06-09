using System.Net;
using System.Net.Mail;

namespace Netpower.Traning._2022.Core;

public static class Mail
{
     public static void Send(string MailTo, string Subject, string Content)
     {
          MailMessage mail = new MailMessage();
          mail.From = new MailAddress("thopk007113@gmail.com");
          mail.To.Add(MailTo);
          mail.Subject = Subject;
          mail.Body = Content;

          SmtpClient client = new SmtpClient("smtp.gmail.com")
          {
               Credentials = new NetworkCredential("thopk007113@gmail.com", "wpeqqfswzefhqapf"),
               EnableSsl = true,
          };

          client.Send(mail);
     }
}
