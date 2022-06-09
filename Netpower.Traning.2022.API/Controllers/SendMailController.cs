using Microsoft.AspNetCore.Mvc;
using Netpower.Traning._2022.Core;
using Netpower.Traning._2022.DTOs;
using System.Net;
using System.Net.Mail;

namespace Netpower.Traning._2022.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SendMailController : ControllerBase
{
     [HttpPost(Name = "SendMail")]
     public OkObjectResult SendMail([FromBody] MailInfoDTO mailInfo)
     {
          Mail.Send(mailInfo.MailTo, mailInfo.Subject, mailInfo.Content);

          return Ok("Email was sent to " + mailInfo.MailTo);
     }
}