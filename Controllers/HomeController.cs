using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlikaOglasi.Models;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace SlikaOglasi.Controllers
{
    
    public class HomeController : Controller
    {
        public IStringLocalizer<Resource> localizer;

        public HomeController(IStringLocalizer<Resource> localizer)
        {
            this.localizer = localizer;
        }
        public IActionResult SetCulture(string culture,string sourceUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)
                    ),
                new CookieOptions
                {
                    Expires=DateTimeOffset.UtcNow.AddYears(1)
                }
                );
            return Redirect(sourceUrl);
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
          
        }
        

        [HttpPost]

        public IActionResult Contact(Kontakt k)
        {
            if (ModelState.IsValid)
            {

                StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(k.Email.ToString());
                message.Append("Name: " + k.Ime + "\n");
                message.Append("Email: " + k.Email + "\n");
                message.Append("Telephone: " + k.Telefon + "\n\n");
                message.Append(k.Poruka);

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.mail.yahoo.com";
                smtp.Port = 465;

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("yahooaccount", "yahoopassword");

                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                mail.From = from;
                mail.To.Add("yahooemailaddress");
                mail.Subject = "Test enquiry from " + k.Ime;
                mail.Body = message.ToString();

                smtp.Send(mail);

            }
            
            return View("Index");
            

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
    }
}
