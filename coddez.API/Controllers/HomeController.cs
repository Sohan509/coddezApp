using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SendEmailInAspNetCore.Helpers;
using SendEmailInAspNetCore.Models;
using System;
using System.Diagnostics;

namespace SendEmailInAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
 
        [HttpPost("sendmail")]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string emailBody = string.Empty;
                    bool useEmailTemplate = false;
                    //instantiate a new MimeMessage
                    var message = new MimeMessage();

                    //Setting the To e-mail address
                    message.To.Add(new MailboxAddress("Sohan Musa", "asm509sohan@gmail.com"));
                    //Setting the From e-mail address
                    message.From.Add(new MailboxAddress(contactViewModel.Name, contactViewModel.Email));
                    //E-mail subject 
                    message.Subject = contactViewModel.Subject;
                    //E-mail message body
                    if (useEmailTemplate)
                    {
                        emailBody = ViewsToStringOutputHelper.RenderRazorViewToString(this, "Welcome", null);
                    }
                    else
                    {
                        emailBody = contactViewModel.Message  + "<br/> <br/> <br/> Message was sent by: " + contactViewModel.Name + " <br/> E-mail: " + contactViewModel.Email;

                    }
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = emailBody
                    };

                    //Configure the e-mail
                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate(contactViewModel.Email, contactViewModel.password); 
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }

                    return Ok();
                }
                catch (Exception ex)
                {

                    ModelState.Clear();
                    ViewBag.Exception = $" Oops! Message could not be sent. Error:  {ex.Message}";
                    return BadRequest();
                }

            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Welcome()
        {
            return View();
        }

    }
}