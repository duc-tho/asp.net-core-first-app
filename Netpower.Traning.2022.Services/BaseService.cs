using Netpower.Traning._2022.Core;

namespace Netpower.Traning._2022.Services
{
     public abstract class BaseService
     {
          protected void SendEmailToAdmin(string Subject, string Content)
          {
               Mail.Send("tho.ngo@netpower.no", Subject, Content);
          }
     }
}
